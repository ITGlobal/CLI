using System;
using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using ITGlobal.CommandLine.Table;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Help extension for <see cref="ISimpleCliParser"/>
    /// </summary>
    [PublicAPI]
    public static class SimpleCliParserHelpExtension
    {
        /// <summary>
        ///     Adds help support to parser
        /// </summary>
        [PublicAPI]
        public static void EnableHelp(
            [NotNull] this ISimpleCliParser parser,
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

                var usage = parser.GetUsage();
                PrintUsage(usage);
                ctx.SuppressLogo();
                ctx.Break();
            });
        }

        private static void PrintUsage(SimpleCliParserUsage usage)
        {
            if (!string.IsNullOrEmpty(usage.Logo))
            {
                Console.Out.WriteLine(usage.Logo.Cyan());
                Console.Out.WriteLine();
            }

            var hasOptions = usage.Arguments.Count(_ => !_.IsHidden) > 0;
            var hasSwitches = usage.Switches.Count(_ => !_.IsHidden) > 0;
            var hasArguments = usage.Arguments.Count(_ => !_.IsHidden) > 0;

            if (!string.IsNullOrEmpty(usage.HelpText))
            {
                Console.Out.WriteLine(usage.HelpText.White());
                Console.Out.WriteLine();
            }

            Console.Out.WriteLine("USAGE".White());
            Console.Out.Write("   ");
            Console.Out.Write(usage.ExecutableName.Yellow());
            if (hasOptions || hasSwitches)
            {
                Console.Out.Write(" [OPTIONS]".White());
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
                table.Column("", _ => _.Name);
                table.Column("", _ => _.Description.White());
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
                table.Column("", _ => _.Description.White());
                table.Draw(Console.Out);
            }
        }
    }
}