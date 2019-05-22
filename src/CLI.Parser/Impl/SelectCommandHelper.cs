using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal static class SelectCommandHelper
    {
        public static (ICliCommand Command, string[] Candidates) SelectCommand(
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
                    return (command, null);
                }
            }

            var candidates = commands
                .SelectMany(_ => _.EnumerateCommandNames())
                .Select(s => (Name: s, Distance: LevenshteinDistance.Calculate(s, commandName)))
                .Where(_ => _.Distance <= 3)
                .OrderBy(_ => _.Distance)
                .Select(_ => _.Name)
                .Take(3)
                .ToArray();

            return (null, candidates);
        }
    };
}
