using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table row model
    /// </summary>
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(DebuggerView) + "}")]
    public sealed class TableRowModel
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public TableRowModel(TableRowType type, [NotNull] TableCellModel[] cells)
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
        public IReadOnlyList<TableCellModel> Cells { get; }

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

        internal static TableRowModel Title(AnsiString text)
        {
            return new TableRowModel(TableRowType.Title, new[] { TableCellModel.Create(text) });
        }

        internal static TableRowModel Header(AnsiString[] headers) =>
            new TableRowModel(
                TableRowType.Header,
                headers
                    .Select(str => TableCellModel.Create(str))
                    .ToArray()
            );

        internal static TableRowModel Body(AnsiString[] headers) =>
            Body(headers.Select(str => TableCellModel.Create(str)).ToArray());

        internal static TableRowModel Body(TableCellModel[] cells) =>
            new TableRowModel(TableRowType.Body, cells);

        internal static TableRowModel Separator { get; } =
            new TableRowModel(TableRowType.Separator, new TableCellModel[0]);

        internal static TableRowModel Footer(AnsiString text)
        {
            return new TableRowModel(TableRowType.Footer, new[] { TableCellModel.Create(text) });
        }
    }
}