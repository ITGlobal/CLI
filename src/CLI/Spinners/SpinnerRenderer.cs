using System;
using ITGlobal.CommandLine.Internals;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Spinners
{
    /// <summary>
    ///     Renders terminal spinners
    /// </summary>
    [PublicAPI]
    public abstract class SpinnerRenderer
    {
        /// <summary>
        ///     Animation step time
        /// </summary>
        public abstract TimeSpan AnimationStep { get; }
        
        /// <summary>
        ///     Render a terminal spinner
        /// </summary>
        public abstract void Render([NotNull] ITerminalOutput output, [CanBeNull] string title, int time);

        /// <summary>
        ///     Default spinner renderer
        /// </summary>
        [NotNull]
        public static SpinnerRenderer Default { get; } = Linear(spinnerForegroundColor: ConsoleColor.Cyan, titleForegroundColor: ConsoleColor.Yellow);

        /// <summary>
        ///     Create a linear style spinner renderer
        /// </summary>
        [NotNull]
        public static SpinnerRenderer Linear(
            ConsoleColor? spinnerForegroundColor = null,
            ConsoleColor? spinnerBackgroundColor = null,
            ConsoleColor? titleForegroundColor = null,
            ConsoleColor? titleBackgroundColor = null
        )
        {
            return new GlyphSpinnerRenderer(Consts.SPINNER_CHARS)
            {
                SpinnerForegroundColor = spinnerForegroundColor,
                SpinnerBackgroundColor = spinnerBackgroundColor,
                TitleForegroundColor = titleForegroundColor,
                TitleBackgroundColor = titleBackgroundColor
            };
        }
    }
}