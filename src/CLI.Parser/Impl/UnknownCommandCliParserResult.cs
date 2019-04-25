using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownCommandCliParserResult : ICliParserResult
    {
        private readonly string _commandName;
        private readonly IHelpUsage _usage;

        public UnknownCommandCliParserResult(string commandName, IHelpUsage usage)
        {
            _commandName = commandName;
            _usage = usage;
        }

        public int Run()
        {
            Console.Error.WriteLine($"Unknown command: {_commandName}".Red());

            if (_usage.SupportsHelp)
            {
                var cmd = $"{_usage.ExecutableName} {_usage.HelpCommand}".Cyan();
                Console.Error.WriteLine($"Type {cmd} to get help");
            }

            return ExitCodes.UnknownArguments;
        }
    }
}