using System;
using System.Collections.Generic;
using System.Linq;
using ITGlobal.CommandLine.Internals;
using ITGlobal.CommandLine.Table;
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
        private readonly List<ParameterInfo> _globalParameters = new List<ParameterInfo>();
        private readonly List<ParameterInfo> _commandParameters = new List<ParameterInfo>();
        private readonly List<ParameterInfo> _visibleParameters = new List<ParameterInfo>();

        private CommandInfo(
            string name,
            string helpText,
            string[] aliases,
            IEnumerable<ParameterInfo> globalParameters,
            IEnumerable<ParameterInfo> commandParameters,
            bool isHidden)
        {
            Name = name;
            HelpText = helpText ?? "";
            Aliases = aliases;
            IsHidden = isHidden;

            foreach (var parameter in globalParameters)
            {
                _globalParameters.Add(parameter);
                if (!parameter.IsHidden)
                {
                    _visibleParameters.Add(parameter);
                }
            }

            foreach (var parameter in commandParameters)
            {
                _commandParameters.Add(parameter);
                if (!parameter.IsHidden)
                {
                    _visibleParameters.Add(parameter);
                }
            }
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
        public IReadOnlyList<ParameterInfo> Parameters => _visibleParameters;
#else
        public IList<ParameterInfo> Parameters => _visibleParameters;
#endif

        /// <summary>
        ///     Returns true for hidden commands
        /// </summary>
        [PublicAPI]
        public bool IsHidden { get; }

        internal UsageInfo Parent { get; set; }

        internal static CommandInfo Create(
            string name,
            string helpText,
            bool isHidden,
            IEnumerable<string> aliases,
            IEnumerable<ParameterInfo> globalParameters,
            IEnumerable<ParameterInfo> commandParameters)
        {
            return new CommandInfo(
                name,
                helpText,
                aliases.ToArray(),
                globalParameters,
                commandParameters,
                isHidden
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

            if (_visibleParameters.Count > 0)
            {
                Console.WriteLine();
                ParameterInfo.PrintTable(_visibleParameters);
            }

            Console.WriteLine();
        }

        private void PrintCommandLineExample()
        {
            Console.WriteLine(Text.Usage);
            using (Terminal.Stdout.WithForeground(ConsoleColor.Yellow))
            {
                Console.Write(Parent.ExecutableName);
            }
            Console.Write(' ');

            foreach (var param in _globalParameters.Where(_ => !_.IsPositional))
            {
                param.PrintInline();
                Console.Write(' ');
            }

            Console.Write(Aliases[0]);
            Console.Write(' ');

            foreach (var param in _commandParameters.Where(_ => !_.IsPositional))
            {
                param.PrintInline();
                Console.Write(' ');
            }

            foreach (var param in _globalParameters.Concat(_commandParameters)
                .Where(_ => _.IsPositional)
                .OrderBy(_ => _.Position.Value))
            {
                param.PrintInline();
                Console.Write(' ');
            }

            Console.WriteLine();
        }

        internal static void PrintTable(IEnumerable<CommandInfo> commands)
        {
            Terminal.Stdout.WriteLine(Text.Commands.ToUpperInvariant().WithForeground(ConsoleColor.Cyan));

            var table = TerminalTable.Create(commands, TableRenderer.Plain(drawHeaders: false));
            table.Column("Command", _ => "  " + string.Join(", ", _.Aliases), fg: _ => ConsoleColor.Cyan);
            table.Column("Description", _ => _.HelpText);
            table.Draw();
        }
    }
}