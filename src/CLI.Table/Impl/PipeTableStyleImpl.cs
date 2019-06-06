namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class PipeTableStyleImpl : IPipeTableStyle
    {
        public PipeTableStyleImpl(
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle frameColors = null,
            IColoredStringStyle footerColors = null
        )
        {
            FrameColors = frameColors ?? ColoredStringStyle.Gray;
            BodyColors = bodyColors ?? ColoredStringStyle.White;
            HeaderColors = headerColors ?? ColoredStringStyle.White;
            TitleColors = titleColors ?? ColoredStringStyle.Yellow;
            FooterColors = footerColors ?? ColoredStringStyle.White;
        }

        public IColoredStringStyle BodyColors { get; }
        public IColoredStringStyle HeaderColors { get; }
        public IColoredStringStyle TitleColors { get; }
        public IColoredStringStyle FrameColors { get; }
        public IColoredStringStyle FooterColors { get; }
    }
}