using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table layout model
    /// </summary>
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(DebuggerView) + "}")]
    public sealed class TableLayout
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public TableLayout([NotNull] TableRowLayout[] rows, int width, int[] columnWidths)
        {
            Rows = rows;
            Width = width;
            ColumnWidths = columnWidths;
        }

        /// <summary>
        ///     Table rows
        /// </summary>
        [NotNull]
        public IReadOnlyList<TableRowLayout> Rows { get; }

        /// <summary>
        ///     Total table width
        /// </summary>
        public int Width { get; }

        /// <summary>
        ///     Colum widths
        /// </summary>
        public IReadOnlyList<int> ColumnWidths { get; }

        private string DebuggerView => $"Rows = [{Rows.Count}], Width = {Width}";
    }
}