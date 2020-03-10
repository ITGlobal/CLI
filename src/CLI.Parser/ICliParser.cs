using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line parser base interface
    /// </summary>
    [PublicAPI]
    public interface ICliParser : ICliArgumentRoot, ICliOptionRoot, ICliSwitchRoot
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
    }
}