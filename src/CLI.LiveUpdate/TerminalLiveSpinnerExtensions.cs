using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public static class TerminalLiveSpinnerExtensions
    {
        public static void Complete([NotNull] this ITerminalLiveSpinner text, params string[] strs)
        {
            text.Complete(AnsiString.Create(strs));
        }
    }
}