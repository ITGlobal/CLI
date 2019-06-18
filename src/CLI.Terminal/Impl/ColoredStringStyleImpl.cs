using System;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class ColoredStringStyleImpl : IColoredStringStyle
    {
        public ColoredStringStyleImpl(ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        public ConsoleColor? ForegroundColor{ get; }
        public ConsoleColor? BackgroundColor { get; }

        public ColoredString Apply(string str) => str.Colored(ForegroundColor, BackgroundColor);

        public ColoredString Apply(char c) => Apply(new string(c, 1));

        public ColoredString Apply(ColoredString str)
            => new ColoredString(
                str.Text,
                str.ForegroundColor ?? ForegroundColor,
                str.BackgroundColor ?? BackgroundColor
            );
    }
}