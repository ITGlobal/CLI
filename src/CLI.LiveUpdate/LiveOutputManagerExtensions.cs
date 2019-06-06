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
            return manager.CreateText(strs.Colored());
        }

        [NotNull]
        public static ITerminalLiveSpinner CreateSpinner(
            [NotNull] this ILiveOutputManager manager,
            params string[] strs
        )
        {
            return manager.CreateSpinner(strs.Colored());
        }

        [NotNull]
        public static ITerminalLiveProgressBar CreateProgressBar(
            [NotNull] this ILiveOutputManager manager,
            params ColoredString[] strs
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
            return manager.CreateProgressBar(0, strs.Colored());
        }
    }
}