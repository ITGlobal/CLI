using System.Collections.Generic;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Usage info for <see cref="CliCommand"/>
    /// </summary>
    [PublicAPI]
    public sealed class CliCommandUsage : IHelpUsage
    {
        internal CliCommandUsage(
            string[] names,
            string helpText,
            bool isHidden,
            int displayOrder,
            CliSwitchUsage[] switches,
            CliOptionUsage[] options,
            CliArgumentUsage[] arguments,
            CliCommandUsage[] commands
        )
        {
            Names = names;
            HelpText = helpText;
            IsHidden = isHidden;
            DisplayOrder = displayOrder;
            Switches = switches;
            Options = options;
            Arguments = arguments;
            Commands = commands;
        }

        internal TreeCliParserUsage Root { get; set; }
        [CanBeNull]
        internal CliCommandUsage Parent { get; set; }

        /// <summary>
        ///     Option names
        /// </summary>
        [NotNull]
        public string[] Names { get; }

        /// <summary>
        ///     Application help text
        /// </summary>
        [CanBeNull]
        public string HelpText { get; }

        /// <summary>
        ///     Is command hidden
        /// </summary>
        public bool IsHidden { get; }

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
        ///     List of subcommands
        /// </summary>
        [NotNull]
        public CliCommandUsage[] Commands { get; }

        /// <summary>
        ///     Command display order
        /// </summary>
        public int DisplayOrder { get; }

        private bool SupportsHelp => Root.HelpSwitches?.Length > 0;

        string IHelpUsage.ExecutableName => Root.ExecutableName;

        string IHelpUsage.HelpCommand
        {
            get
            {
                var command = "";
                if (SupportsHelp)
                {
                    var sw = Root.HelpSwitches[0];
                    if (Parent != null)
                    {
                        command = $"{string.Join(" ", Parent.GetName())} {sw}";
                    }
                    else
                    {
                        command = $"{sw}";
                    }
                }

                return command;
            }
        }

        bool IHelpUsage.SupportsHelp => SupportsHelp;

        internal IEnumerable<string> GetName()
        {
            if (Parent != null)
            {
                foreach (var part in Parent.GetName())
                {
                    yield return part;
                }
            }

            yield return Names[0];
        }
    }
}