using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class CliCommandUsageBuilder : ICliCommandUsageBuilder
    {
        private readonly TreeCliParserUsageBuilder _rootBuilder;
        private readonly string[] _names;
        private readonly string _helpText;
        private readonly bool _isHidden;
        private readonly int _displayOrder;

        private readonly List<CliSwitchUsage> _switches = new List<CliSwitchUsage>();
        private readonly List<CliOptionUsage> _options = new List<CliOptionUsage>();
        private readonly List<CliArgumentUsage> _arguments = new List<CliArgumentUsage>();
        private readonly List<CliCommandUsageBuilder> _commands = new List<CliCommandUsageBuilder>();

        internal CliCommandUsageBuilder(
            TreeCliParserUsageBuilder rootBuilder,
            string[] names,
            string helpText, 
            bool isHidden, 
            int displayOrder)
        {
            _rootBuilder = rootBuilder;
            _names = names;
            _helpText = helpText;
            _isHidden = isHidden;
            _displayOrder = displayOrder;
        }

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
            var builder = new CliCommandUsageBuilder(_rootBuilder, names, helpText, isHidden, displayOrder);
            _commands.Add(builder);
            return builder;
        }

        public string[] GetOptionNames(char? shortName, string longName)
            => _rootBuilder.GetOptionNames(shortName, longName);

        public CliCommandUsage Build()
        {
            return new CliCommandUsage(
                _names,
                _helpText,
                _isHidden,
                _displayOrder,
                _switches.ToArray(),
                _options.ToArray(),
                _arguments.ToArray(),
                _commands.Select(_ => _.Build()).ToArray()
            );
        }
    }
}