using System;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A style parameters for an <see cref="AnsiString"/>
    /// </summary>
    public interface IColoredStringStyle
    {
        /// <summary>
        ///     Default foreground color
        /// </summary>
        ConsoleColor? ForegroundColor { get; }

        /// <summary>
        ///     Default background color
        /// </summary>
        ConsoleColor? BackgroundColor { get; }
    }
}