using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    [PublicAPI]
    public interface ITerminalLiveSpinner : ITerminalLiveText
    {
        void Complete(params ColoredString[] strs);
    }
}