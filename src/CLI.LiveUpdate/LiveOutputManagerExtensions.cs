using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class LiveOutputManagerExtensions
    {
        [NotNull]
        public static ITerminalLiveText CreateText(
            [NotNull] this ILiveOutputManager manager,
            params string[] strs
        )
        {
            return manager.CreateText(AnsiString.Create(strs));
        }

        [NotNull]
        public static ITerminalLiveSpinner CreateSpinner(
            [NotNull] this ILiveOutputManager manager,
            params string[] strs
        )
        {
            return manager.CreateSpinner(AnsiString.Create(strs));
        }

        [NotNull]
        public static ITerminalLiveProgressBar CreateProgressBar(
            [NotNull] this ILiveOutputManager manager,
            params AnsiString[] strs
        )
        {
            return manager.CreateProgressBar(0, strs);
        }

        [NotNull]
        public static ITerminalLiveProgressBar CreateProgressBar(
            [NotNull] this ILiveOutputManager manager,
            params string[] strs
        )
        {
            return manager.CreateProgressBar(0, AnsiString.Create(strs));
        }
    }
}