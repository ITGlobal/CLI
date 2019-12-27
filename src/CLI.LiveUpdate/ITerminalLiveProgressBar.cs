using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ITerminalLiveProgressBar : ITerminalLiveText
    {
        void Write(int? value, AnsiString[] strs);
        void Complete(params AnsiString[] strs);
    }
}