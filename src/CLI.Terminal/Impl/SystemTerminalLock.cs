using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class SystemTerminalLock : ITerminalLock
    {
        private readonly TextWriter _stdOut;
        private readonly TextWriter _stdErr;
        private readonly Encoding _outputEncoding;

        public SystemTerminalLock(ITerminal terminal, ITerminalLockOwner owner)
        {
            _stdOut = Console.Out;
            _stdErr = Console.Error;
            _outputEncoding = Console.OutputEncoding;

            Console.SetOut(new SafeTextWriter(_stdOut, owner));
            Console.SetError(new SafeTextWriter(_stdErr, owner));

            Console.OutputEncoding = Encoding.UTF8;

            Stdout = terminal.Stdout;
            Stderr = terminal.Stderr;
        }

        public ITerminalOutput Stdout { get; }
        public ITerminalOutput Stderr { get; }

        public void Dispose()
        {
            Console.SetOut(_stdOut);
            Console.SetError(_stdErr);
            Console.OutputEncoding = _outputEncoding;
        }

        private sealed class SafeTextWriter : TextWriter
        {
            private readonly TextWriter _writer;
            private readonly ITerminalLockOwner _owner;

            public SafeTextWriter(TextWriter writer, ITerminalLockOwner owner)
            {
                _writer = writer;
                _owner = owner;
            }

            public override Encoding Encoding => _writer.Encoding;

            public override void Write(char value)
            {
                _owner.BeginPrint();

                switch (value)
                {
                    case '\n':
                        _writer.WriteLine();
                        _owner.Redraw();
                        break;
                    case '\r':
                        break;
                    default:
                        _writer.Write(value);
                        break;

                }

                _owner.EndPrint();
            }
        }
    }
}