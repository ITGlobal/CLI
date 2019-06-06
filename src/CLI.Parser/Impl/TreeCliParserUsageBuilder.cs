using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class TreeCliParserUsageBuilder : ICliCommandUsageBuilder
    {
        private readonly TreeCliParser _parser;

        private readonly List<CliSwitchUsage> _switches = new List<CliSwitchUsage>();
        private readonly List<CliOptionUsage> _options = new List<CliOptionUsage>();
        private readonly List<CliArgumentUsage> _arguments = new List<CliArgumentUsage>();
        private readonly List<CliCommandUsageBuilder> _commands = new List<CliCommandUsageBuilder>();

        public TreeCliParserUsageBuilder(TreeCliParser parser)
        {
            _parser = parser;
        }

        public string[] GetOptionNames(char? shortName, string longName)
            => CommandLineTokenizer.GetOptionNames(_parser.Flags, shortName, longName);

        public void AddSwitch(CliSwitchUsage usage)
        {
            _switches.Add(usage);
        }

        public void AddOption(CliOptionUsage usage)
        {
            _options.Add(usage);
        }

        public void AddArgument(CliArgumentUsage usage)
        {
            _arguments.Add(usage);
        }

        public CliCommandUsageBuilder AddCommand(string[] names, string helpText, bool isHidden, int displayOrder)
        {
            var builder = new CliCommandUsageBuilder(this, names, helpText, isHidden, displayOrder);
            _commands.Add(builder);
            return builder;
        }

        public TreeCliParserUsage Build()
        {
            var helpSwitches = _switches.Where(_ => _.IsHelpSwitch).SelectMany(_ => _.Names).ToArray();
            var usage = new TreeCliParserUsage(
                executableName: _parser.ExecutableName,
                logo: _parser.Logo,
                helpText: _parser.HelpText,
                switches: _switches.ToArray(),
                options: _options.ToArray(),
                arguments: _arguments.ToArray(),
                commands: _commands.Select(_ => _.Build()).ToArray(),
                helpSwitches: helpSwitches.Length > 0 ? helpSwitches : null
            );

            LinkCommands(usage.Commands, null);

            return usage;

            void LinkCommands(IEnumerable<CliCommandUsage> commands, CliCommandUsage parentCommand)
            {
                foreach (var command in commands)
                {
                    command.Parent = parentCommand;
                    command.Root = usage;

                    LinkCommands(command.Commands, command);
                }
            }
        }
    }
}