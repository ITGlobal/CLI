using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table.Rendering
{
    /// <summary>
    ///     Table row cell mode
    /// </summary>
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(DebuggerView) + "}")]
    public sealed class TableCellModel
    {
        /// <summary>
        ///     .ctor
        /// </summary>
        public TableCellModel([NotNull] AnsiString[] content, TableCellAlignment alignment)
        {
            Content = content;
            Alignment = alignment;
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
        public int MaxWidth => Content.Count > 0 ? Content.Max(_ => _.Length) : 0;

        internal string DebuggerView =>
            $"Align = [{Alignment}], MaxWidth = {MaxWidth}, Text = {string.Join("\n", Content.Select(_ => _.Text))}";

        internal static TableCellModel Create(AnsiString text, TableCellAlignment alignment = TableCellAlignment.Left)
        {
            AnsiString[] content;
            if (text.Chars.Any(_ => _.Char == '\n'))
            {
                content = text.Split('\n').ToArray();
            }
            else
            {
                content = new[] { text };
            }

            return new TableCellModel(content, alignment);
        }
    }
}