using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal static class SelectCommandHelper
    {
        public readonly struct SelectCommandResult
        {
            public SelectCommandResult(ICliCommand command, string[] candidates)
            {
                Command = command;
                Candidates = candidates;
            }

            public readonly ICliCommand Command;
            public readonly string[] Candidates;

            public void Deconstruct(out ICliCommand command, out string[] candidates)
            {
                command = Command;
                candidates = Candidates;
            }
        }

        public static SelectCommandResult SelectCommand(
            RawCommandLine commandLine,
            IList<CliCommand> commands,
            string commandName
        )
        {
            foreach (var c in commands)
            {
                if (c.MatchesCommandName(commandName))
                {
                    var command = c.SelectCommand(commandLine);
                    return new SelectCommandResult(command, null);
                }
            }

            var candidates = commands
                .SelectMany(_ => _.EnumerateCommandNames())
                .Select(s => new {Name = s, Distance = LevenshteinDistance.Calculate(s, commandName)})
                .Where(_ => _.Distance <= 3)
                .OrderBy(_ => _.Distance)
                .Select(_ => _.Name)
                .Take(3)
                .ToArray();

            return new SelectCommandResult(null, candidates);
        }
    }
}
