using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Provides methods to attach a handler for Ctrl-C/SIGINT
    /// </summary>
    [PublicAPI]
    public static class CtrlCInterceptor
    {
        /// <summary>
        ///     Attache a handler for Ctrl-C/SIGINT
        /// </summary>
        [NotNull]
        public static ICtrlCInterceptor AttachCtrlCInterceptor([NotNull] this ITerminal terminal)
        {
            return new CtrlCInterceptorImpl(terminal);
        }
    }
}
