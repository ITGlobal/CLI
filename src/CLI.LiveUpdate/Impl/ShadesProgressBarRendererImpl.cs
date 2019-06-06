namespace ITGlobal.CommandLine.Impl
{
    internal sealed class ShadesProgressBarRendererImpl : ProgressBarRendererImpl
    {
        private const string GLYPH_FILL = "\u2588";
        private const string GLYPH_EMPTY = "\u2592";

        private readonly IColoredStringStyle _fillStyle;
        private readonly IColoredStringStyle _emptyStyle;

        public ShadesProgressBarRendererImpl(
            ProgressBarLocation location,
            int width,
            IColoredStringStyle fillStyle,
            IColoredStringStyle emptyStyle)
            : base(location, width)
        {
            _fillStyle = fillStyle;
            _emptyStyle = emptyStyle;
        }

        protected override void RenderFrameStart(ITerminalLock terminal) { }

        protected override void RenderFill(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_fillStyle.Apply(GLYPH_FILL));
        }

        protected override void RenderFillTip(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_fillStyle.Apply(GLYPH_FILL));
        }

        protected override void RenderEmpty(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_emptyStyle.Apply(GLYPH_EMPTY));
        }

        protected override void RenderEnd(ITerminalLock terminal) { }
    }
}