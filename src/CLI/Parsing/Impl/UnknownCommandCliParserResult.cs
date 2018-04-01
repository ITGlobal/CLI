using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownCommandCliParserResult : ICliParserResult
    {
        private readonly ITerminal _terminal;
        private readonly string _commandName;
        private readonly IHelpUsage _usage;

        public UnknownCommandCliParserResult(
            ITerminal terminal,
            string commandName,
            IHelpUsage usage)
        {
            _terminal = terminal;
            _commandName = commandName;
            _usage = usage;
        }

        public int Run()
        {
            _terminal.Stderr.WriteLine($"Unknown command: {_commandName}".WithForeground(ConsoleColor.Red));

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