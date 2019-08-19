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
                Console.Out.WriteLine(usage.Logo.Cyan());
                Console.Out.WriteLine();
            }

            var hasOptions = usage.Arguments.Count(_ => !_.IsHidden) > 0;
            var hasSwitches = usage.Switches.Count(_ => !_.IsHidden) > 0;
            var hasArguments = usage.Arguments.Count(_ => !_.IsHidden) > 0;
            var hasCommands = usage.Commands.Count(_ => !_.IsHidden) > 0;

            if (!string.IsNullOrEmpty(usage.HelpText))
            {
                Console.Out.WriteLine(usage.HelpText.White());
                Console.Out.WriteLine();
            }

            Console.Out.WriteLine("USAGE".White());
            Console.Out.Write("   ");
            Console.Out.Write(usage.ExecutableName.Cyan());
            if (hasOptions || hasSwitches)
            {
                Console.Out.Write(" [OPTIONS]".White());
            }

            if (hasCommands)
            {
                Console.Out.Write(" COMMAND".Yellow());
            }

            foreach (var argument in usage.Arguments.Where(_ => !_.IsHidden).OrderBy(_ => _.Position))
            {
                Console.Out.Write(" ");
                if (!argument.IsRequired)
                {
                    Console.Out.Write("[".White());
                    Console.Out.Write(argument.Name.ToUpperInvariant().White());
                }
                else
                {
                    Console.Out.Write(argument.Name.ToUpperInvariant().Yellow());
                }

                if (argument.IsRepeatable)
                {
                    Console.Out.Write("...".White());
                }

                if (!argument.IsRequired)
                {
                    Console.Out.Write("]".White());
                }
            }
            Console.Out.WriteLine();
            Console.Out.WriteLine();

            var tableRenderer = TableRenderer.Plain(PlainTableStyle.Create(drawHeaders: false));

            if (hasOptions || hasSwitches)
            {
                var options = usage.Switches.Where(_ => !_.IsHidden).Select(OptionInfo.Create)
                    .Concat(usage.Options.Where(_ => !_.IsHidden).Select(OptionInfo.Create))
                    .OrderBy(_ => _.DisplayOrder)
                    .ThenBy(_ => _.Key);

                Console.Out.WriteLine("OPTIONS".White());
                var table = TerminalTable.Create(options, renderer: tableRenderer);
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (hasArguments)
            {
                var arguments = usage.Arguments.Where(_ => !_.IsHidden)
                    .Select(ArgumentInfo.Create)
                    .OrderBy(_ => _.DisplayOrder)
                    .ThenBy(_ => _.Key);

                Console.Out.WriteLine("ARGUMENTS".White());
                var table = TerminalTable.Create(arguments, renderer: tableRenderer);
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (hasCommands)
            {
                Console.Out.WriteLine("COMMANDS".White());
                var table = TerminalTable.Create(
                    CommandInfo.Enumerate(usage.Commands)
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: tableRenderer
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }
        }

        private static void PrintUsage(CliCommandUsage usage)
        {
            var rootUsage = usage.Root;

            if (!string.IsNullOrEmpty(rootUsage.Logo))
            {
                Console.Out.WriteLine(rootUsage.Logo.Cyan());
                Console.Out.WriteLine();
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
                Console.Out.WriteLine(usage.HelpText.White());
                Console.Out.WriteLine();
            }

            Console.Out.WriteLine("USAGE".White());
            Console.Out.Write("   ");
            Console.Out.Write(rootUsage.ExecutableName.Cyan());
            Console.Out.Write($" {string.Join(" ", usage.GetName())}");

            if (hasGlobalOptions || hasGlobalSwitches || hasOptions || hasSwitches)
            {
                Console.Out.Write(" [OPTIONS]".White());
            }

            if (hasCommands)
            {
                Console.Out.Write(" COMMAND".Yellow());
            }

            foreach (var argument in usage.Arguments.Where(_ => !_.IsHidden).OrderBy(_ => _.Position))
            {
                Console.Out.Write(" ");
                if (!argument.IsRequired)
                {
                    Console.Out.Write("[".White());
                    Console.Out.Write(argument.Name.ToUpperInvariant().White());
                }
                else
                {
                    Console.Out.Write(argument.Name.ToUpperInvariant().Yellow());
                }

                if (argument.IsRepeatable)
                {
                    Console.Out.Write("...".White());
                }

                if (!argument.IsRequired)
                {
                    Console.Out.Write("]".White());
                }
            }
            Console.Out.WriteLine();
            Console.Out.WriteLine();

            var tableRenderer = TableRenderer.Plain(PlainTableStyle.Create(drawHeaders: false));

            if (hasGlobalOptions || hasGlobalSwitches)
            {
                Console.Out.WriteLine("GLOBAL OPTIONS".White());
                var table = TerminalTable.Create(
                    usage.Root.Switches
                        .Where(_ => !_.IsHidden).Select(OptionInfo.Create)
                        .Concat(usage.Root.Options.Where(_ => !_.IsHidden).Select(OptionInfo.Create))
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: tableRenderer
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (hasOptions || hasSwitches)
            {
                Console.Out.WriteLine("OPTIONS".White());
                var table = TerminalTable.Create(
                    switches.Where(_ => !_.IsHidden).Select(OptionInfo.Create)
                        .Concat(usage.Options.Where(_ => !_.IsHidden).Select(OptionInfo.Create))
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: tableRenderer
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (hasArguments)
            {
                Console.Out.WriteLine("ARGUMENTS".White());
                var table = TerminalTable.Create(
                    usage.Arguments.Where(_ => !_.IsHidden)
                        .Select(ArgumentInfo.Create)
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: tableRenderer
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (hasCommands)
            {
                Console.Out.WriteLine("COMMANDS".White());
                var table = TerminalTable.Create(
                    CommandInfo.Enumerate(usage.Commands)
                        .OrderBy(_ => _.DisplayOrder)
                        .ThenBy(_ => _.Key),
                    renderer: tableRenderer
                );
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }
        }
    }
}