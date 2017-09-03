using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Describes console command
    /// </summary>
    [PublicAPI]
    public sealed class CommandInfo
    {
        private CommandInfo(
            string name,
            string helpText,
            string[] aliases,
            ParameterInfo[] parameters)
        {
            Name = name;
            HelpText = helpText ?? "";
            Aliases = aliases;
            Parameters = parameters;
        }

        /// <summary>
        ///     Command name
        /// </summary>
        [PublicAPI, NotNull]
        public string Name { get; }

        /// <summary>
        ///     Command's help text
        /// </summary>
        [PublicAPI, NotNull]
        public string HelpText { get; }

        /// <summary>
        ///     Command's aliases. Contains at least one item.
        /// </summary>
        [PublicAPI, NotNull]
#if !NET40
        public IReadOnlyList<string> Aliases { get; }
#else
        public IList<string> Aliases { get; }
#endif
        

        /// <summary>
        ///     Command's parameters. Also includes global parameters.
        /// </summary>
        [PublicAPI, NotNull]
#if !NET40
        public IReadOnlyList<ParameterInfo> Parameters { get; }
#else
        public IList<ParameterInfo> Parameters { get; }
#endif
        

        internal UsageInfo Parent { get; set; }

        internal static CommandInfo Create(
            string name,
            string helpText,
            IEnumerable<string> aliases,
            IEnumerable<ParameterInfo> parameters)
        {
            return new CommandInfo(
                name,
                helpText,
                aliases.ToArray(),
                parameters.ToArray()
            );
        }

        /// <summary>
        ///     Prints command usage
        /// </summary>
        [PublicAPI]
        public void Print()
        { 
            if (!string.IsNullOrEmpty(HelpText))
            {
                Console.WriteLine(HelpText);
            }
            Console.WriteLine();

            PrintCommandLineExample();

            if (Parameters.Count > 0)
            {
                Console.WriteLine();
                ParameterInfo.PrintTable(Parameters);
            }
			
            Console.WriteLine();
        }

        private void PrintCommandLineExample()
        {
            Console.WriteLine(Text.Usage);
            Console.Write(Parent.ExecutableName);
            Console.Write(' ');
            Console.Write(Aliases[0]);
            Console.Write(' ');

            foreach (var param in Parameters.Where(_ => _.IsPositional).OrderBy(_ => _.Position.Value))
            {
                param.PrintInline();
                Console.Write(' ');
            }

            foreach (var param in Parameters.Where(_ => !_.IsPositional))
            {
                param.PrintInline();
                Console.Write(' ');
            }

            Console.WriteLine();
        }

        internal static void PrintTable(IEnumerable<CommandInfo> commands)
        {
            Table(commands, table =>
            {
                table.PrintHeader(false).PrintTitle().Title(Text.Commands);
                table.Column("Command", _ => "  " + string.Join("|", _.Aliases), fg: _ => ConsoleColor.Cyan);
                table.Column("Description", _ => _.HelpText);
            });
        }
    }
}