using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public interface IProgressBarRenderer
    {
        void Render([NotNull] ITerminalLock terminal, [NotNull] ColoredString[] text, int value, int time);
    }
}
