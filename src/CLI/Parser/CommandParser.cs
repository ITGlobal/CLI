using System;
using System.Collections.Generic;
using System.Linq;
using ITGlobal.CommandLine.Internals;
using JetBrains.Annotations;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class CommandParser : ICommandParser
    {
        private readonly List<IParameterParser> _parameters = new List<IParameterParser>();
        private readonly List<Command> _commands = new List<Command>();

        private readonly PositionalParameter<string> _commandNameParameter = 
            (PositionalParameter<string>)new PositionalParameter<string>(0, "command").Hidden();
        private bool _isInitialized;

        private string _executableName;
        private string _title;
        private string _version;
        private string _helpText;
        private bool _suppressLogo;
        private bool _strictMode;
        private CommandHandler _handler = _ => 0;
        private readonly List<CommandHook> _hooks = new List<CommandHook>();

        private UsageInfo _usage;


        public bool SuppressValidation { get; set; }
        public IList<Command> Commands => _commands;
        public PositionalParameter<string> CommandNameParameter => _commandNameParameter;

        public ICommandParser ExecutableName(string exeName)
        {
            _executableName = exeName;
            return this;
        }

        public ICommandParser Title(string title)
        {
            _title = title;
            return this;
        }

        public ICommandParser Version(string version)
        {
            _version = version;
            return this;
        }

        public ICommandParser HelpText(string text)
        {
            _helpText = text;
            return this;
        }

        public ICommandParser SuppressLogo(bool suppress)
        {
            _suppressLogo = suppress;
            return this;
        }

        public ICommandParser StrictMode(bool enable)
        {
            _strictMode = enable;
            return this;
        }

        public ISwitch Switch(string name)
        {
            var sw = new SwitchParameter(name);
            _parameters.Add(sw);
            return sw;
        }

        public INamedParameter<T> Parameter<T>(string name)
        {
            var parameter = new NamedParameter<T>(name);
            _parameters.Add(parameter);
            return parameter;
        }

        public IPositionalParameter<T> Parameter<T>(int index, string name)
        {
            var parameter = new PositionalParameter<T>(index, name);
            _parameters.Add(parameter);
            return parameter;
        }


        public ICommand Command(string name)
        {
            var command = new Command(name);
            _commands.Add(command);
            return command;
        }

        public ICommandParser Handler(CommandHandler handler)
        {
            _handler = handler;
            return this;
        }

        public ICommandParser Hook([NotNull] CommandHook hook)
        {
            _hooks.Add(hook);
            return this;
        }

        public ICliParserResult Parse(params string[] args)
        {
            try
            {
                Initialize();

                var commandLine = new CommandLineInfo(args, _strictMode);
                commandLine.Parse(_parameters);

                if (_commands.Count <= 0 || !_commandNameParameter.IsSet)
                {
                    commandLine.AddFreeArguments();

                    var result = HookFunc();
                    if (result != null)
                    {
                        return new CommandParserHookResult(result.Value);
                    }

                    if (!SuppressValidation)
                    {
                        commandLine.ThrowIfNotValid();
                    }

                    return new CommandParserResult(this, _handler, commandLine);
                }

                var name = _commandNameParameter.Value;
                var command = _commands.FirstOrDefault(_ => _.MatchesAlias(name));
                if (command == null)
                {
                    throw new CommandNotFoundException(name);
                }

                {
                    var result = HookFunc();
                    if (result != null)
                    {
                        return new CommandParserHookResult(result.Value);
                    }
                }

                return command.Run(this, commandLine);
            }
            catch
            {
                PrintLogo();
                throw;
            }
        }

        public UsageInfo Usage()
        {
            Initialize();

            return _usage = _usage ?? UsageInfo.Create(
                _executableName,
                _title,
                _version,
                _helpText,
                from c in _commands
                select c.GetCommandInfo(from p in _parameters where p != _commandNameParameter select p),
                from p in _parameters
                select p.GetParameterInfo()
            );
        }

        public CommandInfoOld Usage(string command)
        {
            return Usage().Commands.FirstOrDefault(_ => _.Aliases.Contains(command));
        }

        internal void PrintLogo()
        {
            if (!_suppressLogo)
            {
                using (Terminal.Stdout.WithForeground(ConsoleColor.Cyan))
                {
                    Console.Write(_title);
                }
                if (!string.IsNullOrEmpty(_version))
                {
                    Console.Write(" (");
                    using (Terminal.Stdout.WithForeground(ConsoleColor.Yellow))
                    {
                        Console.Write(_version);
                    }
                    Console.Write(")");
                }
                Console.WriteLine();
            }
        }

        private void Initialize()
        {
            if (!_isInitialized)
            {
                if (_commands.Count > 0)
                {
                    _parameters.Add(_commandNameParameter);
                }

                var errors = new List<string>();

                var ambiguousParameters =
                    from g in (
                        from p in _parameters
                        from a in p.Aliases
                        group p by a.ToLowerInvariant()
                        into gr
                        select new { Alias = gr.Key, Parameters = gr.ToArray() }
                    )
                    where g.Parameters.Length > 1
                    select g;

                foreach (var parameter in ambiguousParameters)
                {
                    errors.Add(string.Format(
                        Text.AmbiguousParameter,
                        parameter.Alias,
                        string.Join(", ", from p in parameter.Parameters select p.Name))
                        );
                }


                var ambiguousCommands =
                    from g in (
                        from p in _commands
                        from a in p.Aliases
                        group p by a.ToLowerInvariant()
                        into gr
                        select new { Alias = gr.Key, Commands = gr.ToArray() }
                    )
                    where g.Commands.Length > 1
                    select g;

                foreach (var parameter in ambiguousCommands)
                {
                    errors.Add(string.Format(
                        Text.AmbiguousCommandAlias,
                        parameter.Alias,
                        string.Join(", ", from p in parameter.Commands select p.Name))
                        );
                }


                foreach (var command in _commands)
                {
                    command.Validate(errors);
                }


                if (errors.Count > 0)
                {
                    throw new CommandLineValidationException(errors.ToArray());
                }

                _isInitialized = true;
            }
        }

        private int? HookFunc()
        {
            foreach(var hook in _hooks)
            {
                var result = hook();
                if(result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}