using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Extension methods for <see cref="IGeneratedTableBuilder{T}"/>
    /// </summary>
    [PublicAPI]
    public static class GeneratedTableBuilderExtensions
    {
        /// <summary>
        ///     Defines a table column
        /// </summary>
        /// <param name="builder">
        ///     Table builder
        /// </param>
        /// <param name="title">
        ///     Column header
        /// </param>
        /// <param name="property">
        ///     Value selector
        /// </param>
        /// <param name="style">
        ///     Text style selector
        /// </param>
        /// <param name="align">
        ///     Cell alignment selector
        /// </param>
        /// <param name="maxWidth">
        ///     Max column width
        /// </param>
        [PublicAPI, NotNull]
        public static IGeneratedTableBuilder<T> Column<T>(
            [NotNull] this IGeneratedTableBuilder<T> builder,
            [NotNull] string title,
            [NotNull] Func<T, string> property,
            Func<T, IColoredStringStyle> style = null,
            Func<T, TableCellAlignment?> align = null,
            int? maxWidth = null
        )
        {
            return builder.Column(title, ValueProvider, style, align, maxWidth);

            ColoredString ValueProvider(T dataItem)
            {
                var s = property(dataItem);
                return (ColoredString)(s ?? string.Empty);
            }
        }
        /// <summary>
        ///     Defines a table column
        /// </summary>
        /// <param name="builder">
        ///     Table builder
        /// </param>
        /// <param name="title">
        ///     Column header
        /// </param>
        /// <param name="property">
        ///     Value selector
        /// </param>
        /// <param name="style">
        ///     Text style selector
        /// </param>
        /// <param name="align">
        ///     Cell alignment selector
        /// </param>
        /// <param name="maxWidth">
        ///     Max column width
        /// </param>
        [PublicAPI, NotNull]
        public static IGeneratedTableBuilder<T> Column<T, TProperty>(
            [NotNull] this IGeneratedTableBuilder<T> builder,
            [NotNull] string title,
            [NotNull] Func<T, TProperty> property,
            Func<T, IColoredStringStyle> style = null,
            Func<T, TableCellAlignment?> align = null,
            int? maxWidth = null
        )
        {
            return builder.Column(title, ValueProvider, style, align, maxWidth);

            ColoredString ValueProvider(T dataItem)
            {
                return (ColoredString)(property(dataItem)?.ToString() ?? string.Empty);
            }
        }
    }
}