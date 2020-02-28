using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITGlobal.CommandLine.Impl
{
    internal class BufferedAnsiTextWriter : AnsiTextWriterBase
    {
        private readonly struct QueuedChar
        {
            public QueuedChar(char c, ConsoleColor? fg, ConsoleColor? bg)
            {
                Char = c;
                Fg = fg;
                Bg = bg;
            }

            public readonly char Char;
            public readonly ConsoleColor? Fg;
            public readonly ConsoleColor? Bg;

            public override string ToString() => $"\"{Char}\" ({Fg}/{Bg})";
        }

        private const int FLUSH_PERIOD_MS = 100;

        private readonly ITerminalWriter _writer;

        private readonly object _queueLock = new object();
        private readonly Queue<QueuedChar> _queue = new Queue<QueuedChar>();
        private bool _isRunning = true;
        private char[] _buffer;

        private readonly Task _flushTask;
        private long _iteration;

        public BufferedAnsiTextWriter(ITerminalWriter writer, Encoding encoding)
            : base(encoding)
        {
            _writer = writer;
            _flushTask = Task.Factory.StartNew(FlushThread, TaskCreationOptions.LongRunning);

            AppDomain.CurrentDomain.ProcessExit += (_, e) => { Dispose(false); };
        }

        public override void Flush()
        {
            long iteration;
            lock (_queueLock)
            {
                iteration = _iteration;
                Monitor.Pulse(_queueLock);
            }

            while (true)
            {
                lock (_queueLock)
                {
                    if (_iteration > iteration)
                    {
                        return;
                    }

                    Monitor.Wait(_queueLock);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            lock (_queueLock)
            {
                _isRunning = false;
                Monitor.Pulse(_queueLock);
            }

            try
            {
                _flushTask.Wait();
            }
            catch (Exception e)
            {
                Trace.WriteLine($"{nameof(BufferedAnsiTextWriter)} failed to stop: {e}");
            }
        }

        protected override void WriteImpl(char c, ConsoleColor? fg, ConsoleColor? bg)
        {
            lock (_queueLock)
            {
                _queue.Enqueue(new QueuedChar(c, fg, bg));
                Monitor.Pulse(_queueLock);
            }
        }

        private void FlushThread()
        {
            var localQueue = new List<QueuedChar>();
            while (true)
            {
                Thread.Sleep(FLUSH_PERIOD_MS);

                ReadQueue(localQueue, out var isDisposed);
                if (isDisposed)
                {
                    return;
                }

                FlushQueue(localQueue);
                localQueue.Clear();

                lock (_queueLock)
                {
                    _iteration++;
                    Monitor.PulseAll(_queueLock);
                }
            }
        }

        private void ReadQueue(List<QueuedChar> localQueue, out bool isDisposed)
        {
            isDisposed = false;

            while (true)
            {
                lock (_queueLock)
                {
                    if (_queue.Count == 0 && _isRunning)
                    {
                        Monitor.Wait(_queueLock);
                        continue;
                    }

                    while (_queue.Count > 0)
                    {
                        localQueue.Add(_queue.Dequeue());
                    }

                    if (localQueue.Count == 0 && !_isRunning)
                    {
                        isDisposed = true;
                    }

                    return;
                }
            }
        }

        private void FlushQueue(List<QueuedChar> localQueue)
        {
            if (localQueue.Count == 0)
            {
                return;
            }

            if (_buffer == null || _buffer.Length < localQueue.Count)
            {
                _buffer = new char[localQueue.Count];
            }

            for (var i = 0; i < localQueue.Count; i++)
            {
                _buffer[i] = localQueue[i].Char;
            }

            var offset = 0;
            var length = 0;
            var fg = localQueue[0].Fg;
            var bg = localQueue[0].Bg;

            for (var i = 0; i < localQueue.Count; i++)
            {
                var c = localQueue[i];
                if (fg == c.Fg && bg == c.Bg)
                {
                    length++;
                }
                else
                {
                    if (length > 0)
                    {
                        var chunk = new AnsiString.Chunk(_buffer, offset, length, fg, bg);
                        _writer.Write(chunk);
                    }

                    fg = c.Fg;
                    bg = c.Bg;

                    offset = i;
                    length = 1;
                }
            }

            if (length > 0)
            {
                var chunk = new AnsiString.Chunk(_buffer, offset, length, fg, bg);
                _writer.Write(chunk);
            }
        }
    }
}
