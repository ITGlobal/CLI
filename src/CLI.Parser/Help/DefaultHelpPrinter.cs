using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITGlobal.CommandLine.Table;

namespace ITGlobal.CommandLine.Parsing.Help
{
    internal sealed class DefaultHelpPrinter : HelpPrinterBase
    {
        protected override void Print(UsageInfo info, bool isImplicitHelp)
        {
            if (!string.IsNullOrEmpty(info.HelpText))
            {
                Console.Out.WriteLine(info.HelpText.White());
                Console.Out.WriteLine();
            }

            Console.Out.WriteLine("USAGE".White());
            Console.Out.Write("   ");
            Console.Out.Write(info.ExecutableName.Cyan());
            Console.Out.Write($" {string.Join(" ", info.CommandLine)}");

            if (info.HasGlobalOptions || info.HasOptions || info.HasArguments)
            {
                Console.Out.Write(" [OPTIONS]".White());
            }

            if (info.HasCommands)
            {
                Console.Out.Write(" COMMAND".Yellow());
            }

            foreach (var argument in info.Arguments)
            {
                Console.Out.Write(" ");
                if (!argument.Argument.IsRequired)
                {
                    Console.Out.Write("[".White());
                    Console.Out.Write(argument.Name.ToUpperInvariant().White());
                }
                else
                {
                    Console.Out.Write(argument.Name.ToUpperInvariant().Yellow());
                }

                if (argument.Argument.IsRepeatable)
                {
                    Console.Out.Write("...".White());
                }

                if (!argument.Argument.IsRequired)
                {
                    Console.Out.Write("]".White());
                }
            }
            Console.Out.WriteLine();
            Console.Out.WriteLine();

            var tableRenderer = TableRenderer.Plain(PlainTableStyle.Create(drawHeaders: false));

            if (info.HasGlobalOptions)
            {
                Console.Out.WriteLine("GLOBAL OPTIONS".White());
                var table = TerminalTable.Create(info.GlobalOptions, tableRenderer);
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (info.HasOptions)
            {
                Console.Out.WriteLine("OPTIONS".White());
                var table = TerminalTable.Create(info.Options, tableRenderer);
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (info.HasArguments)
            {
                Console.Out.WriteLine("ARGUMENTS".White());
                var table = TerminalTable.Create(info.Arguments, tableRenderer);
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }

            if (info.HasCommands)
            {
                Console.Out.WriteLine("COMMANDS".White());
                var table = TerminalTable.Create(info.Commands, tableRenderer);
                table.Column("", _ => "  ");
                table.Column("", _ => _.Name.Yellow());
                table.Column("", _ => (_.Description ?? "").White());
                table.Draw(Console.Out);
            }
        }

        protected override string GetSwitchDescription(CliSwitchUsage usage)
        {
            var sb = new StringBuilder();
            sb.Append(usage.HelpText);
            if (usage.IsRepeatable)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append("(repeatable)");
            }

            return sb.ToString();
        }

        protected override string GetOptionDescription(CliOptionUsage usage)
        {
            var sb = new StringBuilder();
            sb.Append(usage.HelpText);

            var descr = string.Join(", ", EnumerateOptionDescriptions(usage));
            if (!string.IsNullOrEmpty(descr))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append("(");
                sb.Append(descr);
                sb.Append(")");
            }

            return sb.ToString();

            static IEnumerable<string> EnumerateOptionDescriptions(CliOptionUsage usage)
            {
                switch (usage.Type)
                {
                    case EnumCliTypeInfo i when i.ValidValues.Length > 0:
                        yield return $"valid values {string.Join("/", from v in i.ValidValues select AnsiStringFactory.Yellow((string) v))}";
                        break;
                    case StringCliTypeInfo _:
                        break;
                    default:
                        yield return usage.Type.Name;
                        break;
                }

                if (usage.IsRequired)
                {
                    yield return "required";
                }

                if (usage.IsRepeatable)
                {
                    yield return "repeatable";
                }

                if (usage.DefaultValue != null)
                {
                    yield return $"default {usage.DefaultValue.Yellow()}";
                }
            }
        }

        protected override string GetArgumentDescription(CliArgumentUsage usage)
        {
            var sb = new StringBuilder();
            sb.Append(usage.HelpText);

            var descr = string.Join(", ", EnumerateArgumentDescriptions(usage));
            if (!string.IsNullOrEmpty(descr))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append("(");
                sb.Append(descr);
                sb.Append(")");
            }

            return sb.ToString();

            static IEnumerable<string> EnumerateArgumentDescriptions(CliArgumentUsage usage)
            {
                switch (usage.Type)
                {
                    case EnumCliTypeInfo i when i.ValidValues.Length > 0:
                        yield return $"valid values {string.Join("/", from v in i.ValidValues select v.Yellow())}";
                        break;
                    case StringCliTypeInfo _:
                        break;
                    default:
                        yield return usage.Type.Name;
                        break;
                }

                if (usage.IsRequired)
                {
                    yield return "required";
                }

                if (usage.IsRepeatable)
                {
                    yield return "repeatable";
                }

                if (usage.DefaultValue != null)
                {
                    yield return $"default {usage.DefaultValue.Yellow()}";
                }
            }
        }
    }
}