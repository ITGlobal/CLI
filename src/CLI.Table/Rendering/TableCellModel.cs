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
        public TableCellModel([NotNull] ColoredString[] content, TableCellAlignment alignment)
        {
            Content = content;
            Alignment = alignment;
            MaxWidth = content.Length > 0 ? content.Max(_ => _.Length) : 0;
        }

        /// <summary>
        ///     Cell lines
        /// </summary>
        [NotNull]
        public ColoredString[] Content { get; }

        /// <summary>
        ///     Cell line alignment
        /// </summary>
        public TableCellAlignment Alignment { get; }

        /// <summary>
        ///     Max cell line width
        /// </summary>
        public int MaxWidth { get; }

        internal string DebuggerView =>
            $"Align = [{Alignment}], MaxWidth = {MaxWidth}, Text = {string.Join("\n", Content.Select(_ => _.Text))}";

        internal static TableCellModel Create(ColoredString text, TableCellAlignment alignment = TableCellAlignment.Left)
        {
            ColoredString[] content;
            if (text.Text.IndexOf('\n') >= 0)
            {
                var parts = text.Text.Split('\n');
                content = parts.Select(str => str.Colored(text.ForegroundColor, text.BackgroundColor)).ToArray();
            }
            else
            {
                content = new[] { text };
            }

            return new TableCellModel(content, alignment);
        }
    }
}