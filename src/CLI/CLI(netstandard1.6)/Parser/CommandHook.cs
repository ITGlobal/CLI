using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{

    /// <summary>
    ///     Hook for a command parser
    /// </summary>
    /// <param name="args">
    ///     Unconsumed arguments
    /// </param>
    /// <returns>
    ///     Null if command parser should continue execution. 
    ///     Exit code if command parser should exit immediately.
    ///     No command handlers will be triggered in that case.
    /// </returns>
    [PublicAPI]
    public delegate int? CommandHook();
}