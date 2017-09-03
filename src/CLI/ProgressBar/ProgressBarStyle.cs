using System;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Progress bar style
    /// </summary>
    public abstract class ProgressBarStyle
    {
        /// <summary>
        ///     Label width
        /// </summary>
        public virtual int LabelWidth { get; } = CLI.PROGRESS_BAR_LABEL_WIDTH;

        public virtual ConsoleColor? LabelFgColor { get; } = ConsoleColor.Yellow;
        public virtual ConsoleColor? LabelBgColor { get; }

        public virtual ConsoleColor? FrameFgColor { get; }
        public virtual ConsoleColor? FrameBgColor { get; }

        public virtual ConsoleColor? FillFgColor { get; } = ConsoleColor.Cyan;
        public virtual ConsoleColor? FillBgColor { get; }

        public virtual ConsoleColor? FillEndFgColor { get; } = ConsoleColor.Cyan;
        public virtual ConsoleColor? FillEndBgColor { get; }

        public virtual ConsoleColor? EmptyFgColor { get; }
        public virtual ConsoleColor? EmptyBgColor { get; }

        public virtual ConsoleColor? ProgressFgColor { get; } = ConsoleColor.Yellow;
        public virtual ConsoleColor? ProgressBgColor { get; }

        public abstract char? FrameStart { get; }
        public abstract char Fill { get; }
        public abstract char FillEnd { get; }
        public abstract char Empty { get; }
        public abstract char? FrameEnd { get; }

        public virtual bool EnableLabel => true;
        public virtual bool EnableProgress => true;

        /// <summary>
        ///     Default progress bar style: [###   ]
        /// </summary>
        public static ProgressBarStyle Default { get; } = new DefaultStyle();

        /// <summary>
        ///     Arrow progress bar style: [==>   ]
        /// </summary>
        public static ProgressBarStyle Arrow { get; } = new ArrowStyle();

        /// <summary>
        ///     Legacy progress bar style: [===---]
        /// </summary>
        public static ProgressBarStyle Legacy { get; } = new LegacyStyle();

        /// <summary>
        ///     Shades progress bar style: ███▒▒▒
        /// </summary>
        public static ProgressBarStyle Shades { get; } = new ShadesStyle();

        /// <summary>
        ///     Rects progress bar style: ▪▪▪▪   ▪
        /// </summary>
        public static ProgressBarStyle Rect { get; } = new RectStyle();

        private sealed class DefaultStyle : ProgressBarStyle
        {
            public override char? FrameStart => '[';
            public override char Fill => '#';
            public override char FillEnd => '#';
            public override char Empty => ' ';
            public override char? FrameEnd => ']';
        }
        
        private sealed class ArrowStyle : ProgressBarStyle
        {
            public override ConsoleColor? FrameFgColor => ConsoleColor.Cyan;
            public override ConsoleColor? FillFgColor => ConsoleColor.DarkCyan;

            public override char? FrameStart => '[';
            public override char Fill => '=';
            public override char FillEnd => '>';
            public override char Empty => ' ';
            public override char? FrameEnd => ']';
        }

        private sealed class LegacyStyle : ProgressBarStyle
        {
            public override char? FrameStart => '[';
            public override char Fill => '=';
            public override char FillEnd => '=';
            public override char Empty => '-';
            public override char? FrameEnd => ']';
        }

        private sealed class ShadesStyle : ProgressBarStyle
        {
            const char GLYPH_FILL = '\u2588';
            const char GLYPH_EMPTY= '\u2592';

            public override ConsoleColor? FillFgColor => null;

            public override char? FrameStart => null;
            public override char Fill => GLYPH_FILL;
            public override char FillEnd => GLYPH_FILL;
            public override char Empty => GLYPH_EMPTY;
            public override char? FrameEnd => null;
        }

        private sealed class RectStyle : ProgressBarStyle
        {
            const char GLYPH_RECT = '\u25AA';

            public override ConsoleColor? FillFgColor => null;

            public override char? FrameStart => GLYPH_RECT;
            public override char Fill => GLYPH_RECT;
            public override char FillEnd => GLYPH_RECT;
            public override char Empty => ' ';
            public override char? FrameEnd => GLYPH_RECT;
        }
    }
}
