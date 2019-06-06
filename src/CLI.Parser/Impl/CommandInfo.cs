using System.Collections.Generic;
using System.Linq;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class CommandInfo
    {
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static IEnumerable<CommandInfo> Enumerate(IEnumerable<CliCommandUsage> commands)
        {
            foreach (var u in commands.Where(_ => !_.IsHidden))
            {
                yield return new CommandInfo
                {
                    DisplayOrder = u.DisplayOrder,
                    Key = u.Names.OrderByDescending(_ => _.Length).First().TrimStart('-').ToLowerInvariant(),
                    Name = string.Join(", ", u.Names),
                    Description = u.HelpText
                };
            }
        }
    }
}