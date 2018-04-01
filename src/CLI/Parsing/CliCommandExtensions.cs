using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Extension method for <see cref="CliCommand"/>
    /// </summary>
    [PublicAPI]
    public static class CliCommandExtensions
    {
        /// <summary>
        ///     Add a command line named string option
        /// </summary>
        [NotNull]
        public static CliOption<string> Option(
            [NotNull] this CliCommand command,
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.Option<string>(longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line named string option
        /// </summary>
        [NotNull]
        public static CliOption<string> Option(
            [NotNull] this CliCommand command,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.Option<string>(shortName, longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable named string option
        /// </summary>
        [NotNull]
        public static MultiCliOption<string> MultiOption(
            [NotNull] this CliCommand command,
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.MultiOption<string>(longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable named string option
        /// </summary>
        [NotNull]
        public static MultiCliOption<string> MultiOption(
            [NotNull] this CliCommand command,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.MultiOption<string>(shortName, longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line positional string argument
        /// </summary>
        [NotNull]
        public static CliArgument<string> Argument(
            [NotNull] this CliCommand command,
            [NotNull] string displayName,
            int position,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.Argument<string>(displayName, position, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable positional string argument
        /// </summary>
        [NotNull]
        public static MultiCliArgument<string> MultiArgument(
            [NotNull] this CliCommand command,
            [NotNull] string displayName,
            int position,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.MultiArgument<string>(displayName, position, helpText, hidden);
        }
    }
}