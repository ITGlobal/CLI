﻿using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Factory for command line parsers
    /// </summary>
    [PublicAPI]
    public static class CliParser
    {
        /// <summary>
        ///     Creates new simple parser
        /// </summary>
        [NotNull]
        public static ISimpleCliParser NewSimpleParser(
            ITerminal terminal = null,
            string executableName = null,
            string logo = null,
            string helpText = null,
            CliParserFlags flags = CliParserFlags.Default,
            bool? suppressLogo = null,
            bool disableHelpSwitch = false
        )
        {
            ISimpleCliParser parser = new SimpleCliParser();

            if (terminal != null)
            {
                parser.UseTerminal(terminal);
            }

            if (executableName != null)
            {
                parser.ExecutableName(executableName);
            }

            if (logo != null)
            {
                parser.Logo(logo);
            }

            if (helpText != null)
            {
                parser.HelpText(helpText);
            }

            parser.Flags(flags);

            if (suppressLogo != null)
            {
                parser.SuppressLogo(suppressLogo.Value);
            }

            if (!disableHelpSwitch)
            {
                parser.EnableHelp();
            }

            return parser;
        }

        /// <summary>
        ///     Creates new tree parser
        /// </summary>
        [NotNull]
        public static ITreeCliParser NewTreeParser(
            ITerminal terminal = null,
            string executableName = null,
            string logo = null,
            string helpText = null,
            CliParserFlags flags = CliParserFlags.Default,
            bool? suppressLogo = null,
            bool disableHelpSwitch = false,
            bool disableImplicitHelp = false)
        {
            ITreeCliParser parser = new TreeCliParser();

            if (terminal != null)
            {
                parser.UseTerminal(terminal);
            }

            if (executableName != null)
            {
                parser.ExecutableName(executableName);
            }

            if (logo != null)
            {
                parser.Logo(logo);
            }

            if (helpText != null)
            {
                parser.HelpText(helpText);
            }

            parser.Flags(flags);

            if (suppressLogo != null)
            {
                parser.SuppressLogo(suppressLogo.Value);
            }

            if (!disableHelpSwitch)
            {
                parser.EnableHelp();
            }

            if (!disableImplicitHelp)
            {
                ((TreeCliParser) parser).EnableImplicitHelp = true;
            }

            return parser;
        }
    }
}
