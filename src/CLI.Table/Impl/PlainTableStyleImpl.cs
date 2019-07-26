namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class PlainTableStyleImpl : IPlainTableStyle
    {
        public PlainTableStyleImpl(
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle footerColors = null,
            bool drawHeaders = true, 
            bool uppercaseHeaders = true,
            bool underlineHeaders = false
        )
        {
            DrawHeaders = drawHeaders;
            UppercaseHeaders = uppercaseHeaders;
            UnderlineHeaders = underlineHeaders;
            BodyColors = bodyColors ?? ColoredStringStyle.White;
            HeaderColors = headerColors ?? ColoredStringStyle.Gray;
            TitleColors = titleColors ?? ColoredStringStyle.Yellow;
            FooterColors = footerColors ?? ColoredStringStyle.White;
        }

        public IColoredStringStyle BodyColors { get; }
        public IColoredStringStyle HeaderColors { get; }
        public IColoredStringStyle TitleColors { get; }
        public IColoredStringStyle FooterColors { get; }
        public bool DrawHeaders { get; }
        public bool UppercaseHeaders { get; }
        public bool UnderlineHeaders { get; }
    }
}