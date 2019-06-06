namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RotatingBarSpinnerRenderer : FrameBasedSpinnerRenderer
    {
        public RotatingBarSpinnerRenderer(IColoredStringStyle colors, SpinnerLocation location, bool addSpaceSeparator)
            : base(colors, location, addSpaceSeparator)
        { }

        protected override string[] Frames { get; } =
        {
            @"|",
            @"/",
            @"-",
            @"\",
        };
    }
}