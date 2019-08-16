using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    public interface ITerminalImplementation
    {
        [NotNull]
        ITerminalWriter Stdout { get; }

        [NotNull]
        ITerminalWriter Stderr { get; }

        string DriverName { get; }
        int WindowWidth { get; }

        void MoveToLine(int offset);
        void ClearLine();
    }
}