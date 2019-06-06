using System;
using System.Collections.Generic;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class InvalidCliParserResult : ICliParserResult
    {
        private readonly IList<string> _errors;
        private readonly IHelpUsage _usage;

        public InvalidCliParserResult(IList<string> errors, IHelpUsage usage)
        {
            _errors = errors;
            _usage = usage;
        }

        public int Run()
        {
            foreach (var error in _errors)
            {
                Console.Error.WriteLine(error.Red());
            }

            if (_usage != null && _usage.SupportsHelp)
            {
                var cmd = $"{_usage.ExecutableName} {_usage.HelpCommand}".Cyan();
                Console.Error.WriteLine($"Type {cmd} to get help");
            }

            return ExitCodes.InvalidInput;
        }
    }
}