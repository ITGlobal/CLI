using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalLiveTextExtensions
    {
        public static void Write([NotNull] this ITerminalLiveText text, params string[] strs)
        {
            text.Write(AnsiString.Create(strs));
        }
    }
}