using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ITerminalLiveSpinner
    {
        void Write(params ColoredString[] strs);
        void Complete(params ColoredString[] strs);
    }
}