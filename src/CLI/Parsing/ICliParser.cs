using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line parser base interface
    /// </summary>
    [PublicAPI]
    public interface ICliParser
    {
        /// <summary>
        ///     Set a terminal for parser output
        /// </summary>
        void UseTerminal([NotNull] ITerminal terminal);

        /// <summary>
        ///     Set an executable name (process name is used by default)
        /// </summary>
        void ExecutableName([NotNull] string name);

        /// <summary>
        ///     Set application logo
        /// </summary>
        void Logo([CanBeNull] string logo);

        /// <summary>
        ///     Set application description
        /// </summary>
        void HelpText([NotNull] string text);

        /// <summary>
        ///     Suppress application logo
        /// </summary>
        void SuppressLogo(bool suppress = true);

        /// <summary>
        ///     Set parser flags
        /// </summary>
        void Flags(CliParserFlags flags);

        /// <summary>
        ///     Add a command line switch
        /// </summary>
        [NotNull]
        CliSwitch Switch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a command line switch
        /// </summary>
        [NotNull]
        CliSwitch Switch(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a command line repeteable switch
        /// </summary>
        [NotNull]
        MultiCliSwitch MultiSwitch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line repeteable switch
        /// </summary>
        [NotNull]
        MultiCliSwitch MultiSwitch(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line positional argument
        /// </summary>
        [NotNull]
        CliArgument<T> Argument<T>(
            [NotNull] string displayName,
            int position,
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null
        );

        /// <summary>
        ///     Add a command line repeatable positional argument
        /// </summary>
        [NotNull]
        MultiCliArgument<T> MultiArgument<T>(
            [NotNull] string displayName,
            int position,
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null
        );

        /// <summary>
        ///     Add a command line option
        /// </summary>
        [NotNull]
        CliOption<T> Option<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a command line option
        /// </summary>
        [NotNull]
        CliOption<T> Option<T>(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a command line repeatable option
        /// </summary>
        [NotNull]
        MultiCliOption<T> MultiOption<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a command line repeatable option
        /// </summary>
        [NotNull]
        MultiCliOption<T> MultiOption<T>(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a callback that will be executed before main handler
        /// </summary>
        void BeforeExecute([NotNull] CliHandler handler);

        /// <summary>
        ///     Add a callback that will be executed before main handler
        /// </summary>
        void BeforeExecuteAsync([NotNull] CliAsyncHandler handler);

        /// <summary>
        ///     Add a execution callback
        /// </summary>
        void OnExecute([NotNull] CliHandler handler);

        /// <summary>
        ///     Add a execution callback
        /// </summary>
        void OnExecuteAsync([NotNull] CliAsyncHandler handler);

        /// <summary>
        ///     Run the parser
        /// </summary>
        ICliParserResult Parse([NotNull] params string[] args);
    }
}