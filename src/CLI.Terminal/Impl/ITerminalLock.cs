using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Impl
{
    internal interface ITerminalLock : IDisposable
    {
        [NotNull]
        ITerminalOutput Stdout { get; }

        [NotNull]
        ITerminalOutput Stderr { get; }
    }
}