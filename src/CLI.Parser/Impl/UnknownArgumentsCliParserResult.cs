using System;
using System.Collections.Generic;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownArgumentsCliParserResult : ICliParserResult
    {
        private readonly IList<string> _arguments;
        private readonly IHelpUsage _usage;

        public UnknownArgumentsCliParserResult(IList<string> arguments, IHelpUsage usage)
        {
            _arguments = arguments;
            _usage = usage;
        }

        public int Run()
        {
            if (_arguments.Count == 1)
            {
                Console.Error.WriteLine($"Unknown argument: {_arguments[0]}".Red());
            }
            else
            {
                Console.Error.WriteLine($"Unknown arguments: {string.Join(", ", _arguments)}".Red());
            }

            if (_usage.SupportsHelp)
            {
                var cmd = $"{_usage.ExecutableName} {_usage.HelpCommand}".Cyan();
                Console.Error.WriteLine($"Type {cmd} to get help");
            }

            return ExitCodes.UnknownArguments;
        }
    }
}