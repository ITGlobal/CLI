using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line switch creator
    /// </summary>
    [PublicAPI]
    public interface ICliSwitchRoot
    {
        /// <summary>
        ///     Add a command line switch
        /// </summary>
        [NotNull]
        CliSwitch Switch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line switch
        /// </summary>
        [NotNull]
        CliSwitch Switch(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line repeatable switch
        /// </summary>
        [NotNull]
        CliRepeatableSwitch RepeatableSwitch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line repeatable switch
        /// </summary>
        [NotNull]
        CliRepeatableSwitch RepeatableSwitch(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        );
    }
}