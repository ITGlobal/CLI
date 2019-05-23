namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RotatingAngleSpinnerRenderer : FrameBasedSpinnerRenderer
    {
        public RotatingAngleSpinnerRenderer(IColoredStringStyle colors, SpinnerLocation location, bool addSpaceSeparator)
            : base(colors, location, addSpaceSeparator)
        { }

        protected override string[] Frames { get; } =
        {
            "\u2524",
            "\u2518",
            "\u2534",
            "\u2514",
            "\u251C",
            "\u250C",
            "\u252C",
            "\u2510",
        };
    }
}