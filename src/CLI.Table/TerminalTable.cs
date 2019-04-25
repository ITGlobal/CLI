using System;
using System.Collections.Generic;
using System.Linq;
using ITGlobal.CommandLine.Table.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Terminal table builder
    /// </summary>
    [PublicAPI]
    public static class TerminalTable
    {
        /// <summary>
        ///     Creates new table builder
        /// </summary>
        [NotNull]
        public static ITableBuilder<T> Create<T>([NotNull] T[] rows, TableRenderer renderer = null)
        {
            if (rows == null)
            {
                throw new ArgumentNullException(nameof(rows));
            }

            var builder = new TableBuilderImpl<T>(rows, renderer ?? TableRenderer.Default);
            return builder;
        }

        /// <summary>
        ///     Creates new table builder
        /// </summary>
        [NotNull]
        public static ITableBuilder<T> Create<T>([NotNull] IEnumerable<T> rows, TableRenderer renderer = null)
            => Create(rows.ToArray(), renderer);
    }
}