namespace ITGlobal.CommandLine.Impl
{
    internal sealed class LeftToRightArrowSpinnerRenderer : FrameBasedSpinnerRenderer
    {
        public LeftToRightArrowSpinnerRenderer(IColoredStringStyle colors, SpinnerLocation location, bool addSpaceSeparator)
            : base(colors, location, addSpaceSeparator)
        { }

        protected override string[] Frames { get; } =
        {
            "[>>>          >]",
            "[ >>>>         ]",
            "[   >>>>       ]",
            "[     >>>>     ]",
            "[       >>>>   ]",
            "[         >>>> ]",
            "[>>          >>]"
        };
    }
}