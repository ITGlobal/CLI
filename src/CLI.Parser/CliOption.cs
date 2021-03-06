using System;
using System.Collections.Generic;
using ITGlobal.CommandLine.Parsing.Help;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line named option
    /// </summary>
    [PublicAPI]
    public sealed class CliOption<T> : ICliConsumer
    {
        #region fields

        private readonly List<ValueValidator<T>> _validators = new List<ValueValidator<T>>();
        private readonly List<DefaultValueProvider<T>> _defaultValueProviders = new List<DefaultValueProvider<T>>();

        private string _helpText = "";
        private bool _hidden;
        private bool _isRequired;
        private int _displayOrder;

        #endregion

        #region .ctor

        internal CliOption() { }

        #endregion

        #region properties

        /// <summary>
        ///     Gets a value indicating whether an option was present in command line
        /// </summary>
        public bool IsSet { get; private set; }

        /// <summary>
        ///     Gets an option value
        /// </summary>
        [PublicAPI]
        public T Value { get; private set; }

        internal char? ShortName { get; set; }

        internal string LongName { get; set; }

        /// <summary>
        ///     Option name
        /// </summary>
        [NotNull]
        internal string Name => LongName != null ? $"--{LongName}" : $"-{ShortName}";

        internal IValueParser<T> Parser { get; private set; } = ValueParser.Get<T>();

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public CliOption<T> HelpText([NotNull] string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            _helpText = text;
            return this;
        }

        /// <summary>
        ///     Marks option as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public CliOption<T> Hidden(bool hidden = true)
        {
            _hidden = hidden;
            return this;
        }

        /// <summary>
        ///     Sets custom value parser
        /// </summary>
        [NotNull]
        public CliOption<T> UseParser([NotNull] IValueParser<T> parser)
        {
            if (parser == null)
            {
                throw new ArgumentNullException(nameof(parser));
            }

            Parser = parser;
            return this;
        }


        /// <summary>
        ///     Sets option default value provider
        /// </summary>
        [NotNull]
        public CliOption<T> DefaultValue([NotNull] DefaultValueProvider<T> provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            _defaultValueProviders.Add(provider);
            return this;
        }

        /// <summary>
        ///     Marks option as required
        /// </summary>
        [NotNull]
        public CliOption<T> Required(string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Option \"{Name}\" is missing";
            _isRequired = true;

            return Validate((value, isSet) =>
            {
                if (!isSet)
                {
                    return errorMessage;
                }

                return null;
            });
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public CliOption<T> Validate([NotNull] ValueValidator<T> validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator));
            }

            _validators.Add(validator);
            return this;
        }

        /// <summary>
        ///     Sets option display order
        /// </summary>
        [NotNull]
        public CliOption<T> DisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
            return this;
        } 
        
        /// <inheritdoc />
        public override string ToString()
        {
            if (!IsSet)
            {
                return string.Empty;
            }

            return Value.ToString();
        }

        #endregion

        #region operators

        /// <summary>
        ///     Implicit conversion to boolean
        /// </summary>
        public static implicit operator bool(CliOption<T> option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to T
        /// </summary>
        public static implicit operator T(CliOption<T> cliOption) => cliOption.Value;

        #endregion

        #region ICliConsumer

        int ICliConsumer.Priority => CliConsumerPriority.Option;

        void ICliConsumer.CheckConfiguration()
        {
            if (Parser == null)
            {
                throw new Exception($"You should specify custom parser for {typeof(T).FullName} (see option \"{Name}\")");
            }
        }

        void ICliConsumer.Consume(RawCommandLine raw)
        {
            string str = null;

            if (LongName != null)
            {
                str = raw.ConsumeOption(LongName);
            }

            if (str == null && ShortName != null)
            {
                str = raw.ConsumeOption(ShortName.Value);
            }

            if (str != null)
            {
                var result = Parser.Parse(str);
                if (result.IsSuccess)
                {
                    Value = result.Value;
                    IsSet = true;
                }
                else
                {
                    raw.AddError(result.ErrorMessage);
                }
            }

            if (!IsSet)
            {
                foreach (var provider in _defaultValueProviders)
                {
                    if (provider(out var value))
                    {
                        Value = value;
                        IsSet = true;
                        break;
                    }
                }
            }

            foreach (var validator in _validators)
            {
                var errorMessage = validator(Value, IsSet);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    raw.AddError(errorMessage);
                    break;
                }
            }
        }

        void ICliConsumer.BuildUsage(IUsageBuilder builder)
        {
            string defaultValue = null;
            foreach (var provider in _defaultValueProviders)
            {
                if (provider(out var value))
                {
                    defaultValue = Parser.Format(value);
                    break;
                }
            }

            builder.AddOption(new CliOptionUsage(
                names: builder.GetOptionNames(ShortName, LongName),
                type: Parser.TypeInfo,
                helpText: _helpText,
                isHidden: _hidden,
                defaultValue: defaultValue,
                isRequired: _isRequired,
                isRepeatable: false,
                displayOrder: _displayOrder
            ));
        }

        #endregion
    }
}