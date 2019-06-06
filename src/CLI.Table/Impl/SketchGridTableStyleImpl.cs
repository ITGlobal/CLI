namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class SketchGridTableStyleImpl : IGridTableStyle
    {
        public IColoredStringStyle FrameColors { get; } = ColoredStringStyle.Null;
        public IColoredStringStyle BodyColors { get; } = ColoredStringStyle.Null;
        public IColoredStringStyle HeaderColors { get; } = ColoredStringStyle.Null;
        public IColoredStringStyle TitleColors { get; } = ColoredStringStyle.Null;
        public IColoredStringStyle FooterColors { get; } = ColoredStringStyle.Null;

        public char BoxHorizontal => '-';
        public char BoxVertical => '|';
        public char BoxDownRight => '+';
        public char BoxDownLeft => '+';
        public char BoxUpRight => '+';
        public char BoxUpLeft => '+';
        public char BoxVerticalAndLeft => '+';
        public char BoxVerticalAndRight => '+';
        public char BoxHorizontalAndUp => '+';
        public char BoxHorizontalAndDown => '+';
        public char BoxVerticalAndHorizontal => '+';
    }
}