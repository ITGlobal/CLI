using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A command builder
    /// </summary>
    [PublicAPI]
    public interface ICommand
    {
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
        ///     Sets a handler function for the command
        /// </summary>
        /// <param name="callback">
        ///     Handler function
        /// </param>
        /// <returns>
        ///     Command
        /// </returns>
        [PublicAPI, NotNull]
        ICommand Handler([NotNull] CommandHandler handler);

        /// <summary>
        ///     Adds an alias for the command
        /// </summary>
        /// <param name="name">
        ///     Command alias
        /// </param>
        /// <returns>
        ///     Command
        /// </returns>
        [PublicAPI, NotNull]
        ICommand Alias([NotNull] string name);

        /// <summary>
        ///     Sets a help text
        /// </summary>
        /// <param name="text">
        ///     Help text
        /// </param>
        /// <returns>
        ///     Command
        /// </returns>
        [PublicAPI, NotNull]
        ICommand HelpText([NotNull] string text);

        /// <summary>
        ///     Marks command as hidden (won't be shown in usage)
        /// </summary>
        [PublicAPI, NotNull]
        ICommand Hidden(bool hidden = true);
    }
}