using System;
using System.Threading;

namespace ITGlobal.CommandLine
{
    public sealed class LiveOutput : ILiveOutput, ITerminalLockOwner
    {
        private readonly ITerminalLock _terminal;

        private readonly object _outputLock = new object();

        private int _width;
        private ColoredString[] _lastOutput = null;

        public LiveOutput()
        {
            _terminal = Terminal.Lock(this);
        }

        public void Write(params ColoredString[] strs)
        {
            lock (_outputLock)
            {
                Clear();

                var width = 0;
                foreach (var str in strs)
                {
                    _terminal.Stderr.Write(str);
                    width += str.Text.Length;
                }

                _width = Math.Max(_width, width);
                _lastOutput = strs;
            }
        }

        public void WriteLine(params ColoredString[] strs)
        {
            lock (_outputLock)
            {
                Write(strs);
                _terminal.Stderr.WriteLine();
                _width = 0;
                _lastOutput = null;
            }
        }

        void ITerminalLockOwner.Begin()
        {
            Monitor.Enter(_outputLock);
            Clear();
        }

        void ITerminalLockOwner.WriteOutput(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var str = new ColoredString(new string(c, 1), foregroundColor, backgroundColor);
            _terminal.Stdout.Write(str);
        }

        void ITerminalLockOwner.WriteError(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var str = new ColoredString(new string(c, 1), foregroundColor, backgroundColor);
            _terminal.Stderr.Write(str);
        }

        void ITerminalLockOwner.End()
        {
            if (_lastOutput != null)
            {
                Write(_lastOutput);
            }

            Monitor.Exit(_outputLock);
        }

        public void Clear()
        {
            lock (_outputLock)
            {
                _terminal.ClearLine();
            }
        }

        public void Dispose()
        {
            _terminal.Dispose();
        }
    }
}