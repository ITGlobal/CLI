using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A command parser builder
    /// </summary>
    [PublicAPI]
    public interface ICommandParser
    {
        /// <summary>
        ///     Sets an executable name (process name is used by default)
        /// </summary>
        [PublicAPI, NotNull]
        ICommandParser ExecutableName(string exeName);

        /// <summary>
        ///     Sets application title
        /// </summary>
        [PublicAPI, NotNull]
        ICommandParser Title(string title);

        /// <summary>
        ///     Sets application version
        /// </summary>
        [PublicAPI, NotNull]
        ICommandParser Version(string version);

        /// <summary>
        ///     Sets application description
        /// </summary>
        [PublicAPI, NotNull]
        ICommandParser HelpText(string text);

        /// <summary>
        ///     Suppresses application logo
        /// </summary>
        [PublicAPI, NotNull]
        ICommandParser SuppressLogo(bool suppress);

        /// <summary>
        ///     Defines a command line switch
        /// </summary>
        /// <param name="name">
        ///     Switch name
        /// </param>
        /// <returns>
        ///     Command line switch
        /// </returns>
        [PublicAPI, NotNull]
        ISwitch Switch([NotNull] string name);

        /// <summary>
        ///     Defines a named parameter
        /// </summary>
        /// <typeparam name="T">
        ///     Parameter type
        /// </typeparam>
        /// <param name="name">
        ///     Parameter name
        /// </param>
        /// <returns>
        ///     Command line named parameter
        /// </returns>
        [PublicAPI, NotNull]
        INamedParameter<T> Parameter<T>([NotNull] string name);

        /// <summary>
        ///     Defines a positional parameter
        /// </summary>
        /// <typeparam name="T">
        ///     Parameter type
        /// </typeparam>
        /// <param name="index">
        ///     Parameter index
        /// </param>
        /// <param name="name">
        ///     Parameter name (used only to print usage)
        /// </param>
        /// <returns>
        ///     Command line positional parameter
        /// </returns>
        [PublicAPI, NotNull]
        IPositionalParameter<T> Parameter<T>(int index, [NotNull] string name);
        
        /// <summary>
        ///     Defines a command
        /// </summary>
        /// <param name="name">
        ///     Command name
        /// </param>
        /// <returns>
        ///     A command builder
        /// </returns>
        [PublicAPI, NotNull]
        ICommand Command([NotNull] string name);

        /// <summary>
        ///     Sets a callback function. This function is triggered if no command has been matched.
        /// </summary>
        [PublicAPI, NotNull]
        ICommandParser Callback([NotNull] CommandHandler callback);

        /// <summary>
        ///     Runs the parser
        /// </summary>
        /// <param name="args">
        ///     Command line arguments
        /// </param>
        /// <returns>
        ///     Command line parser result
        /// </returns>
        [PublicAPI]
        ICommandParserResult Run([NotNull] params string[] args);

        /// <summary>
        ///     Gets a command line usage information
        /// </summary>
        [PublicAPI, NotNull]
        UsageInfo Usage();

        /// <summary>
        ///     Gets a command line usage information on a specified command 
        /// </summary>
        /// <returns>
        ///     Command usage information. null, if no matching command is found.
        /// </returns>
        [PublicAPI, CanBeNull]
        CommandInfo Usage([NotNull] string command);
    }
}