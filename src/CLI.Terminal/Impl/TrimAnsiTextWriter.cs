using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TrimAnsiTextWriter : AnsiTextWriterBase
    {
        private readonly TextWriter _writer;

        public TrimAnsiTextWriter(TextWriter writer)
            : base(writer.Encoding)
        {
            _writer = writer;
        }


        protected override void WriteImpl(char c, ConsoleColor? fg, ConsoleColor? bg)
        {
            _writer.Write(c);
        }

        protected override void Dispose(bool disposing)
        {
            _writer.Dispose();
        }
    }
}