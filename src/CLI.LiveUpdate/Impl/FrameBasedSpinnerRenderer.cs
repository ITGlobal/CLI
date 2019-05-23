using System.Security.Cryptography;

namespace ITGlobal.CommandLine.Impl
{
    internal abstract class FrameBasedSpinnerRenderer : ISpinnerRenderer
    {
        private readonly IColoredStringStyle _colors;
        private readonly SpinnerLocation _location;
        private readonly bool _addSpaceSeparator;

        protected FrameBasedSpinnerRenderer(IColoredStringStyle colors, SpinnerLocation location, bool addSpaceSeparator)
        {
            _colors = colors;
            _location = location;
            _addSpaceSeparator = addSpaceSeparator;
        }

        protected abstract string[] Frames { get; }

        public void Render(ITerminalLock terminal, ColoredString[] text, int time)
        {
            if (_location == SpinnerLocation.Leading)
            {
                Render(terminal, time);

                if (_addSpaceSeparator)
                {
                    terminal.Stderr.Write(' ');
                }
            }

            foreach (var s in text)
            {
                terminal.Stderr.Write(s);
            }

            if (_location == SpinnerLocation.Trailing)
            {
                if (_addSpaceSeparator)
                {
                    terminal.Stderr.Write(' ');
                }

                Render(terminal, time);
            }
        }

        private void Render(ITerminalLock terminal, int time)
        {
            var i = time % Frames.Length;
            var frame = Frames[i];
            terminal.Stderr.Write(_colors.Apply(frame));
        }
    }
}