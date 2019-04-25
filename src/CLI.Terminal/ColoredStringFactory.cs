using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static partial class ColoredStringFactory
    {
        [Pure]
        public static ColoredString Fg([NotNull] this string text, ConsoleColor? foregroundColor)
            => Create(text, foregroundColor, null);

        [Pure]
        public static ColoredString Bg([NotNull] this string text, ConsoleColor? backgroundColor)
            => Create(text, null, backgroundColor);

        [Pure]
        public static ColoredString Colored([NotNull] this string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
            => Create(text, foregroundColor, backgroundColor);

        [Pure]
        private static ColoredString Create([NotNull] string text, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            if (ReferenceEquals(text, null))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return new ColoredString(text, foregroundColor, backgroundColor);
        }
    }
}
