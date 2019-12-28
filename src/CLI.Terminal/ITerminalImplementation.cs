using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A terminal driver implementation
    /// </summary>
    public interface ITerminalImplementation : IDisposable
    {
        /// <summary>
        ///     A standard output writer
        /// </summary>
        [NotNull]
        ITerminalWriter Stdout { get; }

        /// <summary>
        ///     A standard error writer
        /// </summary>
        [NotNull]
        ITerminalWriter Stderr { get; }

        /// <summary>
        ///     Driver name
        /// </summary>
        [NotNull]
        string DriverName { get; }

        /// <summary>
        ///     Terminal window width
        /// </summary>
        int WindowWidth { get; }

        /// <summary>
        ///     Creates a copy of terminal driver
        /// </summary>
        [NotNull]
        ITerminalImplementation Clone();

        /// <summary>
        ///     Initializes a terminal driver
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Moves cursor to the beginning of specified line (relative to current)
        /// </summary>
        void MoveToLine(int offset);

        /// <summary>
        ///     Clears whole current line
        /// </summary>
        void ClearLine();
    }
}