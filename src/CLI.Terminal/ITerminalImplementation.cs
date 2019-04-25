using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public interface ITerminalImplementation
    {
        [NotNull]
        ITerminalWriter Stdout { get; }

        [NotNull]
        ITerminalWriter Stderr { get; }

        void ClearLine();
    }
}