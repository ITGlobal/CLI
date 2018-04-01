using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ITGlobal.CommandLine.Internals;
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
        private readonly List<ParameterInfo> _allParameters = new List<ParameterInfo>();
        private readonly List<ParameterInfo> _visibleParameters = new List<ParameterInfo>();

        private UsageInfo(
            string executableName,
            string title,
            string version,
            string helpText,
            CommandInfoOld[] commands,
            IEnumerable<ParameterInfo> parameters)
        {
            ExecutableName = executableName /* ?? Process.GetCurrentProcess().ProcessName */;

            Title = title ?? "";
            Version = version ?? "";
            HelpText = helpText ?? "";
            Commands = commands;

            foreach (var command in commands)
            {
                command.Parent = this;
            }

            foreach(var parameter in parameters)
            {
                _allParameters.Add(parameter);
                if(!parameter.IsHidden)
                {
                    _visibleParameters.Add(parameter);
                }
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
        public IReadOnlyList<CommandInfoOld> Commands { get; }
#else
        public IList<CommandInfoOld> Commands { get; }
#endif


        /// <summary>
        ///     Gets a list of defined global parameters
        /// </summary>
        [PublicAPI, NotNull]

#if !NET40
        public IReadOnlyList<ParameterInfo> Parameters => _visibleParameters;
#else
        public IList<ParameterInfo> Parameters => _visibleParameters;
#endif

        internal static UsageInfo Create(
            string executableName,
            string title,
            string version,
            string helpText,
            IEnumerable<CommandInfoOld> commands,
            IEnumerable<ParameterInfo> parameters)
        {
            return new UsageInfo(
                executableName,
                title,
                version,
                helpText,
                commands.Where(_ => !_.IsHidden).ToArray(),
                parameters
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

            if (_visibleParameters.Count > 0)
            {
                Console.WriteLine();
                ParameterInfo.PrintTable(_visibleParameters);
            }

            if (HasCommands)
            {
                CommandInfoOld.PrintTable(Commands);
            }
        }
		
        private void PrintCommandLineExample()
        {
            Console.WriteLine(Text.Usage);
            using (Terminal.Stdout.WithForeground(ConsoleColor.Yellow))
            {
                Console.Write(ExecutableName);
            }
            Console.Write(' ');

            foreach (var param in _allParameters.Where(_ => !_.IsPositional))
            {
                param.PrintInline();
                Console.Write(' ');
            }

            foreach (var param in _allParameters.Where(_ => _.IsPositional).OrderBy(_ => _.Position.Value))
            {
                param.PrintInline();
                Console.Write(' ');
            }

            Console.WriteLine();
        }
    }
}