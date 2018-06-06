using System;
using System.Collections.Generic;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class InvalidCliParserResult : ICliParserResult
    {
        private readonly ITerminal _terminal;
        private readonly IList<string> _errors;
        private readonly IHelpUsage _usage;

        public InvalidCliParserResult(ITerminal terminal, IList<string> errors, IHelpUsage usage)
        {
            _terminal = terminal;
            _errors = errors;
            _usage = usage;
        }

        public int Run()
        {
            foreach (var error in _errors)
            {
                _terminal.Stderr.WriteLine(error.WithForeground(ConsoleColor.Red));
            }

            if (_usage.SupportsHelp)
            {
                _terminal.Stderr.WriteLine(
                    (TerminalString)"Type ",
                    $"{_usage.ExecutableName} {_usage.HelpCommand}".WithForeground(ConsoleColor.Cyan),
                    " to get help"
                );
            }

            return ExitCodes.InvalidInput;
        }
    }
}