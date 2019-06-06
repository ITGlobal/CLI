using System;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class ColoredStringStyleImpl : IColoredStringStyle
    {
        private readonly ConsoleColor? _foregroundColor;
        private readonly ConsoleColor? _backgroundColor;

        public ColoredStringStyleImpl(ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            _foregroundColor = foregroundColor;
            _backgroundColor = backgroundColor;
        }

        public ColoredString Apply(string str) => str.Colored(_foregroundColor, _backgroundColor);

        public ColoredString Apply(char c) => Apply(new string(c, 1));

        public ColoredString Apply(ColoredString str)
            => new ColoredString(
                str.Text,
                str.ForegroundColor ?? _foregroundColor,
                str.BackgroundColor ?? _backgroundColor
            );
    }
}