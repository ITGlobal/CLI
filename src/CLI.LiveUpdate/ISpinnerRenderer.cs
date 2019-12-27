using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public interface ISpinnerRenderer
    {
        void Render([NotNull] ITerminalLock terminal, AnsiString text, int time);
    }
}