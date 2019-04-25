using System;
using ITGlobal.CommandLine.Impl;

namespace ITGlobal.CommandLine
{
    internal sealed class GlyphSpinnerRenderer : SpinnerRenderer
    {
        private readonly string[] _glyphs;

        public GlyphSpinnerRenderer(params string[] glyphs)
        {
            _glyphs = glyphs;
        }

        public ConsoleColor? SpinnerForegroundColor { get; set; }
        public ConsoleColor? SpinnerBackgroundColor { get; set; }

        public ConsoleColor? TitleForegroundColor { get; set; }
        public ConsoleColor? TitleBackgroundColor { get; set; }

        public override TimeSpan AnimationStep { get; } = TimeSpan.FromMilliseconds(Consts.SPINNER_SLEEP_TIME);

        public override void Render(ITerminalWriter output, string title, int time)
        {
            var index = time % _glyphs.Length;

            output.Write(new ColoredString(_glyphs[index], SpinnerForegroundColor, SpinnerBackgroundColor));

            if (string.IsNullOrEmpty(title))
            {
                return;
            }

            output.Write(' ');
            output.Write(new ColoredString(title, SpinnerForegroundColor, SpinnerBackgroundColor));
        }
    }
}