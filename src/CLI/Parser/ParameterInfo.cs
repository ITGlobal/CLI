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
    ///     Describes console parameter
    /// </summary>
    [PublicAPI]
    public sealed class ParameterInfo
    {
        private static readonly string[] EmptyArray = new string[0];

        private ParameterInfo(
            string name,
            string helpText,
            string[] aliases = null,
            int? position = null,
            bool isRequired = false,
            bool isSwitch = false,
            bool isHidden = false)
        {
            Name = name;
            HelpText = helpText ?? "";
            Aliases = aliases ?? EmptyArray;
            Position = position;
            IsRequired = isRequired;
            IsSwitch = isSwitch;
            IsHidden = isHidden;
        }

        /// <summary>
        ///     Parameter name
        /// </summary>
        [PublicAPI, NotNull]
        public string Name { get; }

        /// <summary>
        ///     Parameter help text
        /// </summary>
        [PublicAPI, NotNull]
        public string HelpText { get; }

        /// <summary>
        ///     Parameter aliases. Always empty for positional parameters, always non-empty for other parameters.
        /// </summary>
        [PublicAPI, NotNull]
#if !NET40
        public IReadOnlyList<string> Aliases { get; }
#else
        public IList<string> Aliases { get; }
#endif
        
        /// <summary>
        ///     Positional parameter index. Null for any non-positional parameters.
        /// </summary>
        [PublicAPI, CanBeNull]
        public int? Position { get; }

        /// <summary>
        ///     Returns true for named parameters
        /// </summary>
        [PublicAPI]
        public bool IsNamed => Aliases.Count > 0 && !IsSwitch;

        /// <summary>
        ///     Returns true for positional parameters
        /// </summary>
        [PublicAPI]
        public bool IsPositional => Position != null;

        /// <summary>
        ///     Returns true for required parameters
        /// </summary>
        [PublicAPI]
        public bool IsRequired { get; }

        /// <summary>
        ///     Returns true for switches
        /// </summary>
        [PublicAPI]
        public bool IsSwitch { get; }

        /// <summary>
        ///     Returns true for hidden parameters
        /// </summary>
        [PublicAPI]
        public bool IsHidden { get; }

        internal static ParameterInfo Switch(string name, IEnumerable<string> aliases, string helpText, bool isHidden)
            => new ParameterInfo(name, helpText, aliases.ToArray(), isSwitch: true, isHidden: isHidden);

        internal static ParameterInfo NamedParameter(string name, string helpText, IEnumerable<string> aliases, bool isRequired, bool isHidden)
            => new ParameterInfo(name, helpText, aliases.ToArray(), isRequired: isRequired, isHidden: isHidden);

        internal static ParameterInfo PositionalParameter(string name, string helpText, int position, bool isRequired, bool isHidden)
            => new ParameterInfo(name, helpText, position: position, isRequired: isRequired, isHidden: isHidden);

        internal void PrintInline()
        {
            IDisposable color;
            if (!IsRequired)
            {
                Console.Write('[');
                color = Terminal.Stdout.WithForeground(ConsoleColor.White);
            }
            else
            {
                Console.Write('<');
                color = Terminal.Stdout.WithForeground(ConsoleColor.Magenta);
            }

            using (color)
            {
                if (IsPositional)
                {
                    Console.Write(Name);
                }
                else
                {
                    Console.Write(string.Join(" | ", Aliases));
                    if(!IsSwitch)
                    {
                        Console.Write(' ');
                        Console.Write('<');
                        Console.Write(Name);
                        Console.Write('>');
                    }
                }
            }

            if (!IsRequired)
            {
                Console.Write(']');
            }
            else
            {
                Console.Write('>');
            }
        }

        internal static void PrintTable(IEnumerable<ParameterInfo> parameters)
        {
            Terminal.Stdout.WriteLine(Text.Parameters.ToUpperInvariant().WithForeground(ConsoleColor.Cyan));

            var table = TerminalTable.Create(parameters, TableRenderer.Plain(drawHeaders: false));
            table.Column("Command", _ => "  " + string.Join(", ", _.Aliases), fg: _ => ConsoleColor.Cyan);
            table.Column("Description", _ => _.HelpText);
            table.Column("Parameter", GetParameterNameOrAliases, fg: _ => ConsoleColor.Cyan);
            table.Column("Description", _ => _.HelpText);
            table.Column("Required", _ => _.IsRequired ? Text.RequiredParameter : "");
            table.Draw();
        }

        private static string GetParameterNameOrAliases(ParameterInfo parameter)
        {
            if (parameter.IsPositional)
            {
                return "  " + parameter.Name;
            }
            return "  " + string.Join(", ", parameter.Aliases);
        }
    }
}