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
            return Create(Terminal.Current, renderer, text);
        }

        /// <summary>
        ///     Creates a terminal progress bar
        /// </summary>
        [NotNull]
        public static IProgressBar Create([NotNull] ITerminal terminal, ProgressBarRenderer renderer = null, string text = null)
        {
            return new ProgressBarImpl(terminal, renderer ?? ProgressBarRenderer.Default, text);
        }
    }
}