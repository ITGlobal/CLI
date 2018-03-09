using System;
using ITGlobal.CommandLine.Internals;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.ProgressBars
{
    /// <summary>
    ///     Renders terminal progress bars
    /// </summary>
    [PublicAPI]
    public abstract class ProgressBarRenderer
    {
        /// <summary>
        ///     Default progress bar style: [###   ]
        /// </summary>
        [NotNull]
        public static ProgressBarRenderer Default { get; } 
            = Create(start: '[', fill: '#', tip: '#', empty: ' ', end: ']');

        /// <summary>
        ///     Arrow progress bar style: [==>   ]
        /// </summary>
        [NotNull]
        public static ProgressBarRenderer Arrow { get; }
            = Create(start: '[', fill: '=', tip: '>', empty: ' ', end: ']');

        /// <summary>
        ///     Legacy progress bar style: [===---]
        /// </summary>
        [NotNull]
        public static ProgressBarRenderer Legacy { get; }
            = Create(start: '[', fill: '=', tip: '=', empty: '-', end: ']');

        /// <summary>
        ///     Shades progress bar style: ███▒▒▒
        /// </summary>
        [NotNull]
        public static ProgressBarRenderer Shades { get; }
            = Create(start: Consts.GLYPH_FILL, fill: Consts.GLYPH_FILL, tip: Consts.GLYPH_FILL, empty: Consts.GLYPH_EMPTY, end: Consts.GLYPH_EMPTY);

        /// <summary>
        ///     Rects progress bar style: ▪▪▪▪   ▪
        /// </summary>
        [NotNull]
        public static ProgressBarRenderer Rectangle { get; }
            = Create(start: Consts.GLYPH_RECT, fill: Consts.GLYPH_RECT, tip: Consts.GLYPH_RECT, empty: ' ', end: Consts.GLYPH_RECT);

        /// <summary>
        ///     Create a progress bar renderer
        /// </summary>
        [NotNull]
        public static ProgressBarRenderer Create(
            char? start,
            char? end,
            char fill,
            char tip,
            char empty,
            bool drawProgress = true,
            bool drawLabel = true,
            int labelWidth = Consts.PROGRESS_BAR_LABEL_WIDTH,
            ConsoleColor? labelFgColor = ConsoleColor.Yellow,
            ConsoleColor? labelBgColor = null,
            ConsoleColor? frameFgColor = null,
            ConsoleColor? frameBgColor = null,
            ConsoleColor? fillFgColor = ConsoleColor.Cyan,
            ConsoleColor? fillBgColor = null,
            ConsoleColor? fillEndFgColor = ConsoleColor.Cyan,
            ConsoleColor? fillEndBgColor = null,
            ConsoleColor? emptyFgColor = null,
            ConsoleColor? emptyBgColor = null,
            ConsoleColor? progressFgColor = ConsoleColor.Yellow,
            ConsoleColor? progressBgColor = null
        )
        {
            var renderer = new ProgressBarRendererImpl
            {
                FrameStart = start,
                FrameEnd = end,
                Fill = fill,
                FillEnd = tip,
                Empty = empty,
                EnableLabel = drawProgress,
                EnableProgress = drawLabel,
                LabelWidth = labelWidth,
                LabelFgColor = labelFgColor,
                LabelBgColor = labelBgColor,
                FrameFgColor = frameFgColor,
                FrameBgColor = frameBgColor,
                FillFgColor = fillFgColor,
                FillBgColor = fillBgColor,
                FillEndFgColor = fillEndFgColor,
                FillEndBgColor = fillEndBgColor,
                EmptyFgColor = emptyFgColor,
                EmptyBgColor = emptyBgColor,
                ProgressFgColor = progressFgColor,
                ProgressBgColor = progressBgColor
            };
            
            return renderer;
        }
        
        /// <summary>
        ///     Render a terminal progress bar
        /// </summary>
        public abstract void Render([NotNull] ITerminalOutput output, [CanBeNull] string text, int progress);
    }
}