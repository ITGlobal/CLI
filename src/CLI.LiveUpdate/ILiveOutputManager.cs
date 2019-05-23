using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ILiveOutputManager : IDisposable
    {
        [NotNull]
        ITerminalLiveText CreateText(params ColoredString[] str);

        [NotNull]
        ITerminalLiveSpinner CreateSpinner(params ColoredString[] str);

        [NotNull]
        ITerminalLiveProgressBar CreateProgressBar(int value, ColoredString[] str);
    }
}