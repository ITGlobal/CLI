using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Usage info for <see cref="ISimpleCliParser"/>
    /// </summary>
    [PublicAPI]
    public sealed class SimpleCliParserUsage : IHelpUsage
    {
        internal SimpleCliParserUsage(
            ITerminal terminal,
            string executableName,
            string logo,
            string helpText,
            CliSwitchUsage[] switches,
            CliOptionUsage[] options,
            CliArgumentUsage[] arguments,
            string[] helpSwitches
            )
        {
            Terminal = terminal;
            ExecutableName = executableName;
            Logo = logo;
            HelpText = helpText;
            Switches = switches;
            Options = options;
            Arguments = arguments;
            HelpSwitches = helpSwitches;
        }

        [NotNull]
        internal ITerminal Terminal { get; }

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
    }
}