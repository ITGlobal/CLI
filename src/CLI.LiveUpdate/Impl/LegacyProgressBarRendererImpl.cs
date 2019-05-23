namespace ITGlobal.CommandLine.Impl
{
    internal sealed class LegacyProgressBarRendererImpl : ProgressBarRendererImpl
    {
        private readonly IColoredStringStyle _frameStyle;
        private readonly IColoredStringStyle _fillStyle;
        private readonly IColoredStringStyle _emptyStyle;

        public LegacyProgressBarRendererImpl(
            ProgressBarLocation location,
            int width,
            IColoredStringStyle frameStyle,
            IColoredStringStyle fillStyle,
            IColoredStringStyle emptyStyle)
            : base(location, width)
        {
            _frameStyle = frameStyle;
            _fillStyle = fillStyle;
            _emptyStyle = emptyStyle;
        }

        protected override void RenderFrameStart(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_frameStyle.Apply("["));
        }

        protected override void RenderFill(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_fillStyle.Apply("="));
        }

        protected override void RenderFillTip(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_fillStyle.Apply("="));
        }

        protected override void RenderEmpty(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_emptyStyle.Apply("-"));
        }

        protected override void RenderEnd(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_frameStyle.Apply("]"));
        }
    }
}