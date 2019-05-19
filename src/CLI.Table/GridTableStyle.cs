using ITGlobal.CommandLine.Table.Impl;

namespace ITGlobal.CommandLine.Table
{
    public static class GridTableStyle
    {
        public static IGridTableStyle Pretty(
            IColoredStringStyle frameColors = null,
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle footerColors = null)
            => new PrettyGridTableStyleImpl(frameColors, bodyColors, headerColors, titleColors, footerColors);

        public static IGridTableStyle Sketch() => new SketchGridTableStyleImpl();
        public static IGridTableStyle Default { get; set; } = Sketch();
    }
}