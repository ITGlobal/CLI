using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class PagedTableRenderer : TableRenderer
    {
        public string FooterRowsText { get; set; } 
        public string FooterTotalText { get; set; } 
        public string FooterPageNumberText { get; set; } 
        public ConsoleColor? NavbarForegroundColor { get; set; }
        public ConsoleColor? NavbarBackgroundColor { get; set; }
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
            var pageSize = Console.WindowHeight - 1;
            pageSize -= HeaderHeight;

            var pageCount = (int)Math.Ceiling(1f * model.Rows.Count / pageSize);
            if (pageCount <= 1 || Console.IsInputRedirected || Console.IsOutputRedirected)
            {
                new PlainTableRenderer().Render(model, output);
                return;
            }

            RenderInteractive(model, pageSize, pageCount);
        }

        private void RenderInteractive<T>(ITableModel<T> model, int pageSize, int pageCount)
        {
            var startIndex = 0;
            var lastAllowedIndex = model.Rows.Count - pageSize - 1;

            while (true)
            {
                var action = PrintPage(model,  startIndex, pageSize, pageCount);
                switch (action)
                {
                    case NavigationAction.Exit:
                        Console.WriteLine();
                        return;

                    case NavigationAction.NextLine:
                        startIndex++;
                        if (startIndex >= lastAllowedIndex)
                        {
                            startIndex = lastAllowedIndex;
                        }

                        break;
                    case NavigationAction.PrevLine:
                        startIndex--;
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }

                        break;

                    case NavigationAction.NextPage:
                        startIndex += pageSize;
                        if (startIndex >= lastAllowedIndex)
                        {
                            startIndex = lastAllowedIndex;
                        }

                        break;
                    case NavigationAction.PrevPage:
                        startIndex -= pageSize;
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }

                        break;

                    case NavigationAction.FirstPage:
                        startIndex = 0;
                        break;

                    case NavigationAction.LastPage:
                        startIndex = lastAllowedIndex;
                        break;
                }

                Console.Clear();
            }
        }

        private enum NavigationAction
        {
            Exit,
            NextPage,
            PrevPage,
            FirstPage,
            LastPage,
            NextLine,
            PrevLine
        }

        private NavigationAction PrintPage<T>(ITableModel<T> model, int startIndex, int pageSize, int pageCount)
        {
            PrintHeader(model);

            var endIndex = startIndex + pageSize;
            if (endIndex >= model.Rows.Count)
            {
                endIndex = model.Rows.Count - 1;
            }

            for (var index = startIndex; index < endIndex; index++)
            {
                var row = model.Rows[index];
                for (var i = 0; i < model.Columns.Count; i++)
                {
                    var column = model.Columns[i];
                    var text = column.GetText(row);
                    var foregroundColor = column.GetForegroundColor(row);
                    var backgroundColor = column.GetBackgroundColor(row);

                    Console.Write(text.Colored(foregroundColor, backgroundColor));

                    if (i != model.Columns.Count - 1)
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }

            for (var index = endIndex; index < pageSize; index++)
            {
                Console.WriteLine();
            }

            PrintFooter(startIndex, endIndex, pageSize, pageCount, model.Rows.Count);

            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case ConsoleKey.Clear:
                    case ConsoleKey.Escape:
                    case ConsoleKey.Q:
                        return NavigationAction.Exit;

                    case ConsoleKey.PageUp:
                        return NavigationAction.PrevPage;

                    case ConsoleKey.Spacebar:
                    case ConsoleKey.PageDown:
                    case ConsoleKey.Enter:
                        return NavigationAction.NextPage;

                    case ConsoleKey.Home:
                        return NavigationAction.FirstPage;

                    case ConsoleKey.End:
                        return NavigationAction.LastPage;

                    case ConsoleKey.UpArrow:
                        return NavigationAction.PrevLine;
                    case ConsoleKey.DownArrow:
                        return NavigationAction.NextLine;
                }
            }
        }

        private int HeaderHeight
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

        private void PrintHeader<T>(ITableModel<T> model)
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

                Console.WriteLine(sb.ToString().Colored(HeaderForegroundColor, HeaderBackgroundColor));
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

                Console.WriteLine(sb.ToString().Colored(HeaderUnderlineForegroundColor, HeaderUnderlineBackgroundColor));
            }
        }

        private void PrintFooter(int startIndex, int endIndex, int pageSize, int pageCount, int rowCount)
        {
            var pageNum = (int)Math.Ceiling(1f * startIndex / pageSize);
            var fieldWidth = (Console.WindowWidth - 2 - 3 - 3 - 2) / 3;

            var sb = new StringBuilder();

            sb.Append("| ");
            PrintField(string.Format(FooterRowsText, startIndex + 1, endIndex + 1));
            sb.Append(" | ");
            PrintField(string.Format(FooterTotalText, rowCount));
            sb.Append(" | ");
            PrintField(string.Format(FooterPageNumberText, pageNum + 1, pageCount));
            sb.Append(" |");
            
            Console.WriteLine(sb.ToString().Colored(NavbarForegroundColor, NavbarBackgroundColor));
            Console.CursorLeft = 0;

            void PrintField(string text)
            {
                sb.Append(text);
                var length = fieldWidth - text.Length;
                for (var i = 0; i < length; i++)
                {
                    sb.Append(' ');
                }
            }
        }
    }
}