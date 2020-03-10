using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line argument creator
    /// </summary>
    [PublicAPI]
    public interface ICliArgumentRoot
    {
        /// <summary>
        ///     Add a command line positional argument
        /// </summary>
        CliArgument<T> Argument<T>(
            string displayName,
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null
        );

        /// <summary>
        ///     Add a command line repeatable positional argument
        /// </summary>
        CliRepeatableArgument<T> RepeatableArgument<T>(
            string displayName,
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null
        );
    }
}