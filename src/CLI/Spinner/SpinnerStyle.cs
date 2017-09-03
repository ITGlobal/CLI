using System;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Defines spinner style
    /// </summary>
    public abstract class SpinnerStyle
    {
        /// <summary>
        ///     Spinner animation interval
        /// </summary>
        public virtual int AnimationInterval { get; } = CLI.SPINNER_SLEEP_TIME;

        /// <summary>
        ///     Spinner animation glyphs
        /// </summary>
        public abstract char[] Glyphs { get; }

        /// <summary>
        ///     Spinner glyph's foreground color
        /// </summary>
        public virtual ConsoleColor SpinnerFgColor => ConsoleColor.Cyan;

        /// <summary>
        ///     Spinner glyph's background color
        /// </summary>
        public virtual ConsoleColor SpinnerBgColor => ConsoleColor.Black;

        /// <summary>
        ///     Spinner title's foreground color
        /// </summary>
        public virtual ConsoleColor TitleFgColor => ConsoleColor.Yellow;

        /// <summary>
        ///     Spinner title's background color
        /// </summary>
        public virtual ConsoleColor TitleBgColor => ConsoleColor.Black;

        /// <summary>
        ///     Default style (rotating line)
        /// </summary>
        public static SpinnerStyle Default { get; } = new DefaultSpinnerStyle();
        
        private sealed class DefaultSpinnerStyle : SpinnerStyle
        {
            public override char[] Glyphs { get; } = { '\\', '|', '/', '-' };
        }
    }
}
