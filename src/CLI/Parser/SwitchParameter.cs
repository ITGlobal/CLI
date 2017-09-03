using System;
using System.Collections.Generic;
using System.Linq;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class SwitchParameter : ISwitch, IParameterParser
    {
        private readonly HashSet<string> _aliases = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly string _name;
        private string _helpText;

        public SwitchParameter(string name)
        {
            _name = name;
            _aliases.Add(GetAliasFor(name));
        }

        public bool IsSet { get; private set; }
        public event Action<ISwitch> ValueParsed;
        private void OnValueParsed() => ValueParsed?.Invoke(this);

        public ISwitch Alias(string name)
        {
            _aliases.Add(GetAliasFor(name));
            return this;
        }

        public ISwitch HelpText(string text)
        {
            _helpText = text;
            return this;
        }

        public ISwitch Hidden(bool hidden = true)
        {
            IsHidden = hidden;
            return this;
        }

        string IParameterParser.Name => _name;
        string[] IParameterParser.Aliases => _aliases.ToArray();
        public bool IsHidden { get; private set; }

        void IParameterParser.Reset() => IsSet = false;

        ParameterParserResult IParameterParser.TryConsume(string[] args, ref int index)
        {
            var name = args[index];
            if (_aliases.Contains(name))
            {
                IsSet = true;
                OnValueParsed();
                return ParameterParserResult.Consumed;
            }

            return ParameterParserResult.NotConsumed;
        }

        ParameterParserResult IParameterParser.TryConsumeAt(string[] args, int index) => ParameterParserResult.NotConsumed;

        void IParameterParser.Validate(IList<string> errors) { }
        ParameterInfo IParameterParser.GetParameterInfo()
            => ParameterInfo.Switch(_name, _aliases, _helpText, IsHidden);
    }
}