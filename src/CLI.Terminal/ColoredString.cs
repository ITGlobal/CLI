using System;
using System.Globalization;
using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A colored string chunk
    /// </summary>
    [PublicAPI]
    public readonly partial struct ColoredString
    {
        public ColoredString([NotNull] string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        public readonly string Text;
        public readonly ConsoleColor? ForegroundColor;
        public readonly ConsoleColor? BackgroundColor;

        public int Length => Text.Length;

        [Pure]
        public ColoredString Substring(int startIndex) =>
            new ColoredString(Text.Substring(startIndex), ForegroundColor, BackgroundColor);

        [Pure]
        public ColoredString Substring(int startIndex, int length) =>
            new ColoredString(Text.Substring(startIndex, length), ForegroundColor, BackgroundColor);

        [Pure]
        public static explicit operator ColoredString(string value) => new ColoredString(value);
        [Pure]
        public static implicit operator string(ColoredString str) => str.ToString();

        [Pure]
        public static implicit operator ColoredString(bool value) => new ColoredString(value ? "true" : "false");

        [Pure]
        public static implicit operator ColoredString(char value) => new ColoredString(new string(value, 1));

        [Pure]
        public static implicit operator ColoredString(int value) => new ColoredString(value.ToString(CultureInfo.InvariantCulture));

        [Pure]
        public static implicit operator ColoredString(long value) => new ColoredString(value.ToString(CultureInfo.InvariantCulture));

        [Pure]
        public static implicit operator ColoredString(float value) => new ColoredString(value.ToString(CultureInfo.InvariantCulture));

        [Pure]
        public static implicit operator ColoredString(double value) => new ColoredString(value.ToString(CultureInfo.InvariantCulture));

        [Pure]
        public static implicit operator ColoredString(decimal value) => new ColoredString(value.ToString(CultureInfo.InvariantCulture));

        [Pure]
        public override string ToString()
        {
            if (ForegroundColor != null && BackgroundColor != null)
            {
                var sgr = Ansi.SGR(
                    Ansi.ForegroundColorToAttributes(ForegroundColor.Value),
                    Ansi.BackgroundColorToAttributes(BackgroundColor.Value)
                );
                return $"{sgr}{Text}{Ansi.SGR_DEFAULT}";
            }

            if (ForegroundColor != null)
            {
                var sgr = Ansi.SGR(
                    Ansi.ForegroundColorToAttributes(ForegroundColor.Value)
                );
                return $"{sgr}{Text}{Ansi.SGR_DEFAULT}";
            }

            if (BackgroundColor != null)
            {
                var sgr = Ansi.SGR(
                    Ansi.BackgroundColorToAttributes(BackgroundColor.Value)
                );
                return $"{sgr}{Text}{Ansi.SGR_DEFAULT}";
            }

            return Text;
        }
    }
}