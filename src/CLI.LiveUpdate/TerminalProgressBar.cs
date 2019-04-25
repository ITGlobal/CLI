using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal process bar extension
    /// </summary>
    [PublicAPI]
    public static class TerminalProgressBar
    {
        /// <summary>
        ///     Creates a terminal progress bar
        /// </summary>
        [NotNull]
        public static IProgressBar Create(ProgressBarRenderer renderer = null, string text = null)
        {
            return new ProgressBarImpl(renderer ?? ProgressBarRenderer.Default, text);
        }
    }
}