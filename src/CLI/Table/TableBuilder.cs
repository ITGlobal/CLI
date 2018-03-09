using System;
using System.Collections.Generic;
using System.Text;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class TableBuilder<T> : ITableBuilder<T>
    {
        private readonly List<TableColumn<T>> _columns = new List<TableColumn<T>>();
        private string _title;
        private bool _enablePaging = false;
        private TableStyle _style = TableStyle.Default;

        public ITableBuilder<T> Title(string title)
        {
            _title = title;
            return this;
        }

        public ITableBuilder<T> PrintTitle(bool enable = true)
        {
            if (enable)
            {
                _style |= TableStyle.HasTitle;
            }
            else
            {
                _style &= ~TableStyle.HasTitle;
            }

            return this;
        }

        public ITableBuilder<T> PrintHeader(bool enable = true)
        {
            if (enable)
            {
                _style |= TableStyle.HasHeaders;
            }
            else
            {
                _style &= ~TableStyle.HasHeaders;
            }

            return this;
        }

        public ITableBuilder<T> EnablePaging(bool enable = true)
        {
            _enablePaging = enable;
            return this;
        }

        public ITableBuilder<T> UseStyle(TableStyle style)
        {
            _style = style;
            return this;
        }

        public ITableBuilder<T> Column(
            string title,
            Func<T, string> property,
            Func<T, ConsoleColor?> fg = null,
            Func<T, ConsoleColor?> bg = null,
            int? maxWidth = null)
        {
            _columns.Add(new TableColumn<T>(title, property, fg ?? (_ => null), bg ?? (_ => null), maxWidth));
            return this;
        }

        public void Print(T[] rows)
        {
            using (CLI.WithOutputEncoding(Encoding.UTF8))
            {
                foreach (var row in rows)
                {
                    foreach (var column in _columns)
                    {
                        column.CalculateMaxWidth(row);
                    }
                }

                if (string.IsNullOrEmpty(_title))
                {
                    _style &= ~TableStyle.HasTitle;
                }

#if NET40
            if (!_enablePaging)
#else
                if (!_enablePaging || Console.IsOutputRedirected)
#endif
                {
                    PrintNonInteractive(rows);
                    return;
                }

                PrintInteractive(rows);
            }
        }

        private void PrintNonInteractive(T[] rows)
        {
            PrintTitle();
            PrintHeader();

            for (var index = 0; index < rows.Length; index++)
            {
                var row = rows[index];
                for (var i = 0; i < _columns.Count; i++)
                {
                    _columns[i].Print(row);
                    if (i != _columns.Count - 1)
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void PrintInteractive(T[] rows)
        {
            var pageSize = Console.WindowHeight - 1;
            pageSize -= TitleHeight;
            pageSize -= HeaderHeight;

            var pageCount = (int) Math.Ceiling(1f * rows.Length / pageSize);
            if (pageCount <= 1)
            {
                PrintNonInteractive(rows);
                return;
            }

            var startIndex = 0;
            var lastAllowedIndex = rows.Length - pageSize - 1;

            while (true)
            {
                var action = PrintPage(rows, startIndex, pageSize, pageCount);
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

        private int TitleHeight
        {
            get
            {
                var height = 0;
                if (_style.HasFlag(TableStyle.HasTitle))
                {
                    height = 2;
                    if (_style.HasFlag(TableStyle.UnderlinedTitle))
                    {
                        height++;
                    }
                }

                return height;
            }
        }

        private void PrintTitle()
        {
            if (!_style.HasFlag(TableStyle.HasTitle))
            {
                return;
            }
            
            using (WithForeground(ConsoleColor.Cyan))
            {
                var title = _title;
                if (_style.HasFlag(TableStyle.UppercaseTitle))
                {
                    title = title.ToUpperInvariant();
                }
                Console.WriteLine(title);
            }

            if (_style.HasFlag(TableStyle.UnderlinedTitle))
            {
                using (WithForeground(ConsoleColor.DarkYellow))
                {
                    Console.WriteLine(new string('=', _title.Length));
                }
            }

            Console.WriteLine();
        }

        private int HeaderHeight
        {
            get
            {
                var height = 0;
                if (_style.HasFlag(TableStyle.HasHeaders))
                {
                    height = 1;
                    if (_style.HasFlag(TableStyle.UnderlinedHeaders))
                    {
                        height++;
                    }
                }

                return height;
            }
        }

        private void PrintHeader()
        {
            if (!_style.HasFlag(TableStyle.HasHeaders))
            {
                return;
            }
            
            using (WithForeground(ConsoleColor.White))
            {
                foreach (var column in _columns)
                {
                    var title = column.Title;
                    if (_style.HasFlag(TableStyle.UppercaseHeaders))
                    {
                        title = title.ToUpperInvariant();
                    }

                    Console.Write(title);
                    Console.Write(' ');
                }
            }
            Console.WriteLine();

            if (_style.HasFlag(TableStyle.UnderlinedHeaders))
            {
                using (WithForeground(ConsoleColor.DarkYellow))
                {
                    for (var i = 0; i < _columns.Count; i++)
                    {
                        var column = _columns[i];
                        Console.Write(new string('-', column.Title.Length));
                        if (i != _columns.Count - 1)
                        {
                            Console.Write(' ');
                        }
                    }
                }

                Console.WriteLine();
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

        private NavigationAction PrintPage(T[] rows, int startIndex, int pageSize, int pageCount)
        {
            PrintTitle();
            PrintHeader();

            var endIndex = startIndex + pageSize;
            if (endIndex >= rows.Length)
            {
                endIndex = rows.Length - 1;
            }

            for (var index = startIndex; index < endIndex; index++)
            {
                var row = rows[index];
                for (var i = 0; i < _columns.Count; i++)
                {
                    _columns[i].Print(row);
                    if (i != _columns.Count - 1)
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

            PrintFooter(startIndex, endIndex, pageSize, pageCount, rows.Length);

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

        private void PrintFooter(int startIndex, int endIndex, int pageSize, int pageCount, int rowCount)
        {
            var pageNum = (int)Math.Ceiling(1f * startIndex / pageSize);
            var fieldWidth = (Console.WindowWidth - 2 - 3 - 3 - 2) / 3;

            using (WithColors(ConsoleColor.Black, ConsoleColor.Gray))
            {
                Console.Write("| ");
                PrintField($"Rows: {startIndex + 1}..{endIndex + 1}", fieldWidth);
                Console.Write(" | ");
                PrintField($"Total {rowCount} rows", fieldWidth);
                Console.Write(" | ");
                PrintField($"Page {pageNum + 1} of {pageCount}", fieldWidth);
                Console.Write(" |");
                Console.CursorLeft = 0;
            }

            void PrintField(string text, int width)
            {
                Console.Write(text);
                var length = width - text.Length;
                for (var i = 0; i < length; i++)
                {
                    Console.Write(' ');
                }
            }
        }
    }
}