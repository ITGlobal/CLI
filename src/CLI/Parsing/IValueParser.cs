﻿using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     String value parser for command line options
    /// </summary>
    [PublicAPI]
    public interface IValueParser<T>
    {
        /// <summary>
        ///     Parses string into a value
        /// </summary>
        ValueParserResult<T> Parse([NotNull] string str);

        /// <summary>
        ///     Converts value back to string
        /// </summary>
        [NotNull]
        string Format(T value);
    }
}