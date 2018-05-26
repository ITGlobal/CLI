using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line parser that supports subcommands
    /// </summary>
    [PublicAPI]
    public interface ITreeCliParser : ICliCommandRoot, ICliParser
    {
        /// <summary>
        ///     Add a command line command
        /// </summary>
        [NotNull]
        CliCommand Command(
            [NotNull] string name,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Get usage info
        /// </summary>
        [NotNull]
        TreeCliParserUsage GetUsage();
    }
}