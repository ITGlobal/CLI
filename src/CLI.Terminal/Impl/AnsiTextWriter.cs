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

            public void Deconstruct(out ConsoleColor fg, out ConsoleColor bg)
            {
                fg = Fg;
                bg = Bg;
            }

            public override string ToString() => $"{Fg}/{Bg}";

            public AnsiColors With(ConsoleColor? fg = null, ConsoleColor? bg = null) => new AnsiColors(fg ?? Fg, bg ?? Bg);
        }

        private readonly TextWriter _writer;
        private readonly AnsiSequenceDecoder _decoder;
        private readonly Stack<AnsiColors> _colorHistory = new Stack<AnsiColors>();
        private AnsiColors? _colors;

        public AnsiTextWriter(TextWriter writer)
        {
            _writer = writer;
            _decoder = new AnsiSequenceDecoder(this);

            PushColors();
        }

        public override Encoding Encoding => _writer.Encoding;

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
            _writer.Write(c);
        }

        private void PushColors(ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            var colors = new AnsiColors(Console.ForegroundColor, Console.BackgroundColor);
            _colorHistory.Push(colors);

            if (foreground != null)
            {
                Console.ForegroundColor = foreground.Value;
            }

            if (background != null)
            {
                Console.BackgroundColor = background.Value;
            }

            _colors = colors.With(foreground, background);
        }

        private void PopColors()
        {
            if (_colorHistory.Count > 0)
            {
                var colors = _colorHistory.Pop();
                var (fg, bg) = colors;
                Console.ForegroundColor = fg;
                Console.BackgroundColor = bg;

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