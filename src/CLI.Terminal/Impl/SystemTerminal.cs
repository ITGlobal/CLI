using System;

namespace ITGlobal.CommandLine.Impl
{
    /// <summary>
    ///     Terminal wrapper
    /// </summary>
    internal sealed class SystemTerminal : ILockableTerminal
    {
        /// <summary>
        ///     Terminal standard input wrapper
        /// </summary>
        public ITerminalInput Stdin { get; } = new SystemTerminalInput(Console.In, IsInputRedirected);

        /// <summary>
        ///     Terminal standard output wrapper
        /// </summary>
        public ITerminalOutput Stdout { get; } = new SystemTerminalOutput(Console.Out, IsOutputRedirected);

        /// <summary>
        ///     Terminal standard error wrapper
        /// </summary>
        public ITerminalOutput Stderr { get; } = new SystemTerminalOutput(Console.Error, IsErrorRedirected);

        /// <summary>
        ///     Locks terminal output. While terminal is locked, any output to terminal 
        /// </summary>
        public ITerminalLock Lock(ITerminalLockOwner owner) => new SystemTerminalLock(this, owner);

#if NET40
        private static bool IsInputRedirected => false;
        private static bool IsOutputRedirected => false;
        private static bool IsErrorRedirected => false;
#else
        private static bool IsInputRedirected => Console.IsInputRedirected;
        private static bool IsOutputRedirected => Console.IsOutputRedirected;
        private static bool IsErrorRedirected => Console.IsErrorRedirected;
#endif
    }
}