using System.Collections.Generic;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class FluentTableRowBuilderImpl : IFluentTableRowBuilder
    {
        private readonly List<TableCellModel> _cells = new List<TableCellModel>();

        public TableCellAlignment DefaultAlignment { get; set; }

        public IFluentTableRowBuilder Add(ColoredString text, TableCellAlignment? alignment = null)
        {
            _cells.Add(TableCellModel.Create(text, alignment ?? DefaultAlignment));
            return this;
        }

        public TableRowModel Build()
        {
            var row = TableRowModel.Body(_cells.ToArray());
            _cells.Clear();
            return row;
        }
    }
}