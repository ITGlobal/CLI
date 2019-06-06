using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalLiveProgressBarStringExtensions
    {
        public static void Write([NotNull] this ITerminalLiveProgressBar progressBar, params string[] strs)
        {
            progressBar.Write(strs.Colored());
        }

        public static void Complete([NotNull] this ITerminalLiveProgressBar progressBar, params string[] strs)
        {
            progressBar.Complete(strs.Colored());
        }

        [PublicAPI]
        public static void Write(
            [NotNull] this ITerminalLiveProgressBar bar,
            int value,
            params string[] strs
        )
        {
            bar.Write(value, strs.Colored());
        }
    }
}