﻿using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Extension method for <see cref="ISimpleCliParser"/> and <see cref="ITreeCliParser"/>
    /// </summary>
    [PublicAPI]
    public static class CliParserExtensions
    {
        /// <summary>
        ///     Add a command line named string option
        /// </summary>
        [NotNull]
        public static CliOption<string> Option(
            [NotNull] this ICliParser parser,
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        )
        {
            return parser.Option<string>(longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line named string option
        /// </summary>
        [NotNull]
        public static CliOption<string> Option(
            [NotNull] this ICliParser parser,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        )
        {
            return parser.Option<string>(shortName, longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable named string option
        /// </summary>
        [NotNull]
        public static MultiCliOption<string> MultiOption(
            [NotNull] this ICliParser parser,
            [NotNull] string longName,
            string helpText = null,
            bool hidden = false
        )
        {
            return parser.MultiOption<string>(longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable named string option
        /// </summary>
        [NotNull]
        public static MultiCliOption<string> MultiOption(
            [NotNull] this ICliParser parser,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false
        )
        {
            return parser.MultiOption<string>(shortName, longName, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line positional string argument
        /// </summary>
        [NotNull]
        public static CliArgument<string> Argument(
            [NotNull] this ICliParser parser,
            [NotNull] string displayName,
            int position,
            string helpText = null,
            bool hidden = false
        )
        {
            return parser.Argument<string>(displayName, position, helpText, hidden);
        }

        /// <summary>
        ///     Add a command line repeatable positional string argument
        /// </summary>
        [NotNull]
        public static MultiCliArgument<string> MultiArgument(
            [NotNull] this ICliParser parser,
            [NotNull] string displayName,
            int position,
            string helpText = null,
            bool hidden = false
        )
        {
            return parser.MultiArgument<string>(displayName, position, helpText, hidden);
        }
    }
}