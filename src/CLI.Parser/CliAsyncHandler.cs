using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     An async handler function for command line parser
    /// </summary>
    [PublicAPI]
    public delegate Task CliAsyncHandler(ICliContext ctx);
}