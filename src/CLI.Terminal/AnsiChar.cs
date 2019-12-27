using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A colored character
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerView) + "()}")]
    public readonly struct AnsiChar : IEquatable<AnsiChar>
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public AnsiChar(char c, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            Char = c;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        /// <summary>
        ///     Character
        /// </summary>
        public readonly char Char;

        /// <summary>
        ///     Foreground color
        /// </summary>
        public readonly ConsoleColor? ForegroundColor;

        /// <summary>
        ///     Background color
        /// </summary>
        public readonly ConsoleColor? BackgroundColor;

        [Pure]
        private string DebuggerView()
        {
            var fgName = ForegroundColor != null ? ForegroundColor.Value.ToString() : "Default";
            var bgName = BackgroundColor != null ? BackgroundColor.Value.ToString() : "Default";

            var str = $"\"{Char}\" {fgName} on {bgName}";
            return str;
        }

        /// <summary>
        ///     Deconstructor
        /// </summary>
        public void Deconstruct(out char c, out ConsoleColor? foregroundColor, out ConsoleColor? backgroundColor)
        {
            c = Char;
            foregroundColor = ForegroundColor;
            backgroundColor = BackgroundColor;
        }

        /// <inheritdoc />
        public bool Equals(AnsiChar other)
            => Char == other.Char && ForegroundColor == other.ForegroundColor && BackgroundColor == other.BackgroundColor;

        /// <inheritdoc />
        public override bool Equals(object obj) 
            => obj is AnsiChar other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Char.GetHashCode();
                hashCode = (hashCode * 397) ^ ForegroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BackgroundColor.GetHashCode();
                return hashCode;
            }
        }

        /// <inheritdoc />
        public override string ToString() => Char.ToString();

        /// <summary>
        ///     Equality operator
        /// </summary>
        public static bool operator ==(AnsiChar left, AnsiChar right) => left.Equals(right);

        /// <summary>
        ///     Inequality operator
        /// </summary>
        public static bool operator !=(AnsiChar left, AnsiChar right) => !left.Equals(right);
    }
}