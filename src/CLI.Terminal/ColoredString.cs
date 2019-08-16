using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A colored string chunk
    /// </summary>
    [PublicAPI]
    public readonly partial struct ColoredString : IEquatable<ColoredString>
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal static ColoredString LF { get; } = new ColoredString("\n", null, null);

        public ColoredString([NotNull] string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        [NotNull]
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

        public bool Equals(ColoredString other)
        {
            return string.Equals(Text, other.Text) && ForegroundColor == other.ForegroundColor && BackgroundColor == other.BackgroundColor;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ColoredString other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Text.GetHashCode();
                hashCode = (hashCode * 397) ^ ForegroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BackgroundColor.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ColoredString left, ColoredString right) => left.Equals(right);

        public static bool operator !=(ColoredString left, ColoredString right) => !left.Equals(right);
    }
}