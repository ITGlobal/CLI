using System;
using System.Collections.Generic;
using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Command line repeatable positional argument
    /// </summary>
    [PublicAPI]
    public sealed class MultiCliArgument<T> : ICliConsumer
    {
        #region fields

        private readonly List<ValueValidator<T[]>> _validators = new List<ValueValidator<T[]>>();

        private string _helpText;
        private bool _hidden;
        private DefaultValueProvider<T[]> _defaultValueProvider;
        private IValueParser<T> _parser = ValueParser.Get<T>();
        private bool _isRequired;

        #endregion

        #region .ctor

        internal MultiCliArgument(int position, string name)
        {
            Position = position;
            Name = name;
        }

        #endregion

        #region properties

        /// <summary>
        ///     Argument index
        /// </summary>
        public int Position { get; }

        /// <summary>
        ///     Gets a value indicating whether an argument was present in command line
        /// </summary>
        public bool IsSet { get; private set; }

        /// <summary>
        ///     Gets an argument value
        /// </summary>
        [PublicAPI]
        public T[] Values { get; private set; }
#if !NET40 && !NET45
            = Array.Empty<T>();
#else
            = new T[0];
#endif

        /// <summary>
        ///     Argument name
        /// </summary>
        [NotNull]
        internal string Name { get; }

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public MultiCliArgument<T> HelpText([NotNull] string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            _helpText = text;
            return this;
        }

        /// <summary>
        ///     Marks argument as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public MultiCliArgument<T> Hidden(bool hidden = true)
        {
            _hidden = hidden;
            return this;
        }

        /// <summary>
        ///     Sets custom value parser
        /// </summary>
        [NotNull]
        public MultiCliArgument<T> UseParser([NotNull] IValueParser<T> parser)
        {
            if (parser == null)
            {
                throw new ArgumentNullException(nameof(parser));
            }

            _parser = parser;
            return this;
        }

        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public MultiCliArgument<T> DefaultValue(params T[] defaultValues)
        {
            bool DefaultValueProvider(out T[] value)
            {
                value = defaultValues;
                return true;
            }

            return DefaultValue(DefaultValueProvider);
        }

        /// <summary>
        ///     Binds argument default value to an environment variable
        /// </summary>
        [NotNull]
        public MultiCliArgument<T> DefaultValueFromEnvironmentVariable(string name)
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
                values = new[] { value };
                return true;
            }

            return DefaultValue(DefaultValueProvider);
        }

        /// <summary>
        ///     Sets argument default value provider
        /// </summary>
        [NotNull]
        public MultiCliArgument<T> DefaultValue([NotNull] DefaultValueProvider<T[]> defaultValueProvider)
        {
            if (defaultValueProvider == null)
            {
                throw new ArgumentNullException(nameof(defaultValueProvider));
            }

            _defaultValueProvider = defaultValueProvider;
            return this;
        }

        /// <summary>
        ///     Marks argument as required
        /// </summary>
        [NotNull]
        public MultiCliArgument<T> Required(string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Argument \"{Name}\" is missing";
            _isRequired = true;

            return Validate((values, isSet) =>
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
        public MultiCliArgument<T> Validate([NotNull] ValueValidator<T[]> validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator));
            }

            _validators.Add(validator);
            return this;
        }

        #endregion

        #region operators

        /// <summary>
        ///     Implicit convertion to boolean
        /// </summary>
        public static implicit operator bool(MultiCliArgument<T> option) => option.IsSet;

        /// <summary>
        ///     Implicit convertion to T[]
        /// </summary>
        public static implicit operator T[](MultiCliArgument<T> cliOption) => cliOption.Values;

        #endregion

        #region ICliConsumer

        void ICliConsumer.CheckConfiguration()
        {
            if (_parser == null)
            {
                throw new Exception($"You should specify custom parser for {typeof(T).FullName} (see argument \"{Name}\")");
            }
        }

        void ICliConsumer.Consume(RawCommandLine raw)
        {
            IEnumerable<T> Iterator()
            {
                while (true)
                {
                    var str = raw.ConsumeArgument(Position);
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

            builder.AddArgument(new CliArgumentUsage(
                position: Position,
                name: Name,
                typeName: TypeNameHelper.GetTypeName<T>(),
                helpText: _helpText,
                isHidden: _hidden,
                defaultValue: defaultValue,
                isRequired: _isRequired,
                isRepeatable: true
            ));
        }

        #endregion
    }
}