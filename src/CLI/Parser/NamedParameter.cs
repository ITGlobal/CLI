using System;
using System.Collections.Generic;
using System.Linq;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class NamedParameter<T> : INamedParameter<T>, IParameterParser
    {
        private readonly HashSet<string> _aliases = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly string _name;
        private T _default;
        private bool _isRequired;
        private string _helpText;
        private Func<string, T> _parser = rawValue => (T) Convert.ChangeType(rawValue, typeof(T));

        public NamedParameter(string name)
        {
            _name = name;
            _aliases.Add(GetAliasFor(name));
        }

        public bool IsSet { get; private set; }

        public T Value { get; private set; }

        public event Action<INamedParameter<T>> ValueParsed;
        private void OnValueParsed() => ValueParsed?.Invoke(this);

        public INamedParameter<T> Alias(string name)
        {
            _aliases.Add(GetAliasFor(name));
            return this;
        }

        public INamedParameter<T> HelpText(string text)
        {
            _helpText = text;
            return this;
        }

        public INamedParameter<T> Hidden(bool hidden = true)
        {
            IsHidden = hidden;
            return this;
        }

        public INamedParameter<T> DefaultValue(T value)
        {
            _default = value;
            Value = value;
            return this;
        }

        public INamedParameter<T> ParseUsing(Func<string, T> parser)
        {
            _parser = parser;
            return this;
        }

        public INamedParameter<T> Required(bool isRequired = true)
        {
            _isRequired = isRequired;
            return this;
        }

        string IParameterParser.Name => _name;
        string[] IParameterParser.Aliases => _aliases.ToArray();
        public bool IsHidden { get; private set; }

        void IParameterParser.Reset()
        {
            IsSet = false;
            Value = _default;
        }

        ParameterParserResult IParameterParser.TryConsume(string[] args, ref int index)
        {
            var name = args[index];
            if (_aliases.Contains(name))
            {
                if (index >= args.Length - 1)
                {
                    return ParameterParserResult.Failure(string.Format(Text.RequiredParameterIsNotSet, _name));
                }

                index++;

                IsSet = true;
                var rawValue = args[index];
                Value = _parser(rawValue);
                OnValueParsed();

                return ParameterParserResult.Consumed;
            }

            return ParameterParserResult.NotConsumed;
        }

        ParameterParserResult IParameterParser.TryConsumeAt(string[] args, int index) => ParameterParserResult.NotConsumed;

        void IParameterParser.Validate(IList<string> errors)
        {
            if (_isRequired && !IsSet)
            {
                errors.Add(string.Format(Text.RequiredParameterIsNotSet, _name));
            }
        }

        ParameterInfo IParameterParser.GetParameterInfo()
            => ParameterInfo.NamedParameter(_name, _helpText, _aliases, _isRequired, IsHidden);
    }
}