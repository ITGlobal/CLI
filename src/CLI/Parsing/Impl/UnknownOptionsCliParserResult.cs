using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownOptionsCliParserResult : ICliParserResult
    {
        private readonly ITerminal _terminal;
        private readonly string[] _options;
        private readonly IHelpUsage _usage;

        public UnknownOptionsCliParserResult(ITerminal terminal, string[] options, IHelpUsage usage)
        {
            _terminal = terminal;
            _options = options;
            _usage = usage;
        }

        public int Run()
        {
            if (_options.Length == 1)
            {
                _terminal.Stderr.WriteLine($"Unknown flag: {_options[0]}".WithForeground(ConsoleColor.Red));
            }
            else
            {
                _terminal.Stderr.WriteLine(
                    $"Unknown flags: {string.Join(", ", _options)}".WithForeground(ConsoleColor.Red));
            }

            if (_usage.SupportsHelp)
            {
                _terminal.Stderr.WriteLine(
                    (TerminalString)"Type ",
                    $"{_usage.ExecutableName} {_usage.HelpCommand}".WithForeground(ConsoleColor.Cyan),
                    " to get help"
                );
            }

            return ExitCodes.UnknownOptions;
        }
    }
}