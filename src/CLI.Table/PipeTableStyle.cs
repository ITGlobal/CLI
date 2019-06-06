using ITGlobal.CommandLine.Table.Impl;

namespace ITGlobal.CommandLine.Table
{
    public static class PipeTableStyle
    {
        public static IPipeTableStyle Create(
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle frameColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle footerColors = null)
            => new PipeTableStyleImpl(
                bodyColors: bodyColors,
                headerColors: headerColors,
                titleColors: titleColors,
                footerColors: footerColors,
                frameColors: frameColors
            );

        public static IPipeTableStyle Default { get; set; } = Create();
    }
}