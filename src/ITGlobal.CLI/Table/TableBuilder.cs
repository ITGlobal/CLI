using System;
using System.Collections.Generic;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class TableBuilder<T> : ITableBuilder<T>
    {
        private readonly List<TableColumn<T>> _columns = new List<TableColumn<T>>();
        private string _title;
        private bool _enablePaging = false;
        private bool _printTitle = true;
        private bool _printColumns = true;
        
        public ITableBuilder<T> Title(string title)
        {
            _title = title;
            return this;
        }

        public ITableBuilder<T> PrintTitle(bool enable = true)
        {
            _printTitle = enable;
            return this;
        }

        public ITableBuilder<T> PrintHeader(bool enable = true)
        {
            _printColumns = enable;
            return this;
        }

        public ITableBuilder<T> EnablePaging(bool enable = true)
        {
            _enablePaging = enable;
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
            foreach (var row in rows)
            {
                foreach (var column in _columns)
                {
                    column.CalculateMaxWidth(row);
                }
            }

            if (!string.IsNullOrEmpty(_title) && _printTitle)
            {
                using (WithForeground(ConsoleColor.Cyan))
                {
                    Console.WriteLine(_title);
                }

                using (WithForeground(ConsoleColor.DarkYellow))
                {
                    Console.WriteLine(new string('=', _title.Length));
                }
            }

            if (_printColumns)
            {
                Console.WriteLine();
                using (WithForeground(ConsoleColor.White))
                {
                    foreach (var column in _columns)
                    {

                        Console.Write(column.Title);
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
                using (WithForeground(ConsoleColor.DarkYellow))
                {
                    foreach (var column in _columns)
                    {

                        Console.Write(new string('-', column.Title.Length));
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }

            var maxRowsToDisplay = Console.WindowHeight - 5;

            for (var index = 0; index < rows.Length; index++)
            {
                var row = rows[index];
                foreach (var column in _columns)
                {
                    column.Print(row);
                    Console.Write(' ');
                }
                Console.WriteLine();

                if (_enablePaging && index > 0 && index % maxRowsToDisplay == 0)
                {
                    Console.Write(Text.TableNextPageText);
                    Console.ReadKey(true);
                    Console.CursorLeft = 0;
                    for (var i = 0; i < Text.TableNextPageText.Length; i++)
                    {
                        Console.Write(' ');
                    }
                    Console.CursorLeft = 0;
                }
            }

            Console.WriteLine();
        }
    }
}