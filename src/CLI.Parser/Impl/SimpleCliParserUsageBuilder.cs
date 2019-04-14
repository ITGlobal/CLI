using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class SimpleCliParserUsageBuilder : IUsageBuilder
    {
        private readonly SimpleCliParser _parser;

        private readonly List<CliSwitchUsage> _switches = new List<CliSwitchUsage>();
        private readonly List<CliOptionUsage> _options = new List<CliOptionUsage>();
        private readonly List<CliArgumentUsage> _arguments = new List<CliArgumentUsage>();

        internal SimpleCliParserUsageBuilder(SimpleCliParser parser)
        {
            _parser = parser;
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

        public string[] GetOptionNames(char? shortName, string longName)
            => CommandLineTokenizer.GetOptionNames(_parser.Flags, shortName, longName);

        public SimpleCliParserUsage BuildSimpleCliParserUsage()
        {
            var helpSwitches = _switches.Where(_ => _.IsHelpSwitch).SelectMany(_ => _.Names).ToArray();
            return new SimpleCliParserUsage(
                _parser.Terminal,
                _parser.ExecutableName,
                _parser.Logo,
                _parser.HelpText,
                _switches.ToArray(),
                _options.ToArray(),
                _arguments.ToArray(),
                helpSwitches.Length > 0 ? helpSwitches : null
            );
        }
    }
}