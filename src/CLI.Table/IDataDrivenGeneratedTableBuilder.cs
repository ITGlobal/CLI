using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Generated table builder
    /// </summary>
    [PublicAPI]
    public interface IDataDrivenGeneratedTableBuilder<out T> : ITableBuilderBase
    {
        /// <summary>
        ///     Set default cell alignment evaluator
        /// </summary>
        [NotNull]
        IDataDrivenGeneratedTableBuilder<T> Align([NotNull] Func<T, TableCellAlignment?> func);
        
        /// <summary>
        ///     Set default cell foreground evaluator
        /// </summary>
        [NotNull]
        IDataDrivenGeneratedTableBuilder<T> Foreground([NotNull] Func<T, ConsoleColor?> func);
        
        /// <summary>
        ///     Set default cell background evaluator
        /// </summary>
        [NotNull]
        IDataDrivenGeneratedTableBuilder<T> Background([NotNull] Func<T, ConsoleColor?> func);
        
        /// <summary>
        ///     Set default cell style evaluator
        /// </summary>
        [NotNull]
        IDataDrivenGeneratedTableBuilder<T> Style([NotNull] Func<T, IColoredStringStyle> func);

        /// <summary>
        ///     Add a table title
        /// </summary>
        [NotNull]
        IDataDrivenGeneratedTableBuilder<T> Title(AnsiString text);

        /// <summary>
        ///     Defines a table column
        /// </summary>
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
        IDataDrivenGeneratedTableBuilder<T> Column(
            AnsiString title,
            [NotNull] Func<T, AnsiString> property,
            Func<T, IColoredStringStyle> style = null,
            Func<T, TableCellAlignment?> align = null,
            int? maxWidth = null
        );
        
        /// <summary>
        ///     Add a table footer
        /// </summary>
        [NotNull]
        IDataDrivenGeneratedTableBuilder<T> Footer(AnsiString text);
    }
}