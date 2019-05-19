using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class AnsiTextWriter : TextWriter, IAnsiCommandHandler
    {
        private readonly TextWriter _writer;
        private readonly AnsiSequenceDecoder _decoder;

        public AnsiTextWriter(TextWriter writer)
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
        {
            Console.ForegroundColor = color;
        }

        void IAnsiCommandHandler.SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        void IAnsiCommandHandler.ResetColors()
        {
            Console.ResetColor();
        }

        void IAnsiCommandHandler.Write(char c)
        {
            switch (c)
            {
                case '\r':
                    break;
                case '\n':
                    _writer.WriteLine();
                    break;
                default:
                    _writer.Write(c);
                    break;
            }

        }
    }
}