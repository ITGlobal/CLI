using System;
using System.Globalization;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A colored terminal string
    /// </summary>
    [PublicAPI]
    public struct TerminalString
    {
        public TerminalString([NotNull] string value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        public string Value { get; }
        public ConsoleColor? ForegroundColor { get; }
        public ConsoleColor? BackgroundColor { get; }

        public static implicit operator TerminalString(string value) => new TerminalString(value);
        public static implicit operator string(TerminalString str) => str.Value;

        public static implicit operator TerminalString(bool value) => new TerminalString(value ? "true" : "false");
        public static implicit operator TerminalString(char value) => new TerminalString(new string(value, 1));
        public static implicit operator TerminalString(int value) => new TerminalString(value.ToString(CultureInfo.InvariantCulture));
        public static implicit operator TerminalString(long value) => new TerminalString(value.ToString(CultureInfo.InvariantCulture));
        public static implicit operator TerminalString(float value) => new TerminalString(value.ToString(CultureInfo.InvariantCulture));
        public static implicit operator TerminalString(double value) => new TerminalString(value.ToString(CultureInfo.InvariantCulture));
        public static implicit operator TerminalString(decimal value) => new TerminalString(value.ToString(CultureInfo.InvariantCulture));
    }
}