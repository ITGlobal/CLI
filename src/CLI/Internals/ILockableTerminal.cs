using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Internals
{
    internal interface ILockableTerminal : ITerminal
    {
        /// <summary>
        ///     Locks terminal output. While terminal is locked, any output to terminal 
        /// </summary>
        [NotNull]
        ITerminalLock Lock([NotNull] ITerminalLockOwner owner);
    }
}