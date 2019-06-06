using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ITerminalLiveProgressBar
    {
        void Write(int? value, ColoredString[] strs);
        void Complete(params ColoredString[] strs);
    }
}