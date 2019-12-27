using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     A builder for a row in a fluent table
    /// </summary>
    public interface IFluentTableRowBuilder
    {
        /// <summary>
        ///     Adds a cell into a row
        /// </summary>
        [NotNull]
        IFluentTableRowBuilder Add(AnsiString text, TableCellAlignment? alignment = null);
    }
}