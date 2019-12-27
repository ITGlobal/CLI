using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalLiveProgressBarStringExtensions
    {
        public static void Write([NotNull] this ITerminalLiveProgressBar progressBar, params string[] strs)
        {
            progressBar.Write(AnsiString.Create(strs));
        }

        public static void Complete([NotNull] this ITerminalLiveProgressBar progressBar, params string[] strs)
        {
            progressBar.Complete(AnsiString.Create(strs));
        }

        [PublicAPI]
        public static void Write([NotNull] this ITerminalLiveProgressBar progressBar, int value, params string[] strs)
        {
            progressBar.Write(value, AnsiString.Create(strs));
        }
    }
}