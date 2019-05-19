using System;
using System.IO;
using System.Linq;
using ITGlobal.CommandLine.Table.Rendering;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class PlainTableRenderer : TableRenderer
    {
        private readonly IPlainTableStyle _style;

        public PlainTableRenderer(IPlainTableStyle style)
        {
            _style = style;
        }
        
        protected override int CalcTotalTableWidth(int[] columnWidths)
        {
            var totalContentWidth = columnWidths.Sum();
            var totalTableWidth = totalContentWidth + columnWidths.Length;
            return totalTableWidth;
        }

        protected override int CalcSpannedColumnWidth(int[] columnWidths)
        {
            var width = columnWidths.Sum() + columnWidths.Length - 1;
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
                if (_style.UppercaseHeaders)
                {
                    s = new ColoredString(s.Text.ToUpperInvariant(), s.ForegroundColor, s.BackgroundColor);
                }

                output.WriteLine(_style.TitleColors.Apply(s));
            }
            output.WriteLine();
        }

        private void DrawHeaders(TableRowLayout row, TextWriter output)
        {
            if (!_style.DrawHeaders)
            {
                return;
            }

            var maxRowNum = row.Cells.Max(_ => _.Content.Length);

            for (var rowNum = 0; rowNum < maxRowNum; rowNum++)
            {
                for (var i = 0; i < row.Cells.Length; i++)
                {
                    DrawCell(row.Cells[i], rowNum);
                    if (i != row.Cells.Length - 1)
                    {
                        output.Write(' ');
                    }
                }

                output.WriteLine();
            }

            if (_style.UnderlineHeaders)
            {
                for (var i = 0; i < row.Cells.Length; i++)
                {
                    for (var j = 0; j < row.Cells[i].Width; j++)
                    {
                        output.Write('-');
                    }

                    if (i != row.Cells.Length - 1)
                    {
                        output.Write('-');
                    }
                }

                output.WriteLine();
            }


            void DrawCell(TableCellLayout cell, int rowNum)
            {
                var n = 0;
                if (cell.Content.Length > rowNum)
                {
                    var s = cell.Content[rowNum];
                    if (_style.UppercaseHeaders)
                    {
                        s = new ColoredString(s.Text.ToUpperInvariant(), s.ForegroundColor, s.BackgroundColor);
                    }

                    output.Write(_style.HeaderColors.Apply(s));
                    n = s.Length;
                }

                for (var i = n; i < cell.Width; i++)
                {
                    output.Write(' ');
                }
            }
        }

        private void DrawBody(TableRowLayout row, TextWriter output)
        {
            var maxRowNum = row.Cells.Max(_ => _.Content.Length);

            for (var rowNum = 0; rowNum < maxRowNum; rowNum++)
            {
                for (var i = 0; i < row.Cells.Length; i++)
                {
                    DrawCell(row.Cells[i], rowNum);
                    if (i != row.Cells.Length - 1)
                    {
                        output.Write(' ');
                    }
                }

                output.WriteLine();
            }

            void DrawCell(TableCellLayout cell, int rowNum)
            {
                var n = 0;
                if (cell.Content.Length > rowNum)
                {
                    var s = cell.Content[rowNum];
                    output.Write(_style.BodyColors.Apply(s));
                    n = s.Length;
                }

                for (var i = n; i < cell.Width; i++)
                {
                    output.Write(' ');
                }
            }
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