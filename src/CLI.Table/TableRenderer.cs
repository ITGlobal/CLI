using ITGlobal.CommandLine.Table.Impl;
using ITGlobal.CommandLine.Table.Rendering;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Terminal table renderer
    /// </summary>
    [PublicAPI]
    public static class TableRenderer
    {
        /// <summary>
        ///     Default renderer
        /// </summary>
        [NotNull]
        public static ITableRenderer Default { get; set; } = Grid();

        /// <summary>
        ///     Creates new "Grid" renderer
        /// </summary>
        [NotNull]
        public static ITableRenderer Grid(IGridTableStyle style = null)
        {
            return new GridTableRenderer(style ?? GridTableStyle.Default);
        }

        /// <summary>
        ///     Creates new "Pipe" renderer
        /// </summary>
        [NotNull]
        public static ITableRenderer Pipe(IPipeTableStyle style = null)
        {
            return new PipeTableRenderer(style ?? PipeTableStyle.Default);
        }

        /// <summary>
        ///     Creates new "Plain" renderer
        /// </summary>
        [NotNull]
        public static ITableRenderer Plain(IPlainTableStyle style = null)
        {
            return new PlainTableRenderer(style ?? PlainTableStyle.Default);
        }
    }
}