using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Prints a table into console
        /// </summary>
        /// <typeparam name="T">
        ///     Row item type
        /// </typeparam>
        /// <param name="items">
        ///     Rows
        /// </param>
        /// <param name="configure">
        ///     Configuration function
        /// </param>
        [PublicAPI]
        public static void Table<T>(
            [NotNull]
            IEnumerable<T> items,
            [NotNull] Action<ITableBuilder<T>> configure)
        {
            var builder = new TableBuilder<T>();
            configure(builder);
            builder.Print(items.ToArray());
        }
    }
}
