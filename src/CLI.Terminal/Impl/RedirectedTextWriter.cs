using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RedirectedTextWriter : TextWriter
    {
        private readonly TextWriter _writer;
        private readonly LockedTerminalImplementation _output;
        private readonly StreamType _stream;

        public RedirectedTextWriter(TextWriter writer, LockedTerminalImplementation output, StreamType stream)
        {
            _writer = writer;
            _output = output;
            _stream = stream;
        }

        public override Encoding Encoding => _writer.Encoding;

        public override void Write(char value)
        {
            _output.Write(_stream, value, Console.ForegroundColor, Console.BackgroundColor);
        }
    }
}