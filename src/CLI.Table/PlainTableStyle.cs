using ITGlobal.CommandLine.Table.Impl;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     A table style for "Plain" renderer
    /// </summary>
    public static class PlainTableStyle
    {
        /// <summary>
        ///     Creates new style with specified parameters
        /// </summary>
        public static IPlainTableStyle Create(
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle footerColors = null,
            bool drawHeaders = true,
            bool uppercaseHeaders = true,
            bool underlineHeaders = false,
            bool underlineTitle = false)
            => new PlainTableStyleImpl(bodyColors, headerColors, titleColors, footerColors, drawHeaders, uppercaseHeaders, underlineHeaders, underlineTitle);

        /// <summary>
        ///     Default style
        /// </summary>
        public static IPlainTableStyle Default { get; set; } = Create();
    }
}