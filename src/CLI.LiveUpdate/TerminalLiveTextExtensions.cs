using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalLiveTextExtensions
    {
        public static void Write([NotNull] this ITerminalLiveText text, params string[] strs)
        {
            text.Write(strs.Colored());
        }
        public static void Complete([NotNull] this ITerminalLiveText text, params string[] strs)
        {
            text.Complete(strs.Colored());
        }
    }
}