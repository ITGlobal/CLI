using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ITerminalLiveText
    {
        void WipeAfter(bool enable = true);
        void Write(params AnsiString[] strs);
    }
}