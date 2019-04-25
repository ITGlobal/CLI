using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class PlainTableRenderer : TableRenderer
    {
        public bool DrawHeaders { get; set; }
        public bool UppercaseHeaders { get; set; }
        public bool UnderlineHeaders { get; set; }

        public ConsoleColor? HeaderForegroundColor { get; set; }
        public ConsoleColor? HeaderBackgroundColor { get; set; }

        public ConsoleColor? HeaderUnderlineForegroundColor { get; set; }
        public ConsoleColor? HeaderUnderlineBackgroundColor { get; set; }

        public ConsoleColor? DefaultForegroundColor { get; set; }
        public ConsoleColor? DefaultBackgroundColor { get; set; }

        public override void Render<T>(ITableModel<T> model, TextWriter output)
        {
            PrintHeader(model, output);

            for (var index = 0; index < model.Rows.Count; index++)
            {
                var row = model.Rows[index];
                for (var i = 0; i < model.Columns.Count; i++)
                {
                    var column = model.Columns[i];
                    var text = column.GetText(row);

                    var foregroundColor = column.GetForegroundColor(row) ?? DefaultForegroundColor;
                    var backgroundColor = column.GetBackgroundColor(row) ?? DefaultBackgroundColor;

                    output.Write(text.Colored(foregroundColor, backgroundColor));

                    if (i != model.Columns.Count - 1)
                    {
                        output.Write(' ');
                    }
                }

                output.WriteLine();
            }

            output.WriteLine();
        }

        private void PrintHeader<T>(ITableModel<T> model, TextWriter output)
        {
            if (!DrawHeaders)
            {
                return;
            }

            {
                var sb = new StringBuilder();

                for (var i = 0; i < model.Columns.Count; i++)
                {
                    var column = model.Columns[i];
                    var title = column.Header;
                    if (UppercaseHeaders)
                    {
                        title = title.ToUpperInvariant();
                    }

                    sb.Append(title);

                    if (i != model.Columns.Count - 1)
                    {
                        sb.Append(' ');
                    }
                }

                output.WriteLine(sb.ToString().Colored(HeaderForegroundColor, HeaderBackgroundColor));
            }


            if (UnderlineHeaders)
            {
                var sb = new StringBuilder();

                for (var i = 0; i < model.Columns.Count; i++)
                {
                    var column = model.Columns[i];
                    for (var j = 0; j < column.Header.Length; j++)
                    {
                        sb.Append('-');
                    }

                    if (i != model.Columns.Count - 1)
                    {
                        sb.Append(' ');
                    }
                }

                output.WriteLine(sb.ToString().Colored(HeaderUnderlineForegroundColor, HeaderUnderlineBackgroundColor));
            }
        }
    }
}