using System;

namespace ITGlobal.CommandLine.Impl
{
    internal interface ILiveOutputItem
    {
        bool NeedsRedraw { get; }
        void Clear(ITerminalLock terminal);
        void Draw(ITerminalLock terminal, int time);
        bool DrawFinal(ITerminalLock terminal, int time, bool defaultWipeAfter);
        void OnTimer(int time);
    }
}