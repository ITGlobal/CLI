using System;

namespace ITGlobal.CommandLine.Table
{
    internal class PlainTableRenderer : TableRenderer
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
        
        public override void Render<T>(ITableModel<T> model, ITerminal terminal)
        {
            using (terminal.Stdout.WithColors(DefaultForegroundColor, DefaultBackgroundColor))
            {
                PrintHeader(model, terminal);

                for (var index = 0; index < model.Rows.Count; index++)
                {
                    var row = model.Rows[index];
                    for (var i = 0; i < model.Columns.Count; i++)
                    {
                        var column = model.Columns[i];
                        var text = column.GetText(row);

                        var foregroundColor = column.GetForegroundColor(row);
                        var backgroundColor = column.GetBackgroundColor(row);

                        terminal.Stdout.Write(text.WithColors(foregroundColor, backgroundColor));

                        if (i != model.Columns.Count - 1)
                        {
                            terminal.Stdout.Write(' ');
                        }
                    }

                    terminal.Stdout.WriteLine();
                }

                terminal.Stdout.WriteLine();
            }
        }

        protected int HeaderHeight
        {
            get
            {
                var height = 0;
                if (DrawHeaders)
                {
                    height = 1;
                    if (UnderlineHeaders)
                    {
                        height++;
                    }
                }

                return height;
            }
        }

        protected void PrintHeader<T>(ITableModel<T> model, ITerminal terminal)
        {
            if (!DrawHeaders)
            {
                return;
            }

            using (terminal.Stdout.WithColors(HeaderForegroundColor, HeaderBackgroundColor))
            {
                for (var i = 0; i < model.Columns.Count; i++)
                {
                    var column = model.Columns[i];
                    var title = column.Header;
                    if (UppercaseHeaders)
                    {
                        title = title.ToUpperInvariant();
                    }

                    terminal.Stdout.Write(title);

                    if (i != model.Columns.Count - 1)
                    {
                        terminal.Stdout.Write(' ');
                    }
                }
            }
            terminal.Stdout.WriteLine();

            if (UnderlineHeaders)
            {
                using (terminal.Stdout.WithColors(HeaderUnderlineForegroundColor, HeaderUnderlineBackgroundColor))
                {
                    for (var i = 0; i < model.Columns.Count; i++)
                    {
                        var column = model.Columns[i];
                        terminal.Stdout.Write(new string('-', column.Header.Length));
                        if (i != model.Columns.Count - 1)
                        {
                            terminal.Stdout.Write(' ');
                        }
                    }
                }

                terminal.Stdout.WriteLine();
            }
        }
    }
}