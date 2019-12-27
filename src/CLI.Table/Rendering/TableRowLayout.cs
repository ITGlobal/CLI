using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table row layout model
    /// </summary>
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(DebuggerView) + "}")]
    public sealed class TableRowLayout
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public TableRowLayout(TableRowType type, [NotNull] TableCellLayout[] cells)
        {
            Type = type;
            Cells = cells;
        }

        /// <summary>
        ///     Row type
        /// </summary>
        public TableRowType Type { get; }

        /// <summary>
        ///     Cells
        /// </summary>
        [NotNull]
        public IReadOnlyList<TableCellLayout> Cells { get; }

        private string DebuggerView
        {
            get
            {
                switch (Type)
                {
                    case TableRowType.Title:
                    case TableRowType.Footer:
                        return $"Type = {Type}, Content = {{ {Cells[0].DebuggerView} }}";
                    case TableRowType.Separator:
                        return $"Type = {Type}";
                    default:
                        return $"Type = {Type}, Cells = [{Cells.Count}]";
                }
            }
        }
    }
}