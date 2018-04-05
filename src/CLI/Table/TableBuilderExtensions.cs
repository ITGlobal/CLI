using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Extension methods for <see cref="ITableBuilder{T}"/>
    /// </summary>
    [PublicAPI]
    public static class TableBuilderExtensions
    {
        /// <summary>
        ///     Defines a table column
        /// </summary>
        /// <param name="table">
        ///     Terminal table builder
        /// </param>
        /// <param name="title">
        ///     Column header
        /// </param>
        /// <param name="property">
        ///     Value selector
        /// </param>
        /// <param name="fg">
        ///     Foreground selector
        /// </param>
        /// <param name="bg">
        ///     Background selector
        /// </param>
        /// <param name="maxWidth">
        ///     Max column width
        /// </param>
        [PublicAPI, NotNull]
        public static ITableBuilder<T> Column<T, TProperty>(
            this ITableBuilder<T> table,
            string title,
            Func<T, TProperty> property,
            Func<T, ConsoleColor?> fg = null,
            Func<T, ConsoleColor?> bg = null,
            int? maxWidth = null
        )
        {
            return table.Column(
                title,
                row => property(row)?.ToString() ?? "",
                fg,
                bg,
                maxWidth
            );
        }
    }
}