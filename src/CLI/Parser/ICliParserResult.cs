using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Command line parser result
    /// </summary>
    [PublicAPI]
    public interface ICliParserResult
    {
        /// <summary>
        ///     Executes parser result. A matching callback function will be triggered
        /// </summary>
        /// <returns>
        ///     Exit code
        /// </returns>
        [PublicAPI]
        int Run();
    }
}