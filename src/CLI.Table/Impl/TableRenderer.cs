using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal abstract class TableRenderer : ITableRenderer
    {
        public void Render(TableModel model, TextWriter output, int? maxViewWidth)
        {
            // Measure columns
            Measure(model, out var columnWidths);

            // Fit table into desired width
            var layout = Layout(model, columnWidths, maxViewWidth);

            // Render table
            Render(layout, output);
        }

        protected abstract int CalcTotalTableWidth(int[] columnWidths);
        protected abstract int CalcSpannedColumnWidth(int[] columnWidths);
        protected abstract void Render(TableLayout model, TextWriter output);

        private void Measure(TableModel model, out int[] columnWidths)
        {
            var columnCount = model.Rows.Max(_ => _.Cells.Length);
            columnWidths = new int[columnCount];
            foreach (var row in model.Rows)
            {
                switch (row.Type)
                {
                    case TableRowType.Body:
                    case TableRowType.Header:
                        break;
                    default:
                        continue;
                }

                if (row.Cells.Length == columnCount)
                {
                    for (var i = 0; i < row.Cells.Length; i++)
                    {
                        var cell = row.Cells[i];

                        var columnWidth = columnWidths[i];
                        columnWidth = Math.Max(cell.MaxWidth, columnWidth);
                        columnWidths[i] = columnWidth;
                    }
                }
            }
        }

        private TableLayout Layout(TableModel model, int[] columnWidths, int? maxViewWidth)
        {
            // Each column add 3 chars to width (left border and padding), plus we need 1 more char to fit right border
            var totalContentWidth = columnWidths.Sum();
            var totalTableWidth = CalcTotalTableWidth(columnWidths);

            if (maxViewWidth != null && totalTableWidth > maxViewWidth.Value)
            {
                AdjustColumnWidth(columnWidths, totalTableWidth, totalContentWidth, maxViewWidth.Value);
                totalTableWidth = maxViewWidth.Value;
                totalContentWidth = columnWidths.Sum();
            }

            var layout = AdjustLayout(model, columnWidths, totalContentWidth, totalTableWidth);

            return layout;
        }

        private void AdjustColumnWidth(int[] columnWidths, int totalTableWidth, int totalContentWidth, int maxViewWidth)
        {
            const int minColumnWidth = 8;

            var maxAllowedTotalContentWidth = maxViewWidth - (totalTableWidth - totalContentWidth);

            // If last column is too wide - shrink only last one
            if (columnWidths.Length > 1)
            {
                var lastColumnWidth = columnWidths[columnWidths.Length - 1];
                var adjustedLastColumnWidth = maxAllowedTotalContentWidth - totalContentWidth + lastColumnWidth;
                if (adjustedLastColumnWidth >= minColumnWidth)
                {
                    columnWidths[columnWidths.Length - 1] = adjustedLastColumnWidth;
                    return;
                }
            }

            // otherwise - shrink all columns proportionally
            var k = maxAllowedTotalContentWidth * 1f / totalContentWidth;
            for (var i = 0; i < columnWidths.Length; i++)
            {
                columnWidths[i] = (int)Math.Ceiling(columnWidths[i] * k);
            }
            totalContentWidth = columnWidths.Sum();

            // If there are any error due to math rounding - extend last column to fill whole view area
            var remainingWidth = maxAllowedTotalContentWidth - totalContentWidth;
            if (remainingWidth > 0)
            {
                columnWidths[columnWidths.Length - 1] += remainingWidth;
            }
        }

        private TableLayout AdjustLayout(TableModel model, int[] columnWidths, int totalContentWidth, int totalTableWidth)
        {
            var rows = new TableRowLayout[model.Rows.Length];
            for (var i = 0; i < model.Rows.Length; i++)
            {
                var row = model.Rows[i];

                rows[i] = AdjustRowLayout(row, columnWidths, totalContentWidth);
            }

            return new TableLayout(rows, totalTableWidth, columnWidths);
        }

        private TableRowLayout AdjustRowLayout(TableRowModel row, int[] columnWidths, int totalContentWidth)
        {
            var cells = new TableCellLayout[row.Cells.Length];
            for (var j = 0; j < row.Cells.Length; j++)
            {
                var cell = row.Cells[j];

                int width;
                if (row.Cells.Length >= columnWidths.Length)
                {
                    width = columnWidths[j];
                }
                else if (row.Cells.Length < columnWidths.Length)
                {
                    if (j == row.Cells.Length - 1)
                    {
                        width = CalcSpannedColumnWidth(columnWidths.Skip(j).ToArray());
                    }
                    else
                    {
                        width = columnWidths[j];
                    }
                }
                else
                {
                    width = totalContentWidth;
                }

                cells[j] = AdjustCellLayout(cell, width);
            }

            return new TableRowLayout(row.Type, cells);
        }

        private TableCellLayout AdjustCellLayout(TableCellModel cell, int width)
        {
            if (cell.MaxWidth <= width)
            {
                return AdjustCellLayout(cell.Content, cell.Alignment, width);
            }

            var strs = new List<ColoredString>();
            foreach (var str in cell.Content)
            {
                var s = str;
                while (true)
                {
                    if (s.Length <= width)
                    {
                        strs.Add(s);
                        break;
                    }

                    strs.Add(s.Substring(0, width));
                    s = s.Substring(width);
                }
            }

            return AdjustCellLayout(strs.ToArray(), cell.Alignment, width);
        }

        private TableCellLayout AdjustCellLayout(ColoredString[] strings, TableCellAlignment alignment, int width)
        {
            for (var i = 0; i < strings.Length; i++)
            {
                strings[i] = AdjustCellLayout(strings[i], alignment, width);
            }

            return new TableCellLayout(strings, alignment, width);
        }

        private ColoredString AdjustCellLayout(ColoredString str, TableCellAlignment alignment, int width)
        {
            var text = str.Text;
            switch (alignment)
            {
                case TableCellAlignment.Left:
                    text = text.PadRight(width);
                    break;
                case TableCellAlignment.Right:
                    text = text.PadLeft(width);
                    break;
                case TableCellAlignment.Middle:
                    var totalPad = width - text.Length;
                    if (totalPad > 0)
                    {
                        var leftPad = totalPad / 2;
                        var rightPad = totalPad - leftPad;

                        if (leftPad > 0)
                        {
                            text = new string(' ', leftPad) + text;
                        }

                        if (rightPad > 0)
                        {
                            text = text + new string(' ', rightPad);
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null);
            }

            return new ColoredString(text, str.ForegroundColor, str.BackgroundColor);
        }
    }
}