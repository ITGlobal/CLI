using System;
using System.Collections.Generic;
using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line named repetable option
    /// </summary>
    [PublicAPI]
    public sealed class MultiCliOption<T> : ICliConsumer
    {
        #region fields

        private readonly List<ValueValidator<T[]>> _validators = new List<ValueValidator<T[]>>();

        private string _helpText;
        private bool _hidden;
        private DefaultValueProvider<T[]> _defaultValueProvider;
        private IValueParser<T> _parser = ValueParser.Get<T>();
        private bool _isRequired;
        private int _displayOrder;

        #endregion

        #region .ctor

        internal MultiCliOption() { }

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
        public T[] Values { get; private set; }
#if !NET40 && !NET45
            = Array.Empty<T>();
#else
            = new T[0];
#endif

        internal char? ShortName { get; set; }

        internal string LongName { get; set; }

        /// <summary>
        ///     Option name
        /// </summary>
        [NotNull]
        internal string Name => LongName != null ? $"--{LongName}" : $"-{ShortName}";

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public MultiCliOption<T> HelpText([NotNull] string text)
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
        public MultiCliOption<T> Hidden(bool hidden = true)
        {
            _hidden = hidden;
            return this;
        }

        /// <summary>
        ///     Sets custom value parser
        /// </summary>
        [NotNull]
        public MultiCliOption<T> UseParser([NotNull] IValueParser<T> parser)
        {
            if (parser == null)
            {
                throw new ArgumentNullException(nameof(parser));
            }

            _parser = parser;
            return this;
        }

        /// <summary>
        ///     Sets option default value
        /// </summary>
        [NotNull]
        public MultiCliOption<T> DefaultValue(params T[] defaultValues)
        {
            bool DefaultValueProvider(out T[] value)
            {
                value = defaultValues;
                return true;
            }

            return DefaultValue(DefaultValueProvider);
        }

        /// <summary>
        ///     Binds option default value to an environment variable
        /// </summary>
        [NotNull]
        public MultiCliOption<T> DefaultValueFromEnvironmentVariable(string name)
        {
            bool DefaultValueProvider(out T[] values)
            {
                values = default(T[]);

                var env = Environment.GetEnvironmentVariable(name);
                if (string.IsNullOrEmpty(env))
                {
                    return false;
                }

                var result = _parser.Parse(env);
                if (!result.IsSuccess)
                {
                    return false;
                }

                var value = result.Value;
                values = new[] {value};
                return true;
            }

            return DefaultValue(DefaultValueProvider);
        }

        /// <summary>
        ///     Sets option default value provider
        /// </summary>
        [NotNull]
        public MultiCliOption<T> DefaultValue([NotNull] DefaultValueProvider<T[]> defaultValueProvider)
        {
            if (defaultValueProvider == null)
            {
                throw new ArgumentNullException(nameof(defaultValueProvider));
            }

            _defaultValueProvider = defaultValueProvider;
            return this;
        }

        /// <summary>
        ///     Marks option as required
        /// </summary>
        [NotNull]
        public MultiCliOption<T> Required(string errorMessage = null)
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
        public MultiCliOption<T> Validate([NotNull] ValueValidator<T[]> validator)
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
        public MultiCliOption<T> DisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
            return this;
        }

        #endregion

        #region operators

        /// <summary>
        ///     Implicit convertion to boolean
        /// </summary>
        public static implicit operator bool(MultiCliOption<T> option) => option.IsSet;

        /// <summary>
        ///     Implicit convertion to T[]
        /// </summary>
        public static implicit operator T[] (MultiCliOption<T> cliOption) => cliOption.Values;

        #endregion

        #region ICliConsumer

        void ICliConsumer.CheckConfiguration()
        {
            if (_parser == null)
            {
                throw new Exception($"You should specify custom parser for {typeof(T).FullName} (see option \"{Name}\")");
            }
        }

        void ICliConsumer.Consume(RawCommandLine raw)
        {
            IEnumerable<T> Iterator()
            {
                while (true)
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

                    if (str == null)
                    {
                        yield break;
                    }
                    
                    var result = _parser.Parse(str);
                    if (result.IsSuccess)
                    {
                        yield return result.Value;
                    }
                    else
                    {
                        raw.AddError(result.ErrorMessage);
                    }
                }
            }

            var values = Iterator().ToArray();
            if (values.Length > 0)
            {
                Values = values;
                IsSet = true;
            }

            if (!IsSet && _defaultValueProvider != null)
            {
                if (_defaultValueProvider(out values))
                {
                    Values = values;
                    IsSet = true;
                }
            }

            foreach (var validator in _validators)
            {
                var errorMessage = validator(Values, IsSet);
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
            if (_defaultValueProvider != null)
            {
                if (_defaultValueProvider(out var values))
                {
                    defaultValue = string.Join(", ", from value in values select _parser.Format(value));
                }
            }

            builder.AddOption(new CliOptionUsage(
                names: builder.GetOptionNames(ShortName, LongName),
                typeName: TypeNameHelper.GetTypeName<T>(),
                helpText: _helpText,
                isHidden: _hidden,
                defaultValue: defaultValue,
                isRequired: _isRequired,
                isRepeatable: true,
                displayOrder: _displayOrder
            ));
        }

        #endregion
    }
}