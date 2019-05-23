using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalLiveSpinnerExtensions
    {
        public static void Write([NotNull] this ITerminalLiveSpinner spinner, params string[] strs)
        {
            spinner.Write(strs.Colored());
        }
        public static void Complete([NotNull] this ITerminalLiveSpinner spinner, params string[] strs)
        {
            spinner.Complete(strs.Colored());
        }
    }
}