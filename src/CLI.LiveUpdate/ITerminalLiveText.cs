using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ITerminalLiveText
    {
        void Write(params ColoredString[] strs);
        void Complete(params ColoredString[] strs);
    }
}