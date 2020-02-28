using System;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal class AnsiTextWriter : AnsiTextWriterBase
    {
        private readonly ITerminalWriter _writer;
        private readonly object _writerLock = new object();
        private readonly char[] _buffer = new char[1];

        public AnsiTextWriter(ITerminalWriter writer, Encoding encoding)
            : base(encoding)
        {
            _writer = writer;
        }

        protected override void WriteImpl(char c, ConsoleColor? fg, ConsoleColor? bg)
        {
            lock (_writerLock)
            {
                _buffer[0] = c;
                var chunk = new AnsiString.Chunk(_buffer, fg, bg);
                _writer.Write(chunk);
            }
        }
    }
}