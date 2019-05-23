using ITGlobal.CommandLine.Table.Impl;
using ITGlobal.CommandLine.Table.Rendering;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    [PublicAPI]
    public static class TableRenderer
    {
        public static ITableRenderer Default { get; set; } = Grid();

        public static ITableRenderer Grid(IGridTableStyle style = null)
        {
            return new GridTableRenderer(style ?? GridTableStyle.Default);
        }

        public static ITableRenderer Plain(IPlainTableStyle style = null)
        {
            return new PlainTableRenderer(style ?? PlainTableStyle.Default);
        }

        public static ITableRenderer Pipe(IPipeTableStyle style = null)
        {
            return new PipeTableRenderer(style ?? PipeTableStyle.Default);
        }
    }
}