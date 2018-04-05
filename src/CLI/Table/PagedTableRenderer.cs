using System;
using ITGlobal.CommandLine.Internals;

namespace ITGlobal.CommandLine.Table
{
    internal sealed class PagedTableRenderer : PlainTableRenderer
    {
        public ConsoleColor? NavbarForegroundColor { get; set; }
        public ConsoleColor? NavbarBackgroundColor { get; set; }

        public override void Render<T>(ITableModel<T> model, ITerminal terminal)
        {
            var pageSize = terminal.Stdout.WindowHeight - 1;
            pageSize -= HeaderHeight;

            var pageCount = (int)Math.Ceiling(1f * model.Rows.Count / pageSize);
            if (pageCount <= 1 || terminal.Stdout.IsRedirected || terminal.Stdin.IsRedirected)
            {
                base.Render(model, terminal);
                return;
            }

            RenderInteractive(model, terminal, pageSize, pageCount);
        }

        private void RenderInteractive<T>(ITableModel<T> model, ITerminal terminal, int pageSize, int pageCount)
        {
            var startIndex = 0;
            var lastAllowedIndex = model.Rows.Count - pageSize - 1;

            while (true)
            {
                var action = PrintPage(model, terminal, startIndex, pageSize, pageCount);
                switch (action)
                {
                    case NavigationAction.Exit:
                        terminal.Stdout.WriteLine();
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

                terminal.Stdout.Clear();
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

        private NavigationAction PrintPage<T>(ITableModel<T> model, ITerminal terminal, int startIndex, int pageSize, int pageCount)
        {
            PrintHeader(model, terminal);

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

                    terminal.Stdout.Write(text.WithColors(foregroundColor, backgroundColor));

                    if (i != model.Columns.Count - 1)
                    {
                        terminal.Stdout.Write(' ');
                    }
                }

                terminal.Stdout.WriteLine();
            }

            for (var index = endIndex; index < pageSize; index++)
            {
                terminal.Stdout.WriteLine();
            }

            PrintFooter(terminal, startIndex, endIndex, pageSize, pageCount, model.Rows.Count);

            while (true)
            {
                var key = terminal.Stdin.ReadKey(intercept: true);
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

        private void PrintFooter(ITerminal terminal, int startIndex, int endIndex, int pageSize, int pageCount, int rowCount)
        {
            var pageNum = (int)Math.Ceiling(1f * startIndex / pageSize);
            var fieldWidth = (terminal.Stdout.WindowWidth - 2 - 3 - 3 - 2) / 3;

            using (terminal.Stdout.WithColors(NavbarForegroundColor, NavbarBackgroundColor))
            {
                terminal.Stdout.Write("| ");
                PrintField(string.Format(TerminalTable.FooterRowsText, startIndex + 1, endIndex + 1));
                terminal.Stdout.Write(" | ");
                PrintField(string.Format(TerminalTable.FooterTotalText, rowCount));
                terminal.Stdout.Write(" | ");
                PrintField(string.Format(TerminalTable.FooterPageNumberText, pageNum + 1, pageCount));
                terminal.Stdout.Write(" |");
                terminal.Stdout.MoveCursor(left: 0);
            }

            void PrintField(string text)
            {
                terminal.Stdout.Write(text);
                var length = fieldWidth - text.Length;
                for (var i = 0; i < length; i++)
                {
                    terminal.Stdout.Write(' ');
                }
            }
        }
    }
}