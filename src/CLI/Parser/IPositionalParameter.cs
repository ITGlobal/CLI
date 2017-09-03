using System;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Command line positional parameter
    /// </summary>
    /// <typeparam name="T">
    ///     Value type
    /// </typeparam>
    [PublicAPI]
    public interface IPositionalParameter<T>
    {
        /// <summary>
        ///     Gets a value indicating whether a parameter was present in command line
        /// </summary>
        [PublicAPI]
        bool IsSet { get; }

        /// <summary>
        ///     Gets a parameter value
        /// </summary>
        [PublicAPI]
        T Value { get; }

        /// <summary>
        ///     Triggered when a value is parsed from command line
        /// </summary>
        event Action<IPositionalParameter<T>> ValueParsed;

        /// <summary>
        ///     Sets a help text
        /// </summary>
        /// <param name="text">
        ///     Help text
        /// </param>
        /// <returns>
        ///     Command line parameter
        /// </returns>
        [PublicAPI, NotNull]
        IPositionalParameter<T> HelpText([NotNull] string text);

        /// <summary>
        ///     Sets a default value for the parameter
        /// </summary>
        /// <param name="value">
        ///     Default value
        /// </param>
        /// <returns>
        ///     Command line parameter
        /// </returns>
        [PublicAPI, NotNull]
        IPositionalParameter<T> DefaultValue(T value);

        /// <summary>
        ///     Sets a value parser for the parameter
        /// </summary>
        /// <param name="parser">
        ///     Value parser
        /// </param>
        /// <returns>
        ///     Command line parameter
        /// </returns>
        [PublicAPI, NotNull]
        IPositionalParameter<T> ParseUsing([NotNull] Func<string, T> parser);

        /// <summary>
        ///     Sets a flag indicating whether a parameter is optional or not
        /// </summary>
        /// <param name="isRequired">
        ///     true, if parameter is required, false otherwise
        /// </param>
        /// <returns>
        ///     Command line parameter
        /// </returns>
        [PublicAPI, NotNull]
        IPositionalParameter<T> Required(bool isRequired = true);
    }
}