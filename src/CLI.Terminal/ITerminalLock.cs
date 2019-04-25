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
        [NotNull]
        ITerminalWriter Stdout { get; }

        [NotNull]
        ITerminalWriter Stderr { get; }

        void ClearLine();
    }
}