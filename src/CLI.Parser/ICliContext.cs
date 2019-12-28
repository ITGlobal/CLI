using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A context for <see cref="CliHandler"/>/<see cref="CliAsyncHandler"/>
    /// </summary>
    [PublicAPI]
    public interface ICliContext
    {
        /// <summary>
        ///     Unconsumed arguments
        /// </summary>
        [NotNull]
        string[] UnconsumedArguments { get; }

        /// <summary>
        ///     Matched command
        /// </summary>
        [CanBeNull]
        CliCommand Command { get; }

        /// <summary>
        ///     Breaks execution with specified exit code
        /// </summary>
        void Break(int exitCode = 0);
    }
}