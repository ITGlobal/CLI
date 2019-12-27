using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table model
    /// </summary>
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(DebuggerView) + "}")]
    public sealed class TableModel
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public TableModel([NotNull] TableRowModel[] rows)
        {
            Rows = rows;
        }

        /// <summary>
        ///     Table rows
        /// </summary>
        [NotNull]
        public IReadOnlyList<TableRowModel> Rows { get; }

        private string DebuggerView => $"Rows = [{Rows.Count}]";
    }
}