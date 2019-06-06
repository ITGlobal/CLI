using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal lock owner
    /// </summary>
    [PublicAPI]
    public interface ITerminalLockOwner
    {
        void Begin();
        void WriteOutput(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor);
        void WriteError(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor);
        void End();
    }
}