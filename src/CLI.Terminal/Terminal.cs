using System;
#if !NET45
using System.Runtime.InteropServices;
#endif
using ITGlobal.CommandLine.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal output wrapper
    /// </summary>
    [PublicAPI]
    public static class Terminal
    {
        private static readonly object SyncRoot = new object();
        private static ITerminalImplementation _implementation;

        /// <summary>
        ///     Initializes terminal output
        /// </summary>
        public static void Initialize()
        {
            if (IsRunningOnWindows)
            {
                UseImplementation(new SystemTerminalImplementation());
            }
            else
            {
                UseImplementation(new AnsiTerminalImplementation());
            }

            try
            {
                WindowWidth = Console.WindowWidth;
            }
            catch
            {
                WindowWidth = 120;
            }
        }

#if !NET45
        private static bool IsRunningOnWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#else
        private static bool IsRunningOnWindows => true;
#endif

        /// <summary>
        ///     Terminal standard output wrapper
        /// </summary>
        [NotNull]
        public static ITerminalWriter Stdout => GetImplementation().Stdout;

        /// <summary>
        ///     Terminal standard error wrapper
        /// </summary>
        [NotNull]
        public static ITerminalWriter Stderr => GetImplementation().Stderr;

        /// <summary>
        ///     Clears current line
        /// </summary>
        public static void ClearLine() => GetImplementation().ClearLine();

        /// <summary>
        ///     Locks terminal output
        /// </summary>
        [NotNull]
        public static ITerminalLock Lock([NotNull] ITerminalLockOwner owner)
        {
            lock (SyncRoot)
            {
                var impl = GetImplementation();
                if (impl is LockedTerminalImplementation)
                {
                    throw new InvalidOperationException("Nested terminal locks are not supported yet");
                }

                var lockedTerminal = new LockedTerminalImplementation(impl, owner);
                UseImplementation(lockedTerminal);

                return lockedTerminal;
            }
        }

        /// <summary>
        ///     Attach a handler for Ctrl-C/SIGINT
        /// </summary>
        [NotNull]
        public static ICtrlCInterceptor OnCtrlC() => new CtrlCInterceptorImpl();
        
        private static ITerminalImplementation GetImplementation()
        {
            lock (SyncRoot)
            {
                if (_implementation == null)
                {
                    Initialize();
                }

                return _implementation;
            }
        }

        internal static void UseImplementation(ITerminalImplementation implementation)
        {
            lock (SyncRoot)
            {
                _implementation = implementation;
            }
        }

        internal static int WindowWidth { get; private set; }
    }
}
