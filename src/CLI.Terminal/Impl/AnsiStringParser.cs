using System;
using System.Collections.Generic;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class AnsiStringParser : IAnsiCommandHandler
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

        private readonly List<AnsiChar> _chars = new List<AnsiChar>();

        private static readonly ThreadLocal<AnsiStringParser> InstanceLocal =
            new ThreadLocal<AnsiStringParser>(() => new AnsiStringParser());

        private AnsiStringParser()
        {
            _decoder = new AnsiSequenceDecoder(this);
        }

        public static AnsiString Create(
            string str,
            ConsoleColor? defaultForegroundColor = null,
            ConsoleColor? defaultBackgroundColor = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                return AnsiString.Empty;
            }

            var instance = InstanceLocal.Value;

            instance.PushColors(defaultForegroundColor, defaultBackgroundColor);

            foreach (var c in str)
            {
                instance._decoder.Process(c);
            }

            var chars = instance._chars.ToArray();
            instance._chars.Clear();
            instance._colorHistory.Clear();
            instance._decoder.Reset();

            return new AnsiString(chars);

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
            _chars.Add(new AnsiChar(c, _colors.Fg, _colors.Bg));
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