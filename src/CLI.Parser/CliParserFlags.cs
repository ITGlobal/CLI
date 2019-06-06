using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line parser flags
    /// </summary>
    [PublicAPI, Flags]
    public enum CliParserFlags
    {
        /// <summary>
        ///     Default value
        /// </summary>
        None = 0,

        /// <summary>
        ///     Allows parser to skip unknown options
        /// </summary>
        IgnoreUnknownOptions = 1 << 0,

        /// <summary>
        ///     Allows parser to skip unknown arguments
        /// </summary>
        AllowFreeArguments = 1 << 1,

        /// <summary>
        ///     Enables POSIX style options (with leading dashes)
        /// </summary>
        PosixNotation = 1 << 2,

        /// <summary>
        ///     Enables POSIX style options (with leading slash)
        /// </summary>
        WindowsNotation = 1 << 3,

        /// <summary>
        ///     Enables options with colon-separated value (e.g. "--option:value" or "/option:value")
        /// </summary>
        ColonSeparatedValues = 1 << 4,

        /// <summary>
        ///     Enables options with EQ-separated value (e.g. "--option=value" or "/option=value")
        /// </summary>
        EqualitySignSeparatedValues = 1 << 5,

        /// <summary>
        ///     Default value
        /// </summary>
        Default = PosixNotation | EqualitySignSeparatedValues
    }
}