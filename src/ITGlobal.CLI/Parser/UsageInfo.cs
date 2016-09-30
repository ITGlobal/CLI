using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Describes console parameters and commands
    /// </summary>
    [PublicAPI]
    public sealed class UsageInfo
    {
        private UsageInfo(
            string executableName,
            string title,
            string version,
            string helpText,
            CommandInfo[] commands,
            ParameterInfo[] parameters)
        {
            ExecutableName = executableName ?? Process.GetCurrentProcess().ProcessName;

            Title = title ?? "";
            Version = version ?? "";
            HelpText = helpText ?? "";
            Commands = commands;
            Parameters = parameters;

            foreach (var command in commands)
            {
                command.Parent = this;
            }
        }

        internal string ExecutableName { get; }

        /// <summary>
        ///     Gets application title
        /// </summary>
        [PublicAPI, NotNull]
        public string Title { get; }

        /// <summary>
        ///     Gets application version
        /// </summary>
        [PublicAPI, NotNull]
        public string Version { get; }

        /// <summary>
        ///     Gets an application description
        /// </summary>
        [PublicAPI, NotNull]
        public string HelpText { get; }

        /// <summary>
        ///     True if any commands were defined
        /// </summary>
        [PublicAPI]
        public bool HasCommands => Commands.Count > 0;

        /// <summary>
        ///     Gets a list of defined commands
        /// </summary>
        [PublicAPI, NotNull]
#if !NET40
        public IReadOnlyList<CommandInfo> Commands { get; }
#else
        public IList<CommandInfo> Commands { get; }
#endif
        

        /// <summary>
        ///     Gets a list of defined global parameters
        /// </summary>
        [PublicAPI, NotNull]
       
#if !NET40
        public IReadOnlyList<ParameterInfo> Parameters { get; }
#else
        public IList<ParameterInfo> Parameters { get; }
#endif

        internal static UsageInfo Create(
            string executableName,
            string title,
            string version,
            string helpText,
            IEnumerable<CommandInfo> commands,
            IEnumerable<ParameterInfo> parameters)
        {
            return new UsageInfo(
                executableName,
                title,
                version,
                helpText,
                commands.ToArray(),
                parameters.ToArray()
            );
        }

        /// <summary>
        ///     Prints usage
        /// </summary>
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

            if (HasCommands)
            {
                CommandInfo.PrintTable(Commands);
            }
        }
		
        private void PrintCommandLineExample()
        {
            Console.WriteLine(Text.Usage);
            Console.Write(ExecutableName);
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
    }
}