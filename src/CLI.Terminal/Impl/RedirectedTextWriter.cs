using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RedirectedTextWriter : AnsiTextWriter
    {
        private readonly LockedTerminalImplementation _output;
        private readonly StreamType _stream;
        
        public RedirectedTextWriter(TextWriter writer, LockedTerminalImplementation output, StreamType stream)
            : base(writer)
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