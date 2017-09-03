using System;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A command line switch
    /// </summary>
    [PublicAPI]
    public interface ISwitch
    {
        /// <summary>
        ///     Gets a value indicating whether a switch was present in command line
        /// </summary>
        [PublicAPI]
        bool IsSet { get; }

        /// <summary>
        ///     Triggered when a value is parsed from command line
        /// </summary>
        event Action<ISwitch> ValueParsed;

        /// <summary>
        ///     Adds an alias for the switch
        /// </summary>
        /// <param name="name">
        ///     Switch alias
        /// </param>
        /// <returns>
        ///     Command line switch
        /// </returns>
        [PublicAPI, NotNull]
        ISwitch Alias([NotNull] string name);

        /// <summary>
        ///     Sets a help text
        /// </summary>
        /// <param name="text">
        ///     Help text
        /// </param>
        /// <returns>
        ///     Command line switch
        /// </returns>
        [PublicAPI, NotNull]
        ISwitch HelpText([NotNull] string text);

        /// <summary>
        ///     Marks switch as hidden (won't be shown in usage)
        /// </summary>
        [PublicAPI, NotNull]
        ISwitch Hidden(bool hidden = true);
    }
}