using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal class AnsiTextWriter : TextWriter, IAnsiCommandHandler
    {
        private readonly struct AnsiColors
        {
            public AnsiColors(ConsoleColor fg, ConsoleColor bg)
            {
                Fg = fg;
                Bg = bg;
            }

            public readonly ConsoleColor Fg;
            public readonly ConsoleColor Bg;

            public override string ToString() => $"{Fg}/{Bg}";

            public AnsiColors With(ConsoleColor? fg = null, ConsoleColor? bg = null) => new AnsiColors(fg ?? Fg, bg ?? Bg);
        }

        private readonly ITerminalWriter _writer;
        private readonly AnsiSequenceDecoder _decoder;
        private readonly Stack<AnsiColors> _colorHistory = new Stack<AnsiColors>();
        private AnsiColors? _colors;
        private readonly char[] _buffer = new char[1];

        public AnsiTextWriter(ITerminalWriter writer, Encoding encoding)
        {
            _writer = writer;
            Encoding = encoding;
            _decoder = new AnsiSequenceDecoder(this);

            PushColors();
        }

        public override Encoding Encoding { get; }

        public override void Write(char value)
        {
            _decoder.Process(value);
        }

        void IAnsiCommandHandler.SetForegroundColor(ConsoleColor color)
        {
            PushColors(foreground: color);
        }

        void IAnsiCommandHandler.SetBackgroundColor(ConsoleColor color)
        {
            PushColors(background: color);
        }

        void IAnsiCommandHandler.SetColors(ConsoleColor foreground, ConsoleColor background)
        {
            PushColors(foreground, background);
        }

        void IAnsiCommandHandler.ResetColors()
        {
            PopColors();
        }

        void IAnsiCommandHandler.Write(char c)
        {
            WriteImpl(c, _colors?.Fg, _colors?.Bg);
        }

        protected virtual void WriteImpl(char c, ConsoleColor? fg, ConsoleColor? bg)
        {
            _buffer[0] = c;
            var chunk = new AnsiString.Chunk(_buffer, fg, bg);
            _writer.Write(chunk);
        }

        private void PushColors(ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            var colors = new AnsiColors(Console.ForegroundColor, Console.BackgroundColor);
            _colorHistory.Push(colors);

            _colors = colors.With(foreground, background);
        }

        private void PopColors()
        {
            if (_colorHistory.Count > 0)
            {
                var colors = _colorHistory.Pop();
                _colors = colors;
            }
            else
            {
                Console.ResetColor();
                _colors = null;
            }
        }
    }
}