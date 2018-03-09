using System;
using ITGlobal.CommandLine.Internals;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal wrapper
    /// </summary>
    [PublicAPI]
    public static class Terminal
    {
        private static ITerminal _current;

        static Terminal()
        {
            _current = Default;
        }

        /// <summary>
        ///     Current terminal wrapper
        /// </summary>
        [NotNull]
        public static ITerminal Current
        {
            get => _current;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _current = value;
            }
        }

        /// <summary>
        ///     Default terminal wrapper
        /// </summary>
        [NotNull]
        public static ITerminal Default { get; } = new SystemTerminal();

        /// <summary>
        ///     Current terminal standard input wrapper
        /// </summary>
        [NotNull]
        public static ITerminalInput Stdin => Current.Stdin;

        /// <summary>
        ///     Terminal standard output wrapper
        /// </summary>
        [NotNull]
        public static ITerminalOutput Stdout => Current.Stdout;

        /// <summary>
        ///     Terminal standard error wrapper
        /// </summary>
        [NotNull]
        public static ITerminalOutput Stderr => Current.Stderr;
    }
}
