namespace ITGlobal.CommandLine.Impl
{
    internal sealed class BothDirectionArrowSpinnerRenderer : FrameBasedSpinnerRenderer
    {
        public BothDirectionArrowSpinnerRenderer(IColoredStringStyle colors, SpinnerLocation location, bool addSpaceSeparator)
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
            "[>>          >>]",
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