namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RightToLeftArrowSpinnerRenderer : FrameBasedSpinnerRenderer
    {
        public RightToLeftArrowSpinnerRenderer(IColoredStringStyle colors, SpinnerLocation location, bool addSpaceSeparator)
            : base(colors, location, addSpaceSeparator)
        { }

        protected override string[] Frames { get; } =
        {
            "[<<          <<]",
            "[         <<<< ]",
            "[       <<<<   ]",
            "[     <<<<     ]",
            "[   <<<<       ]",
            "[ <<<<         ]",
            "[<<<          <]",
        };
    }
}