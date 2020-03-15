using ITGlobal.CommandLine.Parsing.Help;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Simple command line parser. Doesn't support commands.
    /// </summary>
    [PublicAPI]
    public interface ISimpleCliParser : ICliParser
    {
    }
}