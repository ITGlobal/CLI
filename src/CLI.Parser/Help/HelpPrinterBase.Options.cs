using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    partial class HelpPrinterBase
    {
        [PublicAPI]
        protected sealed class OptionInfo
        {
            internal OptionInfo(CliSwitchUsage usage, string name, string description)
            {
                DisplayOrder = usage.DisplayOrder;
                Key = usage.Names.OrderByDescending(_ => _.Length).First().TrimStart('-').ToLowerInvariant();
                Name = name;
                Switch = usage;
                Description = description;
            }

            internal OptionInfo(CliOptionUsage usage, string name, string description)
            {
                DisplayOrder = usage.DisplayOrder;
                Key = usage.Names.OrderByDescending(_ => _.Length).First().TrimStart('-').ToLowerInvariant();
                Name = name;
                Option = usage;
                Description = description;
            }

            [NotNull]
            public string Key { get; }

            public int DisplayOrder { get; }

            [NotNull]
            public string Name { get; }

            [NotNull]
            public string Description { get; }

            [CanBeNull]
            public CliSwitchUsage Switch { get; }

            [CanBeNull]
            public CliOptionUsage Option { get; }
        }

        [NotNull]
        protected virtual string GetSwitchName([NotNull] CliSwitchUsage usage)
            => string.Join(", ", usage.Names);

        [NotNull]
        protected abstract string GetSwitchDescription([NotNull] CliSwitchUsage usage);

        [NotNull]
        protected virtual string GetOptionName([NotNull] CliOptionUsage usage)
            => string.Join(", ", usage.Names) + " <value>";

        [NotNull]
        protected abstract string GetOptionDescription([NotNull] CliOptionUsage usage);

        private OptionInfo GetSwitchInfo(CliSwitchUsage usage)
        {
            var name = GetSwitchName(usage);
            var description = GetSwitchDescription(usage);
            var info = new OptionInfo(usage, name, description);
            return info;
        }

        private OptionInfo GetOptionInfo(CliOptionUsage usage)
        {
            var name = GetOptionName(usage);
            var description = GetOptionDescription(usage);
            var info = new OptionInfo(usage, name, description);
            return info;
        }
    }
}
