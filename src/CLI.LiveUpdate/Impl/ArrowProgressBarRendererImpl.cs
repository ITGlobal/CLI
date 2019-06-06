namespace ITGlobal.CommandLine.Impl
{
    internal sealed class ArrowProgressBarRendererImpl : ProgressBarRendererImpl
    {
        private readonly IColoredStringStyle _frameStyle;
        private readonly IColoredStringStyle _fillStyle;
        private readonly IColoredStringStyle _tipStyle;
        private readonly IColoredStringStyle _emptyStyle;

        public ArrowProgressBarRendererImpl(
            ProgressBarLocation location,
            int width,
            IColoredStringStyle frameStyle,
            IColoredStringStyle fillStyle,
            IColoredStringStyle tipStyle,
            IColoredStringStyle emptyStyle)
            : base(location, width)
        {
            _frameStyle = frameStyle;
            _fillStyle = fillStyle;
            _tipStyle = tipStyle;
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
            terminal.Stderr.Write(_tipStyle.Apply(">"));
        }

        protected override void RenderEmpty(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_emptyStyle.Apply(" "));
        }

        protected override void RenderEnd(ITerminalLock terminal)
        {
            terminal.Stderr.Write(_frameStyle.Apply("]"));
        }
    }
}