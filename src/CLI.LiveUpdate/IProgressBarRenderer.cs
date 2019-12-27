using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public interface IProgressBarRenderer
    {
        void Render([NotNull] ITerminalLock terminal, AnsiString text, int value, int time);
    }
}
