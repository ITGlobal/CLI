using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Spinners
{
    /// <summary>
    ///     Terminal spinner extension
    /// </summary>
    [PublicAPI]
    public static class TerminalSpinner
    {
        /// <summary>
        ///     Creates a terminal spinner
        /// </summary>
        [NotNull]
        public static ISpinner Create(string title = null, SpinnerRenderer renderer = null) 
            => Create(Terminal.Current, title, renderer);

        /// <summary>
        ///     Creates a terminal spinner
        /// </summary>
        [NotNull]
        public static ISpinner Create([NotNull] ITerminal terminal, string title = null, SpinnerRenderer renderer = null) 
            => new SpinnerImpl(terminal, title, renderer ?? SpinnerRenderer.Default);
    }
}