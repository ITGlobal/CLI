using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TrimAnsiTextWriter : TextWriter, IAnsiCommandHandler
    {
        private readonly TextWriter _writer;
        private readonly AnsiSequenceDecoder _decoder;

        public TrimAnsiTextWriter(TextWriter writer)
        {
            _writer = writer;
            _decoder = new AnsiSequenceDecoder(this);
        }

        public override Encoding Encoding => _writer.Encoding;

        public override void Write(char value)
        {
            _decoder.Process(value);
        }

        void IAnsiCommandHandler.SetForegroundColor(ConsoleColor color)
        { }

        void IAnsiCommandHandler.SetBackgroundColor(ConsoleColor color)
        { }

        void IAnsiCommandHandler.SetColors(ConsoleColor foreground, ConsoleColor background)
        { }

        void IAnsiCommandHandler.ResetColors()
        { }

        void IAnsiCommandHandler.Write(char c)
        {
            _writer.Write(c);
        }
    }
}