using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A hook function for command line parser
    /// </summary>
    [PublicAPI]
    public delegate void CliHook(IHookCliContext ctx);
}