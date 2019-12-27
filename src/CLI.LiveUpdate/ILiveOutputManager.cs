using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ILiveOutputManager : IDisposable
    {
        void WipeAfter(bool enable = true);

        [NotNull]
        ITerminalLiveText CreateText(params AnsiString[] str);

        [NotNull]
        ITerminalLiveSpinner CreateSpinner(params AnsiString[] str);

        [NotNull]
        ITerminalLiveProgressBar CreateProgressBar(int value, params AnsiString[] str);
    }
}