using System;
using System.Collections.Generic;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class PositionalParameter<T> : IPositionalParameter<T>, IParameterParser
    {
        private readonly int _index;
        private readonly string _name;
        private T _default;
        private bool _isRequired;
        private string _helpText;
        private Func<string, T> _parser = rawValue => (T) Convert.ChangeType(rawValue, typeof(T));

        public PositionalParameter(int index, string name)
        {
            _index = index;
            _name = name;
        }

        public bool IsSet { get; private set; }

        public T Value { get; private set; }

        public event Action<IPositionalParameter<T>> ValueParsed;
        private void OnValueParsed() => ValueParsed?.Invoke(this);

        public IPositionalParameter<T> HelpText(string text)
        {
            _helpText = text;
            return this;
        }

        public IPositionalParameter<T> DefaultValue(T value)
        {
            _default = value;
            Value = value;
            return this;
        }

        public IPositionalParameter<T> ParseUsing(Func<string, T> parser)
        {
            _parser = parser;
            return this;
        }

        public IPositionalParameter<T> Required(bool isRequired = true)
        {
            _isRequired = isRequired;
            return this;
        }

        string IParameterParser.Name => _name;
        string[] IParameterParser.Aliases => EmptyArray;

        void IParameterParser.Reset()
        {
            IsSet = false;
            Value = _default;
        }

        bool IParameterParser.TryConsume(string[] args, ref int index) => false;

        bool IParameterParser.TryConsumeAt(string[] args, int index)
        {
            if (index == _index)
            {
                IsSet = true;
                var rawValue = args[index];
                Value = _parser(rawValue);
                OnValueParsed();
                return true;
            }

            return false;
        }

        void IParameterParser.Validate(IList<string> errors)
        {
            if (_isRequired && !IsSet)
            {
                errors.Add(string.Format(Text.RequiredParameterIsNotSet, _name));
            }
        }

        ParameterInfo IParameterParser.GetParameterInfo() => ParameterInfo.PositionalParameter(_name, _helpText, _index, _isRequired);
    }
}