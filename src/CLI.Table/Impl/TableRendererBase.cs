using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ITGlobal.CommandLine.Impl;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal abstract class TableRendererBase : ITableRenderer
    {
        public void Render(TableModel model, TextWriter output, int? maxViewWidth)
        {
            // Measure columns
            Measure(model, out var columnWidths);

            // Fit table into desired width
            var layout = Layout(model, columnWidths, maxViewWidth);

            // Render table
            var token = (Terminal.GetImplementation() as WindowsTerminalImplementation)?.DisableWrapAtEolOutput();
            using (token)
            {
                // NOTE: Will disable ENABLE_WRAP_AT_EOL_OUTPUT even when not printing to console
                // NOTE: This is for simplicity, otherwise we may miss some corner cases like printing to locked terminal
                Render(layout, output);
            }
        }

        protected abstract int CalcTotalTableWidth(int[] columnWidths);
        protected abstract int CalcSpannedColumnWidth(int[] columnWidths);
        protected abstract void Render(TableLayout model, TextWriter output);

        private static void Measure(TableModel model, out int[] columnWidths)
        {
            var columnCount = model.Rows.Max(_ => _.Cells.Count);
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

                if (row.Cells.Count == columnCount)
                {
                    for (var i = 0; i < row.Cells.Count; i++)
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

        private static void AdjustColumnWidth(int[] columnWidths, int totalTableWidth, int totalContentWidth, int maxViewWidth)
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
            var rows = new TableRowLayout[model.Rows.Count];
            for (var i = 0; i < model.Rows.Count; i++)
            {
                var row = model.Rows[i];

                rows[i] = AdjustRowLayout(row, columnWidths, totalContentWidth);
            }

            return new TableLayout(rows, totalTableWidth, columnWidths);
        }

        private TableRowLayout AdjustRowLayout(TableRowModel row, int[] columnWidths, int totalContentWidth)
        {
            var cells = new TableCellLayout[row.Cells.Count];
            for (var j = 0; j < row.Cells.Count; j++)
            {
                var cell = row.Cells[j];

                int width;
                if (row.Cells.Count >= columnWidths.Length)
                {
                    width = columnWidths[j];
                }
                else if (row.Cells.Count < columnWidths.Length)
                {
                    if (j == row.Cells.Count - 1)
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

        private static TableCellLayout AdjustCellLayout(TableCellModel cell, int width)
        {
            if (width <= 1)
            {
                width = 10;
            }

            if (cell.MaxWidth <= width)
            {
                return AdjustCellLayout(cell.Content, cell.Alignment, width);
            }

            var strs = new List<AnsiString>();
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

        private static TableCellLayout AdjustCellLayout(IReadOnlyList<AnsiString> strings, TableCellAlignment alignment, int width)
        {
            var content = new AnsiString[strings.Count];
            for (var i = 0; i < strings.Count; i++)
            {
                content[i] = AdjustCellLayout(strings[i], alignment, width);
            }

            return new TableCellLayout(content, alignment, width);
        }

        private static AnsiString AdjustCellLayout(AnsiString str, TableCellAlignment alignment, int width)
        {
            switch (alignment)
            {
                case TableCellAlignment.Left:
                    str = str.PadRight(width);
                    break;
                case TableCellAlignment.Right:
                    str = str.PadLeft(width);
                    break;
                case TableCellAlignment.Middle:
                    var totalPad = width - str.Length;
                    if (totalPad > 0)
                    {
                        var leftPad = totalPad / 2 + str.Length;

                        str = str.PadLeft(leftPad);
                        str = str.PadRight(width);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null);
            }

            return str;
        }
    }
}