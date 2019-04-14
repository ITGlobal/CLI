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
        public static CliRepeatableOption<string> RepeatableOption(
            [NotNull] this CliCommand command,
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.RepeatableOption<string>(longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable named string option
        /// </summary>
        [NotNull]
        public static CliRepeatableOption<string> RepeatableOption(
            [NotNull] this CliCommand command,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.RepeatableOption<string>(shortName, longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line positional string argument
        /// </summary>
        [NotNull]
        public static CliArgument<string> Argument(
            [NotNull] this CliCommand command,
            [NotNull] string displayName,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.Argument<string>(displayName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable positional string argument
        /// </summary>
        [NotNull]
        public static CliRepeatableArgument<string> RepeatableArgument(
            [NotNull] this CliCommand command,
            [NotNull] string displayName,
            string helpText = null,
            bool hidden = false
        )
        {
            return command.RepeatableArgument<string>(displayName, helpText, hidden);
        }
    }
}