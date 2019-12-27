using System;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RedirectedTextWriter : AnsiTextWriter
    {
        private readonly LockedTerminalImplementation _output;
        private readonly StreamType _stream;

        public RedirectedTextWriter(ITerminalWriter writer, Encoding encoding, LockedTerminalImplementation output, StreamType stream)
            : base(writer, encoding)
        {
            _output = output;
            _stream = stream;
        }

        protected override void WriteImpl(char c, ConsoleColor? fg, ConsoleColor? bg)
        {
            _output.Write(_stream, c, fg, bg);
        }
    }
}