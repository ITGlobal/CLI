using ITGlobal.CommandLine.Table.Impl;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     A table style for "Grid" renderer
    /// </summary>
    public static class GridTableStyle
    {
        /// <summary>
        ///     Creates new "pretty" style with specified parameters
        /// </summary>
        public static IGridTableStyle Pretty(
            IColoredStringStyle frameColors = null,
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle footerColors = null)
            => new PrettyGridTableStyleImpl(frameColors, bodyColors, headerColors, titleColors, footerColors);

        /// <summary>
        ///     Creates new "sketch" style with specified parameters
        /// </summary>
        public static IGridTableStyle Sketch() => new SketchGridTableStyleImpl();

        /// <summary>
        ///     Default style
        /// </summary>
        public static IGridTableStyle Default { get; set; } = Sketch();
    }
}