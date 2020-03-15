using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line parser that supports subcommands
    /// </summary>
    [PublicAPI]
    public interface ITreeCliParser : ICliCommandRoot, ICliParser
    {
    }
}