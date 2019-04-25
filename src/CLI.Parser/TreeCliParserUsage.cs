using System;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Usage info for <see cref="ITreeCliParser"/>
    /// </summary>
    [PublicAPI]
    public sealed class TreeCliParserUsage : IHelpUsage
    {
        internal TreeCliParserUsage(
            string executableName,
            string logo,
            string helpText,
            CliSwitchUsage[] switches,
            CliOptionUsage[] options,
            CliArgumentUsage[] arguments,
            CliCommandUsage[] commands,
            string[] helpSwitches
        )
        {
            ExecutableName = executableName;
            Logo = logo;
            HelpText = helpText;
            Switches = switches;
            Options = options;
            Arguments = arguments;
            Commands = commands;
            HelpSwitches = helpSwitches;
        }

        /// <summary>
        ///     Executable name
        /// </summary>
        [NotNull]
        public string ExecutableName { get; }

        /// <summary>
        ///     Application logo
        /// </summary>
        [CanBeNull]
        public string Logo { get; }

        /// <summary>
        ///     Application help text
        /// </summary>
        [CanBeNull]
        public string HelpText { get; }

        /// <summary>
        ///     List of supported switches
        /// </summary>
        [NotNull]
        public CliSwitchUsage[] Switches { get; }

        /// <summary>
        ///     List of supported options
        /// </summary>
        [NotNull]
        public CliOptionUsage[] Options { get; }

        /// <summary>
        ///     List of supported arguments
        /// </summary>
        [NotNull]
        public CliArgumentUsage[] Arguments { get; }

        /// <summary>
        ///     List of commands
        /// </summary>
        [NotNull]
        public CliCommandUsage[] Commands { get; }

        /// <summary>
        ///     List of supported help switches. null if built-in help switch is disabled.
        /// </summary>
        [CanBeNull]
        public string[] HelpSwitches { get; }

        private bool SupportsHelp => HelpSwitches?.Length > 0;
        bool IHelpUsage.SupportsHelp => SupportsHelp;

        string IHelpUsage.HelpCommand
        {
            get
            {
                if (SupportsHelp)
                {
                    return HelpSwitches[0];
                }

                return "";
            }
        }

        internal CliCommandUsage GetCommandUsage(string[] name)
        {
            var commands = Commands;
            CliCommandUsage command = null;
            foreach (var part in name)
            {
                command = commands.FirstOrDefault(
                    _ => _.Names.Contains(part, StringComparer.OrdinalIgnoreCase));
                if (command == null)
                {
                    break;
                }

                commands = command.Commands;
            }

            return command;
        }
    }
}