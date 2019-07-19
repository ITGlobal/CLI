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
        private static ITerminalImplementation _defaultImplementation;

        /// <summary>
        ///     Initializes terminal output
        /// </summary>
        public static void Initialize()
        {
            if (IsRunningOnWindows)
            {
                _defaultImplementation = new SystemTerminalImplementation();

            }
            else
            {
                _defaultImplementation = new AnsiTerminalImplementation();
            }

            UseImplementation(null);

            try
            {
                WindowWidth = Console.WindowWidth - 1;
            }
            catch
            {
                WindowWidth = 120;
            }

            if (WindowWidth < 40)
            {
                WindowWidth = 40;
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

        /// <summary>
        ///     Get terminal driver
        /// </summary>
        [NotNull]
        public static ITerminalImplementation GetImplementation()
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

        /// <summary>
        ///     Set terminal driver
        /// </summary>
        public static void UseImplementation([NotNull] ITerminalImplementation implementation)
        {
            lock (SyncRoot)
            {
                _implementation = implementation ?? _defaultImplementation;
            }
        }

        internal static int WindowWidth { get; private set; }
    }
}
