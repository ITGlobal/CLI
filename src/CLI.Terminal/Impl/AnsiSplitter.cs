using System;
using System.Collections.Generic;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class AnsiSplitter : IAnsiCommandHandler
    {
        private readonly struct AnsiColors
        {
            public AnsiColors(ConsoleColor? fg, ConsoleColor? bg)
            {
                Fg = fg;
                Bg = bg;
            }

            public readonly ConsoleColor? Fg;
            public readonly ConsoleColor? Bg;

            public override string ToString() => $"{Fg}/{Bg}";
        }

        private readonly AnsiSequenceDecoder _decoder;
        private readonly Stack<AnsiColors> _colorHistory = new Stack<AnsiColors>();
        private AnsiColors _colors = new AnsiColors(null, null);

        private readonly List<ColoredString> _results = new List<ColoredString>();
        private readonly StringBuilder _sb = new StringBuilder();

        private static readonly ColoredString[] Empty = new[] {(ColoredString) ""};
        private static readonly ColoredString[] LF = new[] {(ColoredString) "\n"};
        private static readonly ColoredString[] CR = new[] {(ColoredString) "\r"};

        public AnsiSplitter()
        {
            _decoder = new AnsiSequenceDecoder(this);
        }

        public IList<ColoredString> Split(ColoredString input)
        {
            switch (input.Text)
            {
                case "\n":
                    return LF;
                case "\r":
                    return CR;
                case "":
                    return Empty;
            }

            _results.Clear();
            _sb.Clear();

            var str = input.ToString();
            _decoder.Reset();
            foreach (var c in str)
            {
                _decoder.Process(c);
            }

            TryEmitResult();

            return _results;
        }

        void IAnsiCommandHandler.SetForegroundColor(ConsoleColor color)
        {
            TryEmitResult();
            PushColors(foreground: color);
        }

        void IAnsiCommandHandler.SetBackgroundColor(ConsoleColor color)
        {
            TryEmitResult();
            PushColors(background: color);
        }

        void IAnsiCommandHandler.SetColors(ConsoleColor foreground, ConsoleColor background)
        {
            TryEmitResult();
            PushColors(foreground, background);
        }

        void IAnsiCommandHandler.ResetColors()
        {
            TryEmitResult();
            PopColors();
        }

        void IAnsiCommandHandler.Write(char c)
        {
            if (c == '\n' || c == '\r')
            {
                TryEmitResult();
            }
            else
            {
                _sb.Append(c);
            }
        }

        private void TryEmitResult()
        {
            if (_sb.Length > 0)
            {
                _results.Add(_sb.ToString().Colored(_colors.Fg, _colors.Bg));

                _sb.Clear();
            }
        }


        private void PushColors(ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            _colorHistory.Push(_colors);
            _colors = new AnsiColors(foreground, background);
        }

        private void PopColors()
        {
            if (_colorHistory.Count > 0)
            {
                _colors = _colorHistory.Pop();
            }
            else
            {
                Console.ResetColor();
                _colors = default;
            }
        }
    }
}