using System;
using System.IO;
using ITGlobal.CommandLine.Table.Impl;
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
        public abstract void Render<T>([NotNull] ITableModel<T> model, [NotNull] TextWriter output);

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
                HeaderForegroundColor = headerForegroundColor ?? ConsoleColor.White,
                HeaderBackgroundColor = headerBackgroundColor ?? ConsoleColor.Black,
                HeaderUnderlineForegroundColor = headerUnderlineForegroundColor,
                HeaderUnderlineBackgroundColor = headerUnderlineBackgroundColor,
                DefaultForegroundColor = defaultForegroundColor ?? ConsoleColor.Gray,
                DefaultBackgroundColor = defaultBackgroundColor ?? ConsoleColor.Black
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
            ConsoleColor? navbarBackgroundColor = ConsoleColor.Cyan,

            string footerRowsText = null,
            string footerTotalText = null,
            string footerPageNumberText = null
        )
        {
            var renderer = new PagedTableRenderer
            {
                FooterRowsText = footerRowsText ?? "Rows: {0}..{1}",
                FooterTotalText = footerTotalText ?? "Total {0} rows",
                FooterPageNumberText = footerPageNumberText ?? "Page {0} of {1}",
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