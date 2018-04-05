using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Table renderer
    /// </summary>
    [PublicAPI]
    public abstract class TableRenderer
    {
        /// <summary>
        ///     Render a table
        /// </summary>
        public abstract void Render<T>([NotNull] ITableModel<T> model, [NotNull] ITerminal terminal);

        /// <summary>
        ///     Default table renderer
        /// </summary>
        [NotNull]
        public static TableRenderer Default { get; } = Plain();

        /// <summary>
        ///     Create a default table renderer
        /// </summary>
        [NotNull]
        public static TableRenderer Plain(
            bool drawHeaders = true,
            bool uppercaseHeaders = true,
            bool underlineHeaders = false,

            ConsoleColor? headerForegroundColor = null,
            ConsoleColor? headerBackgroundColor = null,

            ConsoleColor? headerUnderlineForegroundColor = null,
            ConsoleColor? headerUnderlineBackgroundColor = null,

            ConsoleColor? defaultForegroundColor = null,
            ConsoleColor? defaultBackgroundColor = null
        )
        {
            var renderer = new PlainTableRenderer
            {
                DrawHeaders = drawHeaders,
                UppercaseHeaders = uppercaseHeaders,
                UnderlineHeaders = underlineHeaders,
                HeaderForegroundColor = headerForegroundColor,
                HeaderBackgroundColor = headerBackgroundColor,
                HeaderUnderlineForegroundColor = headerUnderlineForegroundColor,
                HeaderUnderlineBackgroundColor = headerUnderlineBackgroundColor,
                DefaultForegroundColor = defaultForegroundColor,
                DefaultBackgroundColor = defaultBackgroundColor
            };

            return renderer;
        }

        /// <summary>
        ///     Create a table renderer that supports interactive paging
        /// </summary>
        [NotNull]
        public static TableRenderer Paged(
            bool drawHeaders = true,
            bool uppercaseHeaders = true,
            bool underlineHeaders = false,

            ConsoleColor? headerForegroundColor = null,
            ConsoleColor? headerBackgroundColor = null,

            ConsoleColor? headerUnderlineForegroundColor = null,
            ConsoleColor? headerUnderlineBackgroundColor = null,

            ConsoleColor? defaultForegroundColor = null,
            ConsoleColor? defaultBackgroundColor = null,

            ConsoleColor? navbarForegroundColor = ConsoleColor.Black,
            ConsoleColor? navbarBackgroundColor = ConsoleColor.Cyan
        )
        {
            var renderer = new PagedTableRenderer
            {
                DrawHeaders = drawHeaders,
                UppercaseHeaders = uppercaseHeaders,
                UnderlineHeaders = underlineHeaders,
                HeaderForegroundColor = headerForegroundColor,
                HeaderBackgroundColor = headerBackgroundColor,
                HeaderUnderlineForegroundColor = headerUnderlineForegroundColor,
                HeaderUnderlineBackgroundColor = headerUnderlineBackgroundColor,
                DefaultForegroundColor = defaultForegroundColor,
                DefaultBackgroundColor = defaultBackgroundColor,
                NavbarForegroundColor = navbarForegroundColor,
                NavbarBackgroundColor = navbarBackgroundColor
            };

            return renderer;
        }
    }
}