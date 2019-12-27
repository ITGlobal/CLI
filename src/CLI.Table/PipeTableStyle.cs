using ITGlobal.CommandLine.Table.Impl;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     A table style for "Pipe" renderer
    /// </summary>
    public static class PipeTableStyle
    {
        /// <summary>
        ///     Creates new style with specified parameters
        /// </summary>
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

        /// <summary>
        ///     Default style
        /// </summary>
        public static IPipeTableStyle Default { get; set; } = Create();
    }
}