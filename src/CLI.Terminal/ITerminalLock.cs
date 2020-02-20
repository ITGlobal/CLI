using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal lock token
    /// </summary>
    [PublicAPI]
    public interface ITerminalLock : IDisposable
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
        ///     Moves cursor to the beginning of specified line (relative to current)
        /// </summary>
        void MoveToLine(int offset);

        /// <summary>
        ///     Clears whole current line
        /// </summary>
        void ClearLine();
    }
}