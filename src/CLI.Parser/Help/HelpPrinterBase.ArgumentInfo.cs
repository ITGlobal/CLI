using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    partial class HelpPrinterBase
    {
        [PublicAPI]
        protected sealed class ArgumentInfo
        {
            internal ArgumentInfo(CliArgumentUsage usage, string name, string description)
            {
                DisplayOrder = usage.Position;
                Key = "";
                Name = name;
                Description = description;

                Argument = usage;
            }

            [NotNull]
            public string Key { get; }

            public int DisplayOrder { get; }
            
            [NotNull]
            public string Name { get; }

            [NotNull]
            public string Description { get;  }

            [NotNull]
            public CliArgumentUsage Argument { get; }
        }

        [NotNull]
        protected virtual string GetArgumentName([NotNull] CliArgumentUsage usage) 
            => usage.Name.ToUpperInvariant();

        [NotNull]
        protected abstract string GetArgumentDescription([NotNull] CliArgumentUsage usage);

        private ArgumentInfo GetArgumentInfo(CliArgumentUsage usage)
        {
            var name = GetArgumentName(usage);
            var description = GetArgumentDescription(usage);
            var info = new ArgumentInfo(usage, name, description);
            return info;
        }
    }
}
