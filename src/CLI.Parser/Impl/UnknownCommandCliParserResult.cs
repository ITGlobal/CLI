using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownCommandCliParserResult : ICliParserResult
    {
        private readonly string _commandName;
        private readonly string[] _commandNameCandidates;
        private readonly IHelpUsage _usage;

        public UnknownCommandCliParserResult(string commandName, string[] commandNameCandidates, IHelpUsage usage)
        {
            _commandName = commandName;
            _commandNameCandidates = commandNameCandidates;
            _usage = usage;
        }

        public int Run()
        {
            Console.Error.WriteLine($"\"{_commandName.Red()}\" is not a {_usage.ExecutableName} command.");

            switch (_commandNameCandidates.Length)
            {
                case 0:
                    break;

                case 1:
                    Console.Error.WriteLine();
                    Console.Error.WriteLine($"The most similar command is");
                    Console.Error.WriteLine($"\t{_commandNameCandidates[0].Cyan()}");

                    break;

                default:
                    Console.Error.WriteLine();
                    Console.Error.WriteLine($"The most similar commands are");
                    foreach (var name in _commandNameCandidates)
                    {
                        Console.Error.WriteLine($"\t{name.Cyan()}");
                    }

                    break;
            }

            if (_usage.SupportsHelp)
            {
                var cmd = $"{_usage.ExecutableName} {_usage.HelpCommand}".Cyan();
                Console.Error.WriteLine();
                Console.Error.WriteLine($"Type {cmd} to get help");
            }

            return ExitCodes.UnknownArguments;
        }
    }
}