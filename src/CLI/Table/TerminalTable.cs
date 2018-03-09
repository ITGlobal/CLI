using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Terminal table builder
    /// </summary>
    [PublicAPI]
    public static class TerminalTable
    {
        [NotNull]
        public static string FooterRowsText { get; set; } = "Rows: {0}..{1}";

        [NotNull]
        public static string FooterTotalText { get; set; } = "Total {0} rows";

        [NotNull]
        public static string FooterPageNumberText { get; set; } = "Page {0} of {1}";

        /// <summary>
        ///     Creates new table builder attached to default terminal output
        /// </summary>
        [NotNull]
        public static ITableBuilder<T> Create<T>([NotNull] T[] rows, TableRenderer renderer = null)
            => Create(Terminal.Current, rows, renderer);

        /// <summary>
        ///     Creates new table builder attached to specified terminal output
        /// </summary>
        [NotNull]
        public static ITableBuilder<T> Create<T>([NotNull] ITerminal terminal, [NotNull] T[] rows, TableRenderer renderer = null)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            if (rows == null)
            {
                throw new ArgumentNullException(nameof(rows));
            }

            var builder = new TableBuilderImpl<T>(rows, terminal, renderer ?? TableRenderer.Default);
            return builder;
        }

        /// <summary>
        ///     Creates new table builder attached to default terminal output
        /// </summary>
        [NotNull]
        public static ITableBuilder<T> Create<T>([NotNull] IEnumerable<T> rows, TableRenderer renderer = null)
            => Create(Terminal.Current, rows, renderer);

        /// <summary>
        ///     Creates new table builder attached to specified terminal output
        /// </summary>
        [NotNull]
        public static ITableBuilder<T> Create<T>([NotNull] ITerminal terminal, [NotNull] IEnumerable<T> rows, TableRenderer renderer = null)
        {
            if (rows == null)
            {
                throw new ArgumentNullException(nameof(rows));
            }

            return Create(Terminal.Current, rows.ToArray(), renderer);
        }
    }
}