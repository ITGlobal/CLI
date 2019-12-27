using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table row cell layout model
    /// </summary>
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(DebuggerView) + "}")]
    public sealed class TableCellLayout
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public TableCellLayout([NotNull] AnsiString[] content, TableCellAlignment alignment, int width)
        {
            Content = content;
            Alignment = alignment;
            Width = width;
        }

        /// <summary>
        ///     Cell lines
        /// </summary>
        [NotNull]
        public IReadOnlyList<AnsiString> Content { get; }

        /// <summary>
        ///     Cell line alignment
        /// </summary>
        public TableCellAlignment Alignment { get; }

        /// <summary>
        ///     Max cell line width
        /// </summary>
        public int Width { get; }

        internal string DebuggerView =>
            $"Align = [{Alignment}], Width = {Width}, Text = {string.Join("\n", Content.Select(_ => _.Text))}";
    }
}