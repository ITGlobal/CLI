using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Extension methods for <see cref="IDataDrivenGeneratedTableBuilder{T}"/>
    /// </summary>
    [PublicAPI]
    public static class DataDrivenTableBuilderExtensions
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
        public static IDataDrivenGeneratedTableBuilder<T> Column<T>(
            [NotNull] this IDataDrivenGeneratedTableBuilder<T> builder,
            AnsiString title,
            [NotNull] Func<T, string> property,
            Func<T, IColoredStringStyle> style = null,
            Func<T, TableCellAlignment?> align = null,
            int? maxWidth = null
        )
        {
            return builder.Column(title, ValueProvider, style, align, maxWidth);

            AnsiString ValueProvider(T dataItem)
            {
                var s = property(dataItem);
                return s ?? string.Empty;
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
        public static IDataDrivenGeneratedTableBuilder<T> Column<T, TProperty>(
            [NotNull] this IDataDrivenGeneratedTableBuilder<T> builder,
            AnsiString title,
            [NotNull] Func<T, TProperty> property,
            Func<T, IColoredStringStyle> style = null,
            Func<T, TableCellAlignment?> align = null,
            int? maxWidth = null
        )
        {
            return builder.Column(title, ValueProvider, style, align, maxWidth);

            AnsiString ValueProvider(T dataItem)
            {
                return property(dataItem)?.ToString() ?? string.Empty;
            }
        }
    }
}