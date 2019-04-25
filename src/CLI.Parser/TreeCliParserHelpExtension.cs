using System;
using System.Collections.Generic;
using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using ITGlobal.CommandLine.Table;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Help extension for <see cref="ITreeCliParser"/>
    /// </summary>
    [PublicAPI]
    public static class TreeCliParserHelpExtension
    {
        /// <summary>
        ///     Adds help support to parser
        /// </summary>
        [PublicAPI]
        public static void EnableHelp(
            [NotNull] this ITreeCliParser parser,
            string[] switchNames = null)
        {
            switchNames = switchNames ?? new[] { "help", "h", "?" };

            var helpSwitches = new CliSwitch[switchNames.Length];
            for (var i = 0; i < switchNames.Length; i++)
            {
                CliSwitch sw;

                var switchName = switchNames[i];
                if (switchName.Length == 1)
                {
                    sw = parser.Switch(switchName[0]);
                }
                else
                {
                    sw = parser.Switch(switchName);
                }

                sw.HelpText("Print help and exit");
                sw.DisplayOrder(1000);
                sw.HelpSwitch();

                if (i != 0)
                {
                    sw.Hidden();
                }
                helpSwitches[i] = sw;
            }

            parser.BeforeExecute(ctx =>
            {
                if (!helpSwitches.Any(_ => _.IsSet))
                {
                    return;
                }

                PrintUsage(parser, ctx);

                ctx.SuppressLogo();
                ctx.Break();
            });
        }

        internal static void PrintUsage(ITreeCliParser parser, ICliContext ctx)
        {
            if (ctx.Command != null)
            {
                PrintUsage(ctx.Command.GetUsage());
            }
            else
            {
                PrintUsage(parser.GetUsage());
            }
        }

        private static void PrintUsage(TreeCliParserUsage usage)
        {
            if (!string.IsNullOrEmpty(usage.Logo))
            {
                Console.Error.WriteLine(usage.Logo.Cyan());
                Console.Error.WriteLine();
            }

            var hasOptions = usage.Arguments.Count(_ => !_.IsHidden) > 0;
            var hasSwitches = usage.Switches.Count(_ => !_.IsHidden) > 0;
            var hasArguments = usage.Arguments.Count(_ => !_.IsHidden) > 0;
            var hasCommands = usage.Commands.Count(_ => !_.IsHidden) > 0;

            if (!string.IsNullOrEmpty(usage.HelpText))
            {
                Console.Error.WriteLine(usage.HelpText);
                Console.Error.WriteLine();
            }

            Console.Error.WriteLine("USAGE".White());
            Console.Error.Write("   ");
            Console.Error.Write(usage.ExecutableName.Yellow());
            if (hasOptions || hasSwitches)
            {
                Console.Error.Write(" [OPTIONS]");
            }

            if (hasCommands)
            {
                Console.Error.Write(" COMMAND");
            }

            foreach (var argument in usage.Arguments.Where(_ => !_.IsHidden).OrderBy(_ => _.Position))
            {
                Console.Error.Write(" ");
                if (!argument.IsRequired)
                {
                    Console.Error.Write("[");
                }

                Console.Error.Write(argument.Name.ToUpperInvariant());

                if (argument.IsRepeatable)
                {
                    Console.Error.Write("...");
                }

                if (!argument.IsRequired)
                {
                    Console.Error.Write("]");
                }
            }
            Console.Error.WriteLine();
            Console.Error.WriteLine();

            if (hasOptions || hasSwitches)
            {
                var options = usage.Switches.Where(_ => !_.IsHidden).Select(OptionInfo.Create)
                    .Concat(usage.Options.Where(_ => !_.IsHidden).Select(OptionInfo.Create))
                    .OrderBy(_ => _.DisplayOrder)
                    .ThenBy(_ => _.Key);

                Console.Error.WriteLine("OPTIONS".White());
                var table = TerminalTable.Create(options, renderer: TableRenderer.Plain(drawHeaders: false));
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description);
                table.Draw();
            }

            if (hasArguments)
            {
                var arguments = usage.Arguments.Where(_ => !_.IsHidden)
                    .Select(ArgumentInfo.Create)
                    .OrderBy(_ => _.DisplayOrder)
                    .ThenBy(_ => _.Key);

                Console.Error.WriteLine("ARGUMENTS".White());
                var table = TerminalTable.Create(arguments, renderer: TableRenderer.Plain(drawHeaders: false));
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description);
                table.Draw();
            }

            if (hasCommands)
            {
                Console.Error.WriteLine("COMMANDS".White());
                var table = TerminalTable.Create(
                    CommandInfo.Enumerate(usage.Commands)
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: TableRenderer.Plain(drawHeaders: false)
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description);
                table.Draw();
            }
        }

        private static void PrintUsage(CliCommandUsage usage)
        {
            var rootUsage = usage.Root;

            if (!string.IsNullOrEmpty(rootUsage.Logo))
            {
                Console.Error.WriteLine(rootUsage.Logo.Cyan());
                Console.Error.WriteLine();
            }

            var options = new List<CliOptionUsage>();
            var switches = new List<CliSwitchUsage>();

            var u = usage;
            while (u != null)
            {
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

            var hasGlobalOptions = usage.Root.Options.Count(_ => !_.IsHidden) > 0;
            var hasGlobalSwitches = usage.Root.Switches.Count(_ => !_.IsHidden) > 0;
            var hasOptions = options.Count(_ => !_.IsHidden) > 0;
            var hasSwitches = switches.Count(_ => !_.IsHidden) > 0;
            var hasArguments = usage.Arguments.Count(_ => !_.IsHidden) > 0;

            var hasCommands = usage.Commands.Count(_ => !_.IsHidden) > 0;

            if (!string.IsNullOrEmpty(usage.HelpText))
            {
                Console.Error.WriteLine(usage.HelpText);
                Console.Error.WriteLine();
            }

            Console.Error.WriteLine("USAGE".White());
            Console.Error.Write("   ");
            Console.Error.Write(rootUsage.ExecutableName.Yellow());
            Console.Error.Write($" {string.Join(" ", usage.GetName())}");

            if (hasGlobalOptions || hasGlobalSwitches || hasOptions || hasSwitches)
            {
                Console.Error.Write(" [OPTIONS]");
            }

            if (hasCommands)
            {
                Console.Error.Write(" COMMAND");
            }

            foreach (var argument in usage.Arguments.Where(_ => !_.IsHidden).OrderBy(_ => _.Position))
            {
                Console.Error.Write(" ");
                if (!argument.IsRequired)
                {
                    Console.Error.Write("[");
                }

                Console.Error.Write(argument.Name.ToUpperInvariant());

                if (argument.IsRepeatable)
                {
                    Console.Error.Write("...");
                }

                if (!argument.IsRequired)
                {
                    Console.Error.Write("]");
                }
            }
            Console.Error.WriteLine();
            Console.Error.WriteLine();

            if (hasGlobalOptions || hasGlobalSwitches)
            {
                Console.Error.WriteLine("GLOBAL OPTIONS".White());
                var table = TerminalTable.Create(
                    usage.Root.Switches
                        .Where(_ => !_.IsHidden).Select(OptionInfo.Create)
                        .Concat(usage.Root.Options.Where(_ => !_.IsHidden).Select(OptionInfo.Create))
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: TableRenderer.Plain(drawHeaders: false)
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description);
                table.Draw();
            }

            if (hasOptions || hasSwitches)
            {
                Console.Error.WriteLine("OPTIONS".White());
                var table = TerminalTable.Create(
                    switches.Where(_ => !_.IsHidden).Select(OptionInfo.Create)
                        .Concat(usage.Options.Where(_ => !_.IsHidden).Select(OptionInfo.Create))
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: TableRenderer.Plain(drawHeaders: false)
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description);
                table.Draw();
            }

            if (hasArguments)
            {
                Console.Error.WriteLine("ARGUMENTS".White());
                var table = TerminalTable.Create(
                    usage.Arguments.Where(_ => !_.IsHidden)
                        .Select(ArgumentInfo.Create)
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: TableRenderer.Plain(drawHeaders: false)
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description);
                table.Draw();
            }

            if (hasCommands)
            {
                Console.Error.WriteLine("COMMANDS".White());
                var table = TerminalTable.Create(
                    CommandInfo.Enumerate(usage.Commands)
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: TableRenderer.Plain(drawHeaders: false)
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description);
                table.Draw();
            }
        }
    }
}