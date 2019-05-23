using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalLiveProgressBarExtensions
    {
        [PublicAPI]
        public static void Write(
            [NotNull] this ITerminalLiveProgressBar bar,
            params ColoredString[] strs
        )
        {
            bar.Write(null, strs);
        }

        [PublicAPI]
        public static void Write(
            [NotNull] this ITerminalLiveProgressBar bar,
            int value
        )
        {
            bar.Write(value, null);
        }

        [PublicAPI]
        public static void Write(
            [NotNull] this ITerminalLiveProgressBar bar,
            int value,
            params ColoredString[] strs
        )
        {
            bar.Write(value, strs);
        }
    }
}