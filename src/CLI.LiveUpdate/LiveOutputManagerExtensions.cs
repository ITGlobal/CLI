using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class LiveOutputManagerExtensions
    {
        [NotNull]
        public static ITerminalLiveProgressBar CreateProgressBar(
            [NotNull] this ILiveOutputManager manager,
            params ColoredString[] strs
        )
        {
            return manager.CreateProgressBar(0, strs);
        }
    }
}