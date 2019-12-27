using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Extension methods for <see cref="IColoredStringStyle"/>
    /// </summary>
    public static class ColoredStringStyleExtensions
    {
        /// <summary>
        ///     Applies default colors to an ordinary string (with ANSI escape codes processing)
        /// </summary>
        public static AnsiString Apply([NotNull] this IColoredStringStyle style, [NotNull] string str)
            => Apply(style, AnsiString.Create(str));

        /// <summary>
        ///     Applies default colors to a single character
        /// </summary>
        public static AnsiString Apply([NotNull] this IColoredStringStyle style, char c)
            => Apply(style, new string(c, 1));
        
        /// <summary>
        ///     Applies default colors to an <see cref="AnsiString"/>
        /// </summary>
        public static AnsiString Apply([NotNull] this IColoredStringStyle style, AnsiString str)
        {
            var defaultForegroundColor = style.ForegroundColor ?? Terminal.DefaultForegroundColor;
            var defaultBackgroundColor = style.BackgroundColor ?? Terminal.DefaultBackgroundColor;
            return str.WithDefaultColors(defaultForegroundColor, defaultBackgroundColor);
        }
    }
}