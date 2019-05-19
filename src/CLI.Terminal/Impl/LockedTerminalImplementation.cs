using System;
using System.Collections.Generic;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class LockedTerminalImplementation : ITerminalLock, ITerminalImplementation, IDisposable
    {
        private readonly struct ConsoleChar
        {
            public ConsoleChar(StreamType stream, char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
            {
                Stream = stream;
                Char = c;
                ForegroundColor = foregroundColor;
                BackgroundColor = backgroundColor;
            }

            public readonly StreamType Stream;
            public readonly char Char;
            public readonly ConsoleColor? ForegroundColor;
            public readonly ConsoleColor? BackgroundColor;

            public override string ToString()
            {
                var stream = Stream == StreamType.Error ? "stderr" : "stdout";
                return $"{stream} \"{Char}\" {ForegroundColor}/{BackgroundColor}";
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

            Console.SetOut(new RedirectedTextWriter(_stdout, this, StreamType.Output));
            Console.SetError(new RedirectedTextWriter(_stderr, this, StreamType.Error));

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

                    output.Write(new ColoredString(new string(x.Char, 1), x.ForegroundColor, x.BackgroundColor));
                }
            }
        }

        ITerminalWriter ITerminalLock.Stdout => _terminal.Stdout;

        ITerminalWriter ITerminalLock.Stderr => _terminal.Stderr;

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
                    //todo clear current line
                    return;
                }

                _chars.Add(new ConsoleChar(stream, c, fg, bg));

                if (c == '\n')
                {
                    _owner.Begin();
                    foreach (var x in _chars)
                    {
                        switch (x.Stream)
                        {
                            case StreamType.Output:
                                _owner.WriteOutput(x.Char, x.ForegroundColor, x.BackgroundColor);
                                break;
                            case StreamType.Error:
                                _owner.WriteError(x.Char, x.ForegroundColor, x.BackgroundColor);
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