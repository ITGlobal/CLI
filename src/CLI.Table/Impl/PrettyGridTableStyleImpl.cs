namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class PrettyGridTableStyleImpl : IGridTableStyle
    {
        public PrettyGridTableStyleImpl(
            IColoredStringStyle frameColors = null,
            IColoredStringStyle bodyColors = null,
            IColoredStringStyle headerColors = null,
            IColoredStringStyle titleColors = null,
            IColoredStringStyle footerColors = null
        )
        {
            FrameColors = frameColors ?? ColoredStringStyle.Gray;
            BodyColors = bodyColors ?? ColoredStringStyle.White;
            HeaderColors = headerColors ?? ColoredStringStyle.Yellow;
            TitleColors = titleColors ?? ColoredStringStyle.White;
            FooterColors = footerColors ?? ColoredStringStyle.White;
        }

        public IColoredStringStyle FrameColors { get; }
        public IColoredStringStyle BodyColors { get; }
        public IColoredStringStyle HeaderColors { get; }
        public IColoredStringStyle TitleColors { get; }
        public IColoredStringStyle FooterColors { get; }

        public char BoxHorizontal => '\u2500';
        public char BoxVertical => '\u2502';
        public char BoxDownRight => '\u250c';
        public char BoxDownLeft => '\u2510';
        public char BoxUpRight => '\u2514';
        public char BoxUpLeft => '\u2518';
        public char BoxVerticalAndLeft => '\u2524';
        public char BoxVerticalAndRight => '\u251c';
        public char BoxHorizontalAndUp => '\u2534';
        public char BoxHorizontalAndDown => '\u252c';
        public char BoxVerticalAndHorizontal => '\u253c';
    }
}