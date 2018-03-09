using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Internals
{
    internal interface ITerminalLock : IDisposable
    {
        [NotNull]
        ITerminalOutput Stdout { get; }

        [NotNull]
        ITerminalOutput Stderr { get; }
    }
}