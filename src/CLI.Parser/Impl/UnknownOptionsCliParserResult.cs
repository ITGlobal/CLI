using System;
using System.Collections.Generic;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownOptionsCliParserResult : ICliParserResult
    {
        private readonly IList<string> _options;
        private readonly IHelpUsage _usage;

        public UnknownOptionsCliParserResult(IList<string> options, IHelpUsage usage)
        {
            _options = options;
            _usage = usage;
        }

        public int Run()
        {
            if (_options.Count == 1)
            {
                Console.Error.WriteLine($"Unknown flag: {_options[0]}".Red());
                Console.Error.WriteLine($"Unknown flag: {_options[0].Red()}");
            }
            else
            {
                Console.Error.WriteLine($"Unknown flags: {string.Join(", ", _options)}".Red());
            }

            if (_usage != null && _usage.SupportsHelp)
            {
                var cmd = $"{_usage.ExecutableName} {_usage.HelpCommand}".Cyan();
                Console.Error.WriteLine($"Type {cmd} to get help");
            }

            return ExitCodes.UnknownOptions;
        }
    }
}