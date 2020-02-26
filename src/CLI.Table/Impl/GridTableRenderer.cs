using System.Collections.Generic;
using System.IO;
using System.Linq;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class GridTableRenderer : TableRendererBase
    {
        private readonly IGridTableStyle _style;

        public GridTableRenderer(IGridTableStyle style)
        {
            _style = style;
        }
        
        protected override int CalcTotalTableWidth(int[] columnWidths)
        {
            var totalContentWidth = columnWidths.Sum();
            var totalTableWidth = totalContentWidth + columnWidths.Length * 3 + 1;
            return totalTableWidth;
        }

        protected override int CalcSpannedColumnWidth(int[] columnWidths)
        {
            var width = columnWidths.Sum() + (columnWidths.Length - 1) * 3;
            return width;
        }

        protected override void Render(TableLayout model, TextWriter output)
        {
            var lastRow = LastRowType.None;
            for (var i = 0; i < model.Rows.Count; i++)
            {
                var row = model.Rows[i];
                var isFirstRow = i == 0;
                var isLastRow = i == model.Rows.Count - 1;

                switch (row.Type)
                {
                    case TableRowType.Title:
                        switch (lastRow)
                        {
                            case LastRowType.None:
                            case LastRowType.Footer:
                                DrawSingleCellSeparator(output, model, isFirstRow, isLastRow);
                                break;
                            case LastRowType.Header:
                            case LastRowType.Body:
                                DrawMultiCellSeparator(
                                    output: output,
                                    model: model,
                                    isFirstRow: isFirstRow,
                                    isLastRow: false,
                                    prevRowIsMultiCell: !isFirstRow && model.Rows[i - 1].Cells.Count == model.ColumnWidths.Count,
                                    nextRowIsMultiCell: !isLastRow && model.Rows[i + 1].Cells.Count == model.ColumnWidths.Count
                                );
                                break;
                        }

                        DrawSingleCell(output, model, row.Cells[0], _style.TitleColors);
                        lastRow = LastRowType.Title;
                        break;

                    case TableRowType.Header:
                        if (lastRow != LastRowType.Header)
                        {
                            DrawMultiCellSeparator(
                                output: output,
                                model: model,
                                isFirstRow: isFirstRow,
                                isLastRow: false,
                                prevRowIsMultiCell: !isFirstRow && model.Rows[i - 1].Cells.Count == model.ColumnWidths.Count,
                                nextRowIsMultiCell: !isLastRow && model.Rows[i + 1].Cells.Count == model.ColumnWidths.Count
                            );
                        }

                        DrawMultiCell(output, row.Cells, _style.HeaderColors);
                        lastRow = LastRowType.Header;
                        break;
                    case TableRowType.Body:
                        if (lastRow != LastRowType.Body)
                        {
                            DrawMultiCellSeparator(
                                output: output,
                                model: model,
                                isFirstRow: isFirstRow,
                                isLastRow: false,
                                prevRowIsMultiCell: !isFirstRow && model.Rows[i - 1].Cells.Count == model.ColumnWidths.Count,
                                nextRowIsMultiCell: !isLastRow && model.Rows[i + 1].Cells.Count == model.ColumnWidths.Count
                            );
                        }

                        DrawMultiCell(output, row.Cells, _style.BodyColors);
                        lastRow = LastRowType.Body;
                        break;
                    case TableRowType.Separator:
                        switch (lastRow)
                        {
                            case LastRowType.None:
                            case LastRowType.Title:
                            case LastRowType.Footer:
                                DrawSingleCellSeparator(output, model, isFirstRow, isLastRow);
                                break;
                            default:
                                DrawMultiCellSeparator(
                                    output: output,
                                    model: model,
                                    isFirstRow: isFirstRow,
                                    isLastRow: false,
                                    prevRowIsMultiCell: !isFirstRow && model.Rows[i - 1].Cells.Count == model.ColumnWidths.Count,
                                    nextRowIsMultiCell: !isLastRow && model.Rows[i + 1].Cells.Count == model.ColumnWidths.Count
                                );
                                break;
                        }

                        break;

                    case TableRowType.Footer:
                        switch (lastRow)
                        {
                            case LastRowType.None:
                            case LastRowType.Title:
                                DrawSingleCellSeparator(output, model, isFirstRow, isLastRow);
                                break;
                            case LastRowType.Header:
                            case LastRowType.Body:
                                DrawMultiCellSeparator(
                                    output: output,
                                    model: model,
                                    isFirstRow: isFirstRow,
                                    isLastRow: false,
                                    prevRowIsMultiCell: !isFirstRow && model.Rows[i - 1].Cells.Count == model.ColumnWidths.Count,
                                    nextRowIsMultiCell: !isLastRow && model.Rows[i + 1].Cells.Count == model.ColumnWidths.Count
                                );
                                break;
                        }

                        DrawSingleCell(output, model, row.Cells[0], _style.FooterColors);
                        lastRow = LastRowType.Footer;
                        break;
                }
            }

            switch (lastRow)
            {
                case LastRowType.None:
                case LastRowType.Title:
                case LastRowType.Footer:
                    DrawSingleCellSeparator(output, model, false, true);
                    break;
                default:
                    DrawMultiCellSeparator(
                        output: output,
                        model: model,
                        isFirstRow: false,
                        isLastRow: true,
                        prevRowIsMultiCell: model.Rows[model.Rows.Count - 1].Cells.Count == model.ColumnWidths.Count,
                        nextRowIsMultiCell: false
                    );
                    break;
            }
        }

        private enum LastRowType
        {
            None,
            Title,
            Footer,
            Header,
            Body
        }

        private void DrawSingleCellSeparator(TextWriter output, TableLayout model, bool isFirstRow, bool isLastRow)
        {
            output.Write(
                _style.FrameColors.Apply(
                    isFirstRow ? _style.BoxDownRight : isLastRow ? _style.BoxUpRight : _style.BoxVerticalAndRight
                )
            );
            for (var i = 0; i < model.Width - 2; i++)
            {
                output.Write(_style.FrameColors.Apply(_style.BoxHorizontal));
            }

            output.Write(
                _style.FrameColors.Apply(
                    isFirstRow ? _style.BoxDownLeft : isLastRow ? _style.BoxUpLeft : _style.BoxVerticalAndLeft
                )
            );
            output.WriteLine();
        }

        private void DrawMultiCellSeparator(
            TextWriter output,
            TableLayout model,
            bool isFirstRow,
            bool isLastRow,
            bool prevRowIsMultiCell,
            bool nextRowIsMultiCell
            )
        {
            for (var column = 0; column < model.ColumnWidths.Count; column++)
            {
                if (column == 0)
                {
                    output.Write(
                        _style.FrameColors.Apply(
                            isFirstRow ? ( _style.BoxDownRight) : (isLastRow ? _style.BoxUpRight : _style.BoxVerticalAndRight)
                        )
                    );
                }
                else
                {
                    if (prevRowIsMultiCell && nextRowIsMultiCell)
                    {
                        output.Write(_style.FrameColors.Apply(_style.BoxVerticalAndHorizontal));
                    }
                    else if (prevRowIsMultiCell)
                    {
                        output.Write(_style.FrameColors.Apply(_style.BoxHorizontalAndUp));
                    }
                    else if (nextRowIsMultiCell)
                    {
                        output.Write(_style.FrameColors.Apply(_style.BoxHorizontalAndDown));
                    }
                    else
                    {
                        output.Write(_style.FrameColors.Apply(_style.BoxHorizontal));
                    }
                }

                output.Write(_style.FrameColors.Apply(_style.BoxHorizontal));
                var width = model.ColumnWidths[column];
                for (var i = 0; i < width; i++)
                {
                    output.Write(_style.FrameColors.Apply(_style.BoxHorizontal));
                }
                output.Write(_style.FrameColors.Apply(_style.BoxHorizontal));
            }

            output.Write(
                _style.FrameColors.Apply(
                    isFirstRow ? (_style.BoxDownLeft) : (isLastRow ? _style.BoxUpLeft : _style.BoxVerticalAndLeft)
                )
            );
            output.WriteLine();
        }

        private void DrawSingleCell(TextWriter output, TableLayout model, TableCellLayout cell, IColoredStringStyle colors)
        {
            var space = _style.FrameColors.Apply(" ");

            foreach (var text in cell.Content)
            {
                output.Write(_style.FrameColors.Apply(_style.BoxVertical));
                output.Write(space);
                output.Write(colors.Apply(text));
                for (var i = text.Length; i < model.Width - 4; i++)
                {
                    output.Write(space);
                }
                output.Write(space);
                output.Write(_style.FrameColors.Apply(_style.BoxVertical));
                output.WriteLine();
            }
        }

        private void DrawMultiCell(TextWriter output, IReadOnlyList<TableCellLayout> cells, IColoredStringStyle colors)
        {
            var space = colors.Apply(" ");
            var lines = cells.Max(_ => _.Content.Count);

            for (var line = 0; line < lines; line++)
            {
                for (var column = 0; column < cells.Count; column++)
                {
                    var cell = cells[column];
                    output.Write(_style.FrameColors.Apply(_style.BoxVertical));
                    output.Write(space);
                    var cellWidth = 0;
                    if (line < cell.Content.Count)
                    {
                        var colored = colors.Apply(cell.Content[line]);
                        output.Write(colored);
                        cellWidth = cell.Content[line].Length;
                    }

                    var maxCellWidth = cell.Width;

                    for (var i = cellWidth; i < maxCellWidth; i++)
                    {
                        output.Write(space);
                    }

                    output.Write(space);
                }
                output.Write(_style.FrameColors.Apply(_style.BoxVertical));
                output.WriteLine();
            }
        }
    }
}