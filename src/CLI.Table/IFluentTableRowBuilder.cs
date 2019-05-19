using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    public interface IFluentTableRowBuilder
    {
        [NotNull]
        IFluentTableRowBuilder Add(ColoredString text, TableCellAlignment? alignment = null);
    }
}