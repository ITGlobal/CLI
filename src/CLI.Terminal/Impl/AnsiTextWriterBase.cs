using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal abstract class AnsiTextWriterBase : TextWriter, IAnsiCommandHandler
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

        private readonly AnsiSequenceDecoder _decoder;
        private readonly object _syncRoot = new object();
        private readonly Stack<AnsiColors> _colorHistory = new Stack<AnsiColors>();
        private AnsiColors? _colors;

        protected AnsiTextWriterBase(Encoding encoding)
        {
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
            ConsoleColor? fg;
            ConsoleColor? bg;

            lock (_syncRoot)
            {
                fg = _colors?.Fg;
                bg = _colors?.Bg; ;
            }

            WriteImpl(c, fg, bg);
        }

        protected abstract void WriteImpl(char c, ConsoleColor? fg, ConsoleColor? bg);

        private void PushColors(ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            var colors = new AnsiColors(Console.ForegroundColor, Console.BackgroundColor);

            lock (_syncRoot)
            {
                _colorHistory.Push(colors);
                _colors = colors.With(foreground, background);
            }
        }

        private void PopColors()
        {
            lock (_syncRoot)
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
}