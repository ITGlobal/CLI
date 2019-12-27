using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A factory to create pre-colored instances of <see cref="AnsiString"/> from an ordinary string
    /// </summary>
    public static partial class AnsiStringFactory
    {
        /// <summary>
        ///     Applies default foreground color <paramref name="foregroundColor"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Fg(this AnsiString text, ConsoleColor? foregroundColor)
            => Create(text, foregroundColor, null);

        /// <summary>
        ///     Applies default background color <paramref name="backgroundColor"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Bg(this AnsiString text, ConsoleColor? backgroundColor)
            => Create(text, null, backgroundColor);

        /// <summary>
        ///     Applies default foreground color <paramref name="foregroundColor"/>
        ///     and default background color <paramref name="backgroundColor"/> to an <see cref="AnsiString"/>
        /// </summary>
        [Pure]
        public static AnsiString Colored(this AnsiString text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
            => Create(text, foregroundColor, backgroundColor);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <paramref name="foregroundColor"/>
        /// </summary>
        [Pure]
        public static AnsiString Fg([NotNull] this string text, ConsoleColor? foregroundColor)
            => Fg(AnsiString.Create(text), foregroundColor);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their background colors set to <paramref name="backgroundColor"/>
        /// </summary>
        [Pure]
        public static AnsiString Bg([NotNull] this string text, ConsoleColor? backgroundColor)
            => Bg(AnsiString.Create(text), backgroundColor);

        /// <summary>
        ///     Creates an <see cref="AnsiString"/> from a <see cref="string"/>.
        ///     All characters will have their foreground colors set to <paramref name="foregroundColor"/>
        ///     and their background colors set to <paramref name="backgroundColor"/>
        /// </summary>
        [Pure]
        public static AnsiString Colored([NotNull] this string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
            => Colored(AnsiString.Create(text), foregroundColor, backgroundColor);

        [Pure]
        private static AnsiString Create(AnsiString text, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            return text.WithDefaultColors(foregroundColor, backgroundColor);
        }
    }
}
