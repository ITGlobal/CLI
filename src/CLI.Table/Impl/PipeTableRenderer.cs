using System;
using System.IO;
using System.Linq;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class PipeTableRenderer : TableRendererBase
    {
        private readonly IPipeTableStyle _style;

        public PipeTableRenderer(IPipeTableStyle style)
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
            foreach (var row in model.Rows)
            {
                switch (row.Type)
                {
                    case TableRowType.Title:
                        DrawTitle(row, output);
                        break;
                    case TableRowType.Header:
                        DrawHeaders(row, output);
                        break;
                    case TableRowType.Body:
                        DrawBody(row, output);
                        break;
                    case TableRowType.Separator:
                        DrawSeparator(model, output);
                        break;
                    case TableRowType.Footer:
                        DrawFooter(row, output);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            output.WriteLine();
        }

        private void DrawTitle(TableRowLayout row, TextWriter output)
        {
            foreach (var str in row.Cells[0].Content)
            {
                var s = str;
                output.WriteLine(_style.TitleColors.Apply(s));
            }
            output.WriteLine();
        }

        private void DrawHeaders(TableRowLayout row, TextWriter output)
        {
            var space = _style.HeaderColors.Apply(" ");

            var maxRowNum = row.Cells.Max(_ => _.Content.Count);

            for (var rowNum = 0; rowNum < maxRowNum; rowNum++)
            {
                output.Write(_style.FrameColors.Apply("|"));
                for (var i = 0; i < row.Cells.Count; i++)
                {
                    DrawCell(row.Cells[i], rowNum);
                }

                output.WriteLine();
            }

            output.Write(_style.FrameColors.Apply("|"));
            for (var i = 0; i < row.Cells.Count; i++)
            {
                for (var j = 0; j < row.Cells[i].Width + 2; j++)
                {
                    output.Write(_style.FrameColors.Apply("-"));
                }
                output.Write(_style.FrameColors.Apply("|"));
            }
            output.WriteLine();

            void DrawCell(TableCellLayout cell, int rowNum)
            {
                output.Write(space);

                var n = 0;
                if (cell.Content.Count > rowNum)
                {
                    var s = cell.Content[rowNum];
                    output.Write(_style.HeaderColors.Apply(s));
                    n = s.Length;
                }

                for (var i = n; i < cell.Width; i++)
                {
                    output.Write(space);
                }

                output.Write(_style.FrameColors.Apply(" |"));
            }
        }

        private void DrawBody(TableRowLayout row, TextWriter output)
        {
            var space = _style.BodyColors.Apply(" ");
            var maxRowNum = row.Cells.Max(_ => _.Content.Count);

            for (var rowNum = 0; rowNum < maxRowNum; rowNum++)
            {
                output.Write(_style.FrameColors.Apply("|"));
                for (var i = 0; i < row.Cells.Count; i++)
                {
                    DrawCell(row.Cells[i], rowNum);
                }

                output.WriteLine();
            }

            void DrawCell(TableCellLayout cell, int rowNum)
            {
                output.Write(space);

                var n = 0;
                if (cell.Content.Count > rowNum)
                {
                    var s = cell.Content[rowNum];
                    output.Write(_style.BodyColors.Apply(s));
                    n = s.Length;
                }

                for (var i = n; i < cell.Width; i++)
                {
                    output.Write(space);
                }

                output.Write(_style.FrameColors.Apply(" |"));
            }
        }

        private void DrawSeparator(TableLayout model, TextWriter output)
        {
            var space = _style.BodyColors.Apply(" ");
            output.Write(_style.FrameColors.Apply("|"));
            for (var i = 0; i < model.ColumnWidths.Count; i++)
            {
                var width = model.ColumnWidths[i];
                for (var j = 0; j < width + 2; j++)
                {
                    output.Write(space);
                }

                output.Write(_style.FrameColors.Apply("|"));
            }

            output.WriteLine();
        }

        private void DrawFooter(TableRowLayout row, TextWriter output)
        {
            output.WriteLine();
            foreach (var str in row.Cells[0].Content)
            {
                output.WriteLine(_style.FooterColors.Apply(str));
            }
        }
    }
}