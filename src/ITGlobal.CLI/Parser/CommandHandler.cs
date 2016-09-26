using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Callback for a command
    /// </summary>
    /// <param name="args">
    ///     Unconsumed arguments
    /// </param>
    /// <returns>
    ///     Exit code (usually 0 if OK)
    /// </returns>
    [PublicAPI]
    public delegate int CommandHandler([NotNull] string args);
}