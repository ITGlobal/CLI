using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing.Help
{
    partial class HelpPrinterBase
    {
        [PublicAPI]
        protected abstract class UsageInfo
        {
            internal UsageInfo(CliParserUsage usage)
            {
                ParserUsage = usage;
            }

            [CanBeNull]
            public string Logo => ParserUsage.Logo;

            [NotNull]
            public string ExecutableName => ParserUsage.ExecutableName;

            [CanBeNull]
            public abstract string HelpText { get; }

            [NotNull]
            public abstract string[] CommandLine { get; }

            [NotNull]
            public CliParserUsage ParserUsage { get; }

            [CanBeNull]
            public abstract CliCommandUsage CommandUsage { get; }

            [NotNull]
            public abstract OptionInfo[] GlobalOptions { get; }

            public bool HasGlobalOptions => GlobalOptions.Length > 0;

            [NotNull]
            public abstract OptionInfo[] Options { get; }

            public bool HasOptions => Options.Length > 0;

            [NotNull]
            public abstract ArgumentInfo[] Arguments { get; }

            public bool HasArguments => Arguments.Length > 0;

            [NotNull]
            public abstract CommandInfo[] Commands { get; }

            public bool HasCommands => Commands.Length > 0;
        }

        private sealed class RootUsageInfo : UsageInfo
        {
            internal RootUsageInfo(
                CliParserUsage usage,
                OptionInfo[] options,
                ArgumentInfo[] arguments,
                CommandInfo[] commands)
                : base(usage)
            {
                CommandLine = new string[0];
                GlobalOptions = new OptionInfo[0];
                Options = options;
                Arguments = arguments;
                Commands = commands;
            }

            public override string HelpText => ParserUsage.HelpText;
            public override string[] CommandLine { get; }
            public override CliCommandUsage CommandUsage => null;
            public override OptionInfo[] GlobalOptions { get; }
            public override OptionInfo[] Options { get; }
            public override ArgumentInfo[] Arguments { get; }
            public override CommandInfo[] Commands { get; }
        }

        private sealed class CommandUsageInfo : UsageInfo
        {
            internal CommandUsageInfo(
                CliCommandUsage usage,
                string[] commandLine,
                OptionInfo[] globalOptions,
                OptionInfo[] options,
                ArgumentInfo[] arguments,
                CommandInfo[] commands)
                : base(usage.Root)
            {
                CommandUsage = usage;
                CommandLine = commandLine;
                GlobalOptions = globalOptions;
                Options = options;
                Arguments = arguments;
                Commands = commands;
            }
            
            public override CliCommandUsage CommandUsage { get; }

            public override string HelpText => CommandUsage.HelpText;
            public override string[] CommandLine { get; }
            public override OptionInfo[] GlobalOptions { get; }
            public override OptionInfo[] Options { get; }
            public override ArgumentInfo[] Arguments { get; }
            public override CommandInfo[] Commands { get; }
        }

        private RootUsageInfo GetRootUsageInfo(CliParserUsage usage)
        {
            var options = usage.Switches
                .Where(_ => !_.IsHidden)
                .Select(GetSwitchInfo)
                .Concat(usage.Options.Where(_ => !_.IsHidden).Select(GetOptionInfo))
                .OrderBy(_ => _.DisplayOrder)
                .ThenBy(_ => _.Key)
                .ToArray();

            var arguments = usage.Arguments
                .Where(_ => !_.IsHidden)
                .Select(GetArgumentInfo)
                .OrderBy(_ => _.DisplayOrder)
                .ThenBy(_ => _.Key)
                .ToArray();

            var commands = usage.Commands
                .Where(_ => !_.IsHidden)
                .Select(GetCommandInfo)
                .OrderBy(_ => _.DisplayOrder)
                .ThenBy(_ => _.Key)
                .ToArray();

            var info = new RootUsageInfo(usage, options, arguments, commands);
            return info;
        }

        private CommandUsageInfo GetCommandUsageInfo(CliCommandUsage usage)
        {
            var options = new List<CliOptionUsage>();
            var switches = new List<CliSwitchUsage>();
            var commandLine = new List<string>();

            var u = usage;
            while (u != null)
            {
                commandLine.Add(u.Names[0]);

                foreach (var o in u.Options)
                {
                    options.Add(o);
                }

                foreach (var s in u.Switches)
                {
                    switches.Add(s);
                }

                u = u.Parent;
            }

            commandLine.Reverse();

            var globalOptions = usage.Root.Switches
                .Where(_ => !_.IsHidden)
                .Select(GetSwitchInfo)
                .Concat(usage.Root.Options.Where(_ => !_.IsHidden).Select(GetOptionInfo))
                .OrderBy(_ => _.DisplayOrder)
                .ThenBy(_ => _.Key)
                .ToArray();

            var commandOptions = switches
                .Where(_ => !_.IsHidden)
                .Select(GetSwitchInfo)
                .Concat(options.Where(_ => !_.IsHidden).Select(GetOptionInfo))
                .OrderBy(_ => _.DisplayOrder)
                .ThenBy(_ => _.Key)
                .ToArray();

            var commandArguments = usage.Arguments
                .Where(_ => !_.IsHidden)
                .Select(GetArgumentInfo)
                .OrderBy(_ => _.DisplayOrder)
                .ThenBy(_ => _.Key)
                .ToArray();

            var subcommands = usage.Commands
                .Where(_ => !_.IsHidden)
                .Select(GetCommandInfo)
                .OrderBy(_ => _.DisplayOrder)
                .ThenBy(_ => _.Key)
                .ToArray();

            var info = new CommandUsageInfo(
                usage: usage,
                commandLine: commandLine.ToArray(),
                globalOptions: globalOptions,
                options: commandOptions,
                arguments: commandArguments,
                commands: subcommands
            );
            return info;
        }
    }
}
