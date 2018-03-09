using System;
using ITGlobal.CommandLine.Internals;

namespace ITGlobal.CommandLine.Spinners
{
    internal sealed class GlyphSpinnerRenderer : SpinnerRenderer
    {
        private readonly char[] _glyphs;

        public GlyphSpinnerRenderer(params char[] glyphs)
        {
            _glyphs = glyphs;
        }

        public ConsoleColor? SpinnerForegroundColor { get; set; }
        public ConsoleColor? SpinnerBackgroundColor { get; set; }

        public ConsoleColor? TitleForegroundColor { get; set; }
        public ConsoleColor? TitleBackgroundColor { get; set; }

        public override TimeSpan AnimationStep { get; } = TimeSpan.FromMilliseconds(Consts.SPINNER_SLEEP_TIME);

        public override void Render(ITerminalOutput output, string title, int time)
        {
            var index = time % _glyphs.Length;

            using (output.WithColors(SpinnerForegroundColor, SpinnerBackgroundColor))
            {
                output.Write(_glyphs[index]);
            }

            if (string.IsNullOrEmpty(title))
            {
                return;
            }

            output.Write(' ');

            var maxLabelWidth = output.WindowWidth - 3;
            var labelWidth = Math.Min(title.Length, maxLabelWidth);

            using (output.WithColors(TitleForegroundColor, TitleBackgroundColor))
            {
                var i = 0;
                for (; i < labelWidth; i++)
                {
                    output.Write(title[i]);
                }
                for (; i < maxLabelWidth; i++)
                {
                    output.Write(' ');
                }
            }
        }
    }
}