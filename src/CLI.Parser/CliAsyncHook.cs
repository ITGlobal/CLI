using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     An async hook function for command line parser
    /// </summary>
    [PublicAPI]
    public delegate Task CliAsyncHook(IHookCliContext ctx);
}