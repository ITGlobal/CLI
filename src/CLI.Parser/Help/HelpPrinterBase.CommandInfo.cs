using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    partial class HelpPrinterBase
    {
        [PublicAPI]
        protected sealed class CommandInfo
        {
            internal CommandInfo(CliCommandUsage usage)
            {
                Usage = usage;
                DisplayOrder = usage.DisplayOrder;
                Key = usage.Names.OrderByDescending(_ => _.Length).First().TrimStart('-').ToLowerInvariant();
                Name = string.Join(", ", usage.Names);
                Description = usage.HelpText ?? "";
            }

            [NotNull]
            public CliCommandUsage Usage { get; }

            [NotNull]
            public string Key { get; }

            public int DisplayOrder { get; }

            [NotNull]
            public string Name { get; }

            [NotNull]
            public string Description { get; }
        }

        private CommandInfo GetCommandInfo(CliCommandUsage usage)
        {
            var info = new CommandInfo(usage);
            return info;
        }
    }
}
