using System;
using System.Collections.Generic;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class LockedTerminalImplementation : ITerminalLock, ITerminalImplementation
    {
        private readonly struct ConsoleChar
        {
            public ConsoleChar(StreamType stream, AnsiChar c)
            {
                Stream = stream;
                Char = c;
            }

            public readonly StreamType Stream;
            public readonly AnsiChar Char;

            public override string ToString()
            {
                var stream = Stream == StreamType.Error ? "stderr" : "stdout";
                return $"{stream} \"{Char.Char}\" {Char.ForegroundColor}/{Char.BackgroundColor}";
            }
        }

        private readonly ITerminalImplementation _terminal;
        private readonly ITerminalLockOwner _owner;

        private readonly TextWriter _stdout;
        private readonly TextWriter _stderr;

        private readonly ITerminalWriter _stdoutWriter;
        private readonly ITerminalWriter _stderrWriter;

        private readonly List<ConsoleChar> _chars = new List<ConsoleChar>();

        private readonly object _syncRoot = new object();

        public LockedTerminalImplementation(ITerminalImplementation terminal, ITerminalLockOwner owner)
        {
            _terminal = terminal;
            _owner = owner;

            _stdout = Console.Out;
            _stderr = Console.Error;

            _stdoutWriter = new RedirectedTerminalWriter(this, StreamType.Output);
            _stderrWriter = new RedirectedTerminalWriter(this, StreamType.Error);
        }

        public void Dispose()
        {
            Console.SetOut(_stdout);
            Console.SetError(_stderr);

            Terminal.UseImplementation(_terminal);

            if (_chars.Count > 0)
            {
                foreach (var x in _chars)
                {
                    ITerminalWriter output;
                    switch (x.Stream)
                    {
                        case StreamType.Output:
                            output = _terminal.Stdout;
                            break;
                        case StreamType.Error:
                            output = _terminal.Stderr;
                            break;
                        default:
                            continue;
                    }

                    output.Write(AnsiString.FromChar(x.Char));
                }
            }
        }

        ITerminalWriter ITerminalLock.Stdout => _terminal.Stdout;
        ITerminalWriter ITerminalLock.Stderr => _terminal.Stderr;
        string ITerminalImplementation.DriverName => _terminal.DriverName;
        int ITerminalImplementation.WindowWidth => _terminal.WindowWidth;

        public ITerminalImplementation Clone()
        {
            return new LockedTerminalImplementation(_terminal, _owner);
        }

        public void Initialize()
        {
            Console.SetOut(new RedirectedTextWriter(_terminal.Stdout, Console.Out.Encoding, this, StreamType.Output));
            Console.SetError(new RedirectedTextWriter(_terminal.Stderr, Console.Error.Encoding , this, StreamType.Error));
        }

        public void MoveToLine(int offset) => _terminal.MoveToLine(offset);

        void ITerminalLock.ClearLine() => _terminal.ClearLine();

        ITerminalWriter ITerminalImplementation.Stdout => _stdoutWriter;

        ITerminalWriter ITerminalImplementation.Stderr => _stderrWriter;

        void ITerminalImplementation.ClearLine()
        {
            lock (_syncRoot)
            {
                _chars.Clear();
            }
        }

        public void Write(StreamType stream, char c, ConsoleColor? fg, ConsoleColor? bg)
        {
            lock (_syncRoot)
            {
                if (c == '\r')
                {
                    return;
                }

                _chars.Add(new ConsoleChar(stream, new AnsiChar(c, fg, bg)));

                if (c == '\n')
                {
                    _owner.Begin();
                    foreach (var x in _chars)
                    {
                        switch (x.Stream)
                        {
                            case StreamType.Output:
                                _owner.WriteOutput(x.Char);
                                break;
                            case StreamType.Error:
                                _owner.WriteError(x.Char);
                                break;
                        }
                    }

                    _owner.End();
                    _chars.Clear();
                }
            }
        }
    }
}