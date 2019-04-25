using System;
using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class TableBuilderImpl<T> : ITableBuilder<T>, ITableModel<T>
    {
        private readonly List<ITableColumnModel<T>> _columns = new List<ITableColumnModel<T>>();

        private readonly T[] _rows;
        private readonly TableRenderer _renderer;

        public TableBuilderImpl(T[] rows, TableRenderer renderer)
        {
            _rows = rows;
            _renderer = renderer;
        }

        /// <summary>
        ///     Table rows
        /// </summary>
#if NET40
        public IList<T> Rows => _rows;
#else
        public IReadOnlyList<T> Rows => _rows;
#endif


        /// <summary>
        ///     Table columns
        /// </summary>
#if NET40
        public IList<ITableColumnModel<T>> Columns => _columns;
#else
        public IReadOnlyList<ITableColumnModel<T>> Columns => _columns;
#endif
        
        /// <summary>
        ///     Defines a table column
        /// </summary>
        /// <param name="title">
        ///     Column header
        /// </param>
        /// <param name="property">
        ///     Value selector
        /// </param>
        /// <param name="fg">
        ///     Foreground selector
        /// </param>
        /// <param name="bg">
        ///     Background selector
        /// </param>
        /// <param name="maxWidth">
        ///     Max column width
        /// </param>
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

        /// <summary>
        ///     Draws table to screen
        /// </summary>
        public void Draw()
        {
            foreach (var row in Rows)
            {
                foreach (var column in _columns.Cast<TableColumn<T>>())
                {
                    column.CalculateMaxWidth(row);
                }
            }
            
            _renderer.Render(this, Console.Error);
        }
    }
}