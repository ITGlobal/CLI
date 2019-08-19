using System;
using System.Diagnostics;
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
        private const int MinWindowWidth = 40;
        internal const int DefaultWindowWidth = 150;

        private static readonly object SyncRoot = new object();
        private static bool _isInitialized;
        private static ITerminalImplementation _implementation;
        private static ITerminalImplementation _defaultImplementation;
        private static int _windowWidth;

        /// <summary>
        ///     Initializes terminal output
        /// </summary>
        public static void Initialize()
        {
            lock (SyncRoot)
            {
                if (_isInitialized)
                {
                    return;
                }

                try
                {
                    if (IsRunningOnWindows)
                    {
                        _defaultImplementation = new WindowsTerminalImplementation();
                    }
                    else
                    {
                        _defaultImplementation = new AnsiTerminalImplementation();
                    }

                    _windowWidth = _implementation.WindowWidth;
                }
                catch (Exception e)
                {
                    _defaultImplementation = new SystemTerminalImplementation();
                    _windowWidth = _implementation.WindowWidth;

                    Debug.WriteLine($"CLI: unable to initialize terminal driver: {e}");
                    Debug.WriteLine($"CLI: falling back to {_defaultImplementation.DriverName}");
                }

                _implementation = _defaultImplementation;
                _isInitialized = true;
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
        public static ITerminalWriter Stdout
        {
            get
            {
                Initialize();
                return GetImplementation().Stdout;
            }
        }

        /// <summary>
        ///     Terminal standard error wrapper
        /// </summary>
        [NotNull]
        public static ITerminalWriter Stderr
        {
            get
            {
                Initialize();
                return GetImplementation().Stderr;
            }
        }

        /// <summary>
        ///     Terminal window width
        /// </summary>
        public static int WindowWidth
        {
            get
            {
                Initialize();
                lock (SyncRoot)
                {
                    return _windowWidth;
                }
            }
            set
            {
                value = value < MinWindowWidth ? MinWindowWidth : value;

                Initialize();
                lock (SyncRoot)
                {
                     _windowWidth = value;
                }
            }
        }

        /// <summary>
        ///     Clears current line
        /// </summary>
        public static void ClearLine()
        {
            Initialize();
            GetImplementation().ClearLine();
        }

        /// <summary>
        ///     Locks terminal output
        /// </summary>
        [NotNull]
        public static ITerminalLock Lock([NotNull] ITerminalLockOwner owner)
        {
            Initialize();
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
        public static ICtrlCInterceptor OnCtrlC()
        {
            Initialize();
            return new CtrlCInterceptorImpl();
        }

        /// <summary>
        ///     Get terminal driver
        /// </summary>
        [NotNull]
        public static ITerminalImplementation GetImplementation()
        {
            Initialize();

            lock (SyncRoot)
            {
                return _implementation;
            }
        }

        /// <summary>
        ///     Set terminal driver
        /// </summary>
        public static void UseImplementation([NotNull] ITerminalImplementation implementation)
        {
            Initialize();

            lock (SyncRoot)
            {
                _implementation = implementation ?? _defaultImplementation;
            }
        }
    }
}
