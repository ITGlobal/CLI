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
        ///     Set parser result factory
        /// </summary>
        void UseResultFactory(ICliParserResultFactory factory);

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
        CliRepeatableSwitch RepeatableSwitch(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        );

        /// <summary>
        ///     Add a command line repeteable switch
        /// </summary>
        [NotNull]
        CliRepeatableSwitch RepeatableSwitch(
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
            string helpText = null,
            bool hidden = false,
            IValueParser<T> parser = null
        );

        /// <summary>
        ///     Add a command line repeatable positional argument
        /// </summary>
        [NotNull]
        CliRepeatableArgument<T> RepeatableArgument<T>(
            [NotNull] string displayName,
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
        CliRepeatableOption<T> RepeatableOption<T>(
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a command line repeatable option
        /// </summary>
        [NotNull]
        CliRepeatableOption<T> RepeatableOption<T>(
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false);

        /// <summary>
        ///     Add a hook that will be executed before main handler
        /// </summary>
        void BeforeExecute([NotNull] CliHook hook);

        /// <summary>
        ///     Add a hook that will be executed before main handler
        /// </summary>
        void BeforeExecuteAsync([NotNull] CliAsyncHook hook);

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
        [NotNull] 
        ICliParserResult Parse([NotNull] params string[] args);

        /// <summary>
        ///     Get autocompletion results
        /// </summary>
        [NotNull]
        AutoCompletionItem[] Autocomplete([NotNull] string[] args, int? position = null);
    }

    public sealed class AutoCompletionItem
    {
        public AutoCompletionItem(AutoCompletionItemType type, string value)
        {
            Type = type;
            Value = value;
        }

        public AutoCompletionItemType Type { get; }
        public string Value { get; }

        internal static AutoCompletionItem Command(string value) 
            => new AutoCompletionItem(AutoCompletionItemType.Command, value);
    }

    public enum AutoCompletionItemType
    {
        Command = 1,
        Option,
        Switch,
        ArgumentValue,
        OptionValue,
    }
}