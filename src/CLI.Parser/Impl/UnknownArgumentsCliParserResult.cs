using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownArgumentsCliParserResult : ICliParserResult
    {
        private readonly ITerminal _terminal;
        private readonly string[] _arguments;
        private readonly IHelpUsage _usage;

        public UnknownArgumentsCliParserResult(
            ITerminal terminal,
            string[] arguments,
            IHelpUsage usage)
        {
            _terminal = terminal;
            _arguments = arguments;
            _usage = usage;
        }

        public int Run()
        {
            if (_arguments.Length == 1)
            {
                _terminal.Stderr.WriteLine($"Unknown argument: {_arguments[0]}".WithForeground(ConsoleColor.Red));
            }
            else
            {
                _terminal.Stderr.WriteLine(
                    $"Unknown arguments: {string.Join(", ", _arguments)}".WithForeground(ConsoleColor.Red));
            }

            if (_usage.SupportsHelp)
            {
                _terminal.Stderr.WriteLine(
                    (TerminalString)"Type ",
                    $"{_usage.ExecutableName} {_usage.HelpCommand}".WithForeground(ConsoleColor.Cyan),
                    " to get help"
                );
            }

            return ExitCodes.UnknownArguments;
        }
    }
}