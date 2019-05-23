using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RedirectedTextWriter : TextWriter, IAnsiCommandHandler
    {
        private readonly TextWriter _writer;
        private readonly LockedTerminalImplementation _output;
        private readonly StreamType _stream;

        private readonly AnsiSequenceDecoder _ansiDecoder;
        private ConsoleColor? _foregroundColor;
        private ConsoleColor? _backgroundColor;

        public RedirectedTextWriter(TextWriter writer, LockedTerminalImplementation output, StreamType stream)
        {
            _writer = writer;
            _output = output;
            _stream = stream;

            _ansiDecoder = new AnsiSequenceDecoder(this);
        }

        public override Encoding Encoding => _writer.Encoding;

        public override void Write(char value)
        {
            _ansiDecoder.Process(value);
        }

        void IAnsiCommandHandler.SetForegroundColor(ConsoleColor color)
        {
            _foregroundColor = color;
        }

        void IAnsiCommandHandler.SetBackgroundColor(ConsoleColor color)
        {
            _backgroundColor = color;
        }

        void IAnsiCommandHandler.ResetColors()
        {
            _foregroundColor = null;
            _backgroundColor = null;
        }

        void IAnsiCommandHandler.Write(char c)
        {
            _output.Write(_stream, c, _foregroundColor, _backgroundColor);
        }
    }
}