using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class DataDrivenGeneratedTableBuilderImpl<T> : IDataDrivenGeneratedTableBuilder<T>
    {
        private sealed class ColumnGenerator
        {
            private readonly Func<T, ColoredString> _property;
            private readonly Func<T, IColoredStringStyle> _style;
            private readonly Func<T, TableCellAlignment?> _align;
            private readonly int? _maxWidth;

            public ColumnGenerator(
                string title,
                Func<T, ColoredString> property,
                Func<T, IColoredStringStyle> style,
                Func<T, TableCellAlignment?> align,
                int? maxWidth)
            {
                Title = title;
                _property = property;
                _style = style;
                _align = align;
                _maxWidth = maxWidth;
            }

            public string Title { get; }

            public TableCellModel Generate(
                T dataItem,
                Func<T, IColoredStringStyle> defaultStyleSelector,
                Func<T, TableCellAlignment?> defaultAlignmentSelector)
            {
                var text = _property(dataItem);

                var style = _style(dataItem) ?? defaultStyleSelector(dataItem) ?? ColoredStringStyle.Null;
                text = style.Apply(text);

                var alignment = _align(dataItem) ?? defaultAlignmentSelector(dataItem) ?? TableCellAlignment.Left;

                return new TableCellModel(new[] { text }, alignment);
            }
        }

        private readonly ITableRenderer _renderer;
        private readonly IEnumerable<T> _dataItems;

        private readonly List<ColumnGenerator> _columns = new List<ColumnGenerator>();

        private Func<T, TableCellAlignment?> _defaultAlignment = _ => null;
        private Func<T, IColoredStringStyle> _defaultStyle = _ => ColoredStringStyle.Null;

        private ColoredString? _title;
        private ColoredString? _footer;

        public DataDrivenGeneratedTableBuilderImpl(IEnumerable<T> dataItems, ITableRenderer renderer)
        {
            _dataItems = dataItems;
            _renderer = renderer;
        }

        public IDataDrivenGeneratedTableBuilder<T> Align(Func<T, TableCellAlignment?> func)
        {
            _defaultAlignment = func;
            return this;
        }

        public IDataDrivenGeneratedTableBuilder<T> Foreground(Func<T, ConsoleColor?> func)
        {
            var oldDefaultStyle = _defaultStyle;
            _defaultStyle = x => oldDefaultStyle(x).Update(foregroundColor: func(x));
            return this;
        }

        public IDataDrivenGeneratedTableBuilder<T> Background(Func<T, ConsoleColor?> func)
        {
            var oldDefaultStyle = _defaultStyle;
            _defaultStyle = x => oldDefaultStyle(x).Update(backgroundColor: func(x));
            return this;
        }

        public IDataDrivenGeneratedTableBuilder<T> Style(Func<T, IColoredStringStyle> func)
        {
            _defaultStyle = func;
            return this;
        }

        public IDataDrivenGeneratedTableBuilder<T> Title(ColoredString text)
        {
            _title = text;
            return this;
        }

        public IDataDrivenGeneratedTableBuilder<T> Column(
            string title,
            Func<T, ColoredString> property,
            Func<T, IColoredStringStyle> style = null,
            Func<T, TableCellAlignment?> align = null,
            int? maxWidth = null)
        {
            _columns.Add(new ColumnGenerator(title, property, style ?? _defaultStyle, align ?? _defaultAlignment, maxWidth));
            return this;
        }

        public IDataDrivenGeneratedTableBuilder<T> Footer(ColoredString text)
        {
            _footer = text;
            return this;
        }

        public void Draw(TextWriter writer, int? maxWidth = null)
        {
            var rows = new List<TableRowModel>();
            if (_title != null)
            {
                rows.Add(TableRowModel.Title(_title.Value));
            }

            rows.Add(TableRowModel.Header(_columns.Select(c => c.Title.Colored()).ToArray()));


            foreach (var dataItem in _dataItems)
            {
                var cells = new TableCellModel[_columns.Count];
                for (var i = 0; i < _columns.Count; i++)
                {
                    var column = _columns[i];
                    cells[i] = column.Generate(dataItem, _defaultStyle, _defaultAlignment);
                }

                rows.Add(TableRowModel.Body(cells));
            }

            if (_footer != null)
            {
                rows.Add(TableRowModel.Footer(_footer.Value));
            }

            var model = new TableModel(rows.ToArray());
            _renderer.Render(model, writer, maxWidth ?? Terminal.WindowWidth);
        }
    }
}