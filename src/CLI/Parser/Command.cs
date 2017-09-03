using System;
using System.Collections.Generic;
using System.Linq;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class Command : ICommand
    {
        private readonly HashSet<string> _aliases = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly List<IParameterParser> _parameters = new List<IParameterParser>();
        private readonly string _name;
        private string _helpText;

        private CommandHandler _handler = _ => 0;

        public Command(string name)
        {
            _name = name;
            _aliases.Add(name);
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


        public ICommand Handler(CommandHandler handler)
        {
            _handler = handler;
            return this;
        }

        public ICommand Alias(string name)
        {
            _aliases.Add(name);
            return this;
        }

        public ICommand HelpText(string text)
        {
            _helpText = text;
            return this;
        }

        public ICommand Hidden(bool hidden = true)
        {
            IsHidden = hidden;
            return this;
        }

        public bool MatchesAlias(string name) => _aliases.Contains(name);

        public string Name => _name;
        public string[] Aliases => _aliases.ToArray();
        public bool SuppressValidation { get; set; }
        public bool IsHidden { get; private set; }

        public CommandInfo GetCommandInfo(IEnumerable<IParameterParser> globalParameters)
        {
            return CommandInfo.Create(
                _name,
                _helpText,
                IsHidden,
                _aliases,
                from p in globalParameters
                orderby p.Name
                select p.GetParameterInfo(),
                from p in _parameters
                orderby p.Name
                select p.GetParameterInfo()
            );
        }

        public ICommandParserResult Run(CommandParser parser, CommandLineInfo commandLine)
        {
            commandLine.Parse(_parameters);
            commandLine.AddFreeArguments();

            if (!SuppressValidation)
            {
                commandLine.ThrowIfNotValid();
            }

            return new CommandParserResult(parser, _handler, commandLine);
        }

        public void Validate(List<string> errors)
        {
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
                    Text.AmbiguousCommandParameter,
                    parameter.Alias,
                    _name,
                    string.Join(", ", from p in parameter.Parameters select p.Name))
                    );
            }
        }
    }
}