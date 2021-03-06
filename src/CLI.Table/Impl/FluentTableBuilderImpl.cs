using System;
using System.Collections.Generic;
using System.IO;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class FluentTableBuilderImpl : IFluentTableBuilder
    {
        private readonly ITableRenderer _renderer;

        private readonly List<TableRowModel> _rows = new List<TableRowModel>();
        private readonly FluentTableRowBuilderImpl _rowBuilder = new FluentTableRowBuilderImpl();

        private TableCellAlignment _defaultAlignment = TableCellAlignment.Left;
        
        public FluentTableBuilderImpl(ITableRenderer renderer)
        {
            _renderer = renderer;
        }

        public IFluentTableBuilder Align(TableCellAlignment alignment)
        {
            _defaultAlignment = alignment;
            return this;
        }

        public IFluentTableBuilder Title(AnsiString text)
        {
            AddRow(TableRowModel.Title(text));
            return this;
        }

        public IFluentTableBuilder Headers(params AnsiString[] headers)
        {
            AddRow(TableRowModel.Header(headers));
            return this;
        }

        public IFluentTableBuilder Add(params AnsiString[] headers)
        {
            AddRow(TableRowModel.Body(headers));
            return this;
        }

        public IFluentTableBuilder Add(Action<IFluentTableRowBuilder> action)
        {
            _rowBuilder.DefaultAlignment = _defaultAlignment;
            action(_rowBuilder);
            _rows.Add(_rowBuilder.Build());
            return this;
        }

        public IFluentTableBuilder Separator()
        {
            AddRow(TableRowModel.Separator);
            return this;
        }

        public IFluentTableBuilder Footer(AnsiString text)
        {
            AddRow(TableRowModel.Footer(text));
            return this;
        }

        public void Draw(TextWriter writer, int? maxWidth = null)
        {
            var model = new TableModel(_rows.ToArray());
            _renderer.Render(model, writer, maxWidth ?? Terminal.WindowWidth);
        }
        
        private void AddRow(TableRowModel row) => _rows.Add(row);
    }
}
