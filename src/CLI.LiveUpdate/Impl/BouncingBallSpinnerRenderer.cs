namespace ITGlobal.CommandLine.Impl
{
    internal sealed class BouncingBallSpinnerRenderer : FrameBasedSpinnerRenderer
    {
        public BouncingBallSpinnerRenderer(IColoredStringStyle colors, SpinnerLocation location, bool addSpaceSeparator)
            : base(colors, location, addSpaceSeparator)
        { }

        protected override string[] Frames { get; } =
        {
            "(*  )",
            "( * )",
            "(  *)",
            "( * )",
        };
    }
}