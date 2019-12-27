using System;

namespace ITGlobal.CommandLine.Impl
{
    internal abstract class ProgressBarRendererImpl : IProgressBarRenderer
    {
        private readonly ProgressBarLocation _location;
        private readonly int _width;

        protected ProgressBarRendererImpl(ProgressBarLocation location, int width)
        {
            _location = location;
            _width = width;
        }

        public void Render(ITerminalLock terminal, AnsiString text, int value, int time)
        {
            if (_location == ProgressBarLocation.Leading)
            {
                RenderProgressBar(terminal, value);
                terminal.Stderr.Write(' ');
            }

            terminal.Stderr.Write(text);

            if (_location == ProgressBarLocation.Trailing)
            {
                terminal.Stderr.Write(' ');
                RenderProgressBar(terminal, value);
            }
        }

        private void RenderProgressBar(ITerminalLock terminal, int value)
        {
            RenderFrameStart(terminal);

            var fillWidth = (int)Math.Ceiling(value * _width * 1f / 100f);
            var i = 0;

            for (; i < fillWidth; i++)
            {
                if (i == fillWidth - 1)
                {
                    RenderFillTip(terminal);
                }
                else
                {
                    RenderFill(terminal);
                }
            }

            for (; i < _width; i++)
            {
                RenderEmpty(terminal);
            }

            RenderEnd(terminal);
        }

        protected abstract void RenderFrameStart(ITerminalLock terminal);
        protected abstract void RenderFill(ITerminalLock terminal);
        protected abstract void RenderFillTip(ITerminalLock terminal);
        protected abstract void RenderEmpty(ITerminalLock terminal);
        protected abstract void RenderEnd(ITerminalLock terminal);
    }
}