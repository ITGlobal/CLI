using System;
using System.Collections.Generic;
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
        private static ConsoleColor _defaultForegroundColor;
        private static ConsoleColor _defaultBackgroundColor;

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

                    _defaultImplementation.Initialize();
                    _windowWidth = _defaultImplementation.WindowWidth;
                }
                catch (Exception e)
                {
                    _defaultImplementation?.Dispose();

                    _defaultImplementation = new SystemTerminalImplementation();
                    _defaultImplementation.Initialize();
                    _windowWidth = _defaultImplementation.WindowWidth;

                    Debug.WriteLine($"CLI: unable to initialize terminal driver: {e}");
                    Debug.WriteLine($"CLI: falling back to {_defaultImplementation.DriverName}");
                }

                Console.ResetColor();
                
                _defaultForegroundColor = Console.ForegroundColor;
                if (!Enum.IsDefined(typeof(ConsoleColor), _defaultForegroundColor))
                {
                    _defaultForegroundColor = ConsoleColor.Gray;
                }

                _defaultBackgroundColor = Console.BackgroundColor;
                if (!Enum.IsDefined(typeof(ConsoleColor), _defaultBackgroundColor))
                {
                    _defaultBackgroundColor = ConsoleColor.Black;
                }

                _implementation = _defaultImplementation;
                _isInitialized = true;
            }
        }

        /// <summary>
        ///     Deinitializes terminal output
        /// </summary>
        public static void Shutdown()
        {
            lock (SyncRoot)
            {
                if (!_isInitialized)
                {
                    return;
                }

                _defaultImplementation?.Dispose();
                if (!ReferenceEquals(_defaultImplementation, _implementation))
                {
                    _implementation?.Dispose();
                }

                _implementation = null;
                _defaultImplementation = null;
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
        ///     Terminal default foreground color
        /// </summary>
        public static ConsoleColor DefaultForegroundColor
        {
            get
            {
                Initialize();
                lock (SyncRoot)
                {
                    return _defaultForegroundColor;
                }
            }
        }

        /// <summary>
        ///     Terminal default background color
        /// </summary>
        public static ConsoleColor DefaultBackgroundColor
        {
            get
            {
                Initialize();
                lock (SyncRoot)
                {
                    return _defaultBackgroundColor;
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
                lock (SyncRoot)
                {
                    _implementation = lockedTerminal;
                }
                lockedTerminal.Initialize();

                return lockedTerminal;
            }
        }

        #region Ctrl-C/SIGINT

        private static readonly object CtrlCInterceptorsLock = new object();
        private static readonly Stack<CtrlCInterceptorImpl> CtrlCInterceptors
            = new Stack<CtrlCInterceptorImpl>();

        /// <summary>
        ///     Attach a handler for Ctrl-C/SIGINT
        /// </summary>
        [NotNull]
        public static ICtrlCInterceptor OnCtrlC()
        {
            Initialize();

            var interceptor = new CtrlCInterceptorImpl();
            var shouldAttachHandler = false;
            lock (CtrlCInterceptorsLock)
            {
                if (CtrlCInterceptors.Count == 0)
                {
                    shouldAttachHandler = true;
                }

                CtrlCInterceptors.Push(interceptor);
            }

            if (shouldAttachHandler)
            {
                Console.CancelKeyPress += OnCancelKeyPress;
            }

            return interceptor;
        }

        internal static void DetachCtrlCInterceptor()
        {
            var shouldDetachHandler = false;
            lock (CtrlCInterceptorsLock)
            {
                if (CtrlCInterceptors.Count == 0)
                {
                    return;
                }

                if (CtrlCInterceptors.Count ==1)
                {
                    shouldDetachHandler = true;
                }

                CtrlCInterceptors.Pop();
            }

            if (shouldDetachHandler)
            {
                Console.CancelKeyPress -= OnCancelKeyPress;
            }
        }

        private static void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            CtrlCInterceptorImpl interceptor;
            lock (CtrlCInterceptorsLock)
            {
                if (CtrlCInterceptors.Count == 0)
                {
                    return;
                }

                interceptor = CtrlCInterceptors.Peek();
            }

            e.Cancel = true;
            interceptor.Trigger();
        }

        #endregion

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
        public static IDisposable UseImplementation([NotNull] ITerminalImplementation implementation)
        {
            Initialize();

            lock (SyncRoot)
            {
                var resetToImplementation = _implementation;

                _implementation = implementation ?? _defaultImplementation.Clone();
                _implementation.Initialize();
                
                return new UseImplementationToken(resetToImplementation);
            }
        }

        private sealed class UseImplementationToken : IDisposable
        {
            private readonly ITerminalImplementation _resetToImplementation;

            public UseImplementationToken(ITerminalImplementation resetToImplementation)
            {
                _resetToImplementation = resetToImplementation;
            }

            public void Dispose()
            {
                lock (SyncRoot)
                {
                    _implementation?.Dispose();
                    _implementation = (_resetToImplementation ?? _defaultImplementation).Clone();
                    _implementation.Initialize();
                }
            }
        }

        /// <summary>
        ///     Disable terminal colors
        /// </summary>
        public static IDisposable DisableColors()
        {
            return UseImplementation(new NoColorTerminalImplementation(GetImplementation()));
        }
    }
}
