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

        public ConsoleColor? ForegroundColor { get; }
        public ConsoleColor? BackgroundColor { get; }
    }
}