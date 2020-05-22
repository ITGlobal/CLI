using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalWriteQueue : IDisposable
    {
        private readonly struct QueuedChar
        {
            public QueuedChar(char c, ConsoleColor? fg, ConsoleColor? bg, ConsoleStream stream)
            {
                Char = c;
                Fg = fg;
                Bg = bg;
                Stream = stream;
            }

            public readonly char Char;
            public readonly ConsoleColor? Fg;
            public readonly ConsoleColor? Bg;
            public readonly ConsoleStream Stream;

            public override string ToString() => $"\"{Char}\" ({Stream}, {Fg}/{Bg})";
        }

        private const int FLUSH_PERIOD_MS = 10;

        private readonly object _queueLock = new object();
        private readonly Queue<QueuedChar> _queue = new Queue<QueuedChar>();
        private bool _isRunning = true;
        private char[] _buffer;

        private readonly Task _flushTask;
        private long _iteration;

        public WindowsTerminalWriteQueue()
        {
            _flushTask = Task.Factory.StartNew(FlushThread, TaskCreationOptions.LongRunning);
        }

        public WindowsTerminalWriter StdErrWriter { get; set; }
        public WindowsTerminalWriter StdOutWriter { get; set; }

        public void Enqueue(char c, ConsoleColor? fg, ConsoleColor? bg, ConsoleStream stream)
        {
            lock (_queueLock)
            {
                _queue.Enqueue(new QueuedChar(c, fg, bg, stream));
                Monitor.PulseAll(_queueLock);
            }
        }

        public void Flush()
        {
            long iteration;
            lock (_queueLock)
            {
                iteration = _iteration + _queue.Count;
                Monitor.PulseAll(_queueLock);
            }

            while (true)
            {
                lock (_queueLock)
                {
                    if (_iteration >= iteration)
                    {
                        return;
                    }

                    Monitor.Wait(_queueLock);
                }
            }
        }

        public void Dispose()
        {
            lock (_queueLock)
            {
                _isRunning = false;
                Monitor.PulseAll(_queueLock);
            }

            try
            {
                _flushTask.Wait();
            }
            catch (Exception e)
            {
                Trace.WriteLine($"{nameof(WindowsTerminalWriteQueue)} failed to stop: {e}");
            }
        }

        private void FlushThread()
        {
            var localQueue = new List<QueuedChar>();
            while (true)
            {
                Thread.Sleep(FLUSH_PERIOD_MS);

                var hasMoreData = true;
                while (hasMoreData)
                {
                    ReadQueue(localQueue, out var stream, out var isDisposed, out hasMoreData);
                    if (isDisposed)
                    {
                        return;
                    }

                    FlushQueue(localQueue, stream);
                    
                    lock (_queueLock)
                    {
                        _iteration+= localQueue.Count;
                        Monitor.PulseAll(_queueLock);
                    }

                    localQueue.Clear();
                }
            }
        }

        private void ReadQueue(
            List<QueuedChar> localQueue,
            out ConsoleStream stream,
            out bool isDisposed,
            out bool hasMoreData)
        {
            stream = default;
            isDisposed = false;
            hasMoreData = false;

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
                        var c = _queue.Peek();
                        if (localQueue.Count > 0)
                        {
                            if (c.Stream != stream)
                            {
                                hasMoreData = true;
                                return;
                            }
                        }
                        else
                        {
                            stream = c.Stream;
                        }

                        _queue.Dequeue();
                        localQueue.Add(c);
                    }

                    if (localQueue.Count == 0 && !_isRunning)
                    {
                        isDisposed = true;
                    }

                    return;
                }
            }
        }

        private void FlushQueue(List<QueuedChar> localQueue, ConsoleStream stream)
        {
            var writer = stream switch
            {
                ConsoleStream.StdErr => StdErrWriter,
                ConsoleStream.StdOut => StdOutWriter,
                _ => null
            };

            if (writer != null)
            {
                FlushQueue(localQueue, writer);
            }
        }

        private void FlushQueue(List<QueuedChar> localQueue, WindowsTerminalWriter writer)
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
                        writer.Write(chunk);
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
                writer.Write(chunk);
            }
        }
    }
}