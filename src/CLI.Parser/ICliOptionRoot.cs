using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line option creator
    /// </summary>
    [PublicAPI]
    public interface ICliOptionRoot
    {
        /// <summary>
        ///     Add a command line option
        /// </summary>
        [NotNull]
        CliOption<T> Option<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line option
        /// </summary>
        [NotNull]
        CliOption<T> Option<T>(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line repeatable option
        /// </summary>
        [NotNull]
        CliRepeatableOption<T> RepeatableOption<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line repeatable option
        /// </summary>
        [NotNull]
        CliRepeatableOption<T> RepeatableOption<T>(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        );
    }
}