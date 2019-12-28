using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A handler function for command line parser
    /// </summary>
    [PublicAPI]
    public delegate void CliHandler(ICliContext ctx);
}