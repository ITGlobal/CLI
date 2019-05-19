using ITGlobal.CommandLine.Table.Impl;

namespace ITGlobal.CommandLine.Table
{
    public static class PlainTableStyle
    {
        public static IPlainTableStyle Create(
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle footerColors = null,
            bool drawHeaders = true,
            bool uppercaseHeaders = true,
            bool underlineHeaders = false)
            => new PlainTableStyleImpl(bodyColors, headerColors, titleColors, footerColors, drawHeaders, uppercaseHeaders, underlineHeaders);

        public static IPlainTableStyle Default { get; set; } = Create();
    }
}