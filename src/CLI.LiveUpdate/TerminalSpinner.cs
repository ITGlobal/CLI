using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
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
            => new SpinnerImpl(title, renderer ?? SpinnerRenderer.Default);
    }
}