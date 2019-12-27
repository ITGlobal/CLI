using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Fluent table builder
    /// </summary>
    [PublicAPI]
    public interface IFluentTableBuilder : ITableBuilderBase
    {
        /// <summary>
        ///     Set default cell alignment
        /// </summary>
        [NotNull]
        IFluentTableBuilder Align(TableCellAlignment alignment);

        /// <summary>
        ///     Add a table title
        /// </summary>
        [NotNull]
        IFluentTableBuilder Title(AnsiString text);

        /// <summary>
        ///     Add a table headers
        /// </summary>
        [NotNull]
        IFluentTableBuilder Headers([NotNull] params AnsiString[] headers);

        /// <summary>
        ///     Add a table row
        /// </summary>
        [NotNull]
        IFluentTableBuilder Add([NotNull] params AnsiString[] headers);


        /// <summary>
        ///     Add a table row using a fluent builder
        /// </summary>
        [NotNull]
        IFluentTableBuilder Add([NotNull] Action<IFluentTableRowBuilder> action);
        /// <summary>
        ///     Add a table separator
        /// </summary>
        [NotNull]
        IFluentTableBuilder Separator();

        /// <summary>
        ///     Add a table footer
        /// </summary>
        [NotNull]
        IFluentTableBuilder Footer(AnsiString text);
    }
}