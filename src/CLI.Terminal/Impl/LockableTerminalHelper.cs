using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Impl
{
    internal static class LockableTerminalHelper
    {
        /// <summary>
        ///     Locks terminal output. While terminal is locked, any output to terminal 
        /// </summary>
        [NotNull]
        internal static ITerminalLock Lock([NotNull] this ITerminal terminal, [NotNull] ITerminalLockOwner owner)
        {
            var locableTerminal = terminal as ILockableTerminal;
            if (locableTerminal != null)
            {
                return locableTerminal.Lock(owner);
            }

            return new DisabledTerminalLock(terminal);
        }
    }
}