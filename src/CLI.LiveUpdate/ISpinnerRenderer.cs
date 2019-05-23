using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public interface ISpinnerRenderer
    {
        void Render([NotNull] ITerminalLock terminal, [NotNull] ColoredString[] text, int time);
    }
}