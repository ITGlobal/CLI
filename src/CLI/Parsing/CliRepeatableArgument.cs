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
    public sealed class CliRepeatableArgument<T> : ICliConsumer
    {
        #region fields

        private readonly List<ValueValidator<T[]>> _validators = new List<ValueValidator<T[]>>();
        private readonly List<DefaultValueProvider<T[]>> _defaultValueProviders = new List<DefaultValueProvider<T[]>>();

        private string _helpText;
        private bool _hidden;
        private bool _isRequired;

        #endregion

        #region .ctor

        internal CliRepeatableArgument(int position, string name)
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

        internal IValueParser<T> Parser { get; private set; } = ValueParser.Get<T>();

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public CliRepeatableArgument<T> HelpText([NotNull] string text)
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
        public CliRepeatableArgument<T> Hidden(bool hidden = true)
        {
            _hidden = hidden;
            return this;
        }

        /// <summary>
        ///     Sets custom value parser
        /// </summary>
        [NotNull]
        public CliRepeatableArgument<T> UseParser([NotNull] IValueParser<T> parser)
        {
            if (parser == null)
            {
                throw new ArgumentNullException(nameof(parser));
            }

            Parser = parser;
            return this;
        }

        /// <summary>
        ///     Sets argument default value provider
        /// </summary>
        [NotNull]
        public CliRepeatableArgument<T> DefaultValue([NotNull] DefaultValueProvider<T[]> provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            _defaultValueProviders.Add(provider);
            return this;
        }

        /// <summary>
        ///     Marks argument as required
        /// </summary>
        [NotNull]
        public CliRepeatableArgument<T> Required(string errorMessage = null)
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
        public CliRepeatableArgument<T> Validate([NotNull] ValueValidator<T[]> validator)
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
        public static implicit operator bool(CliRepeatableArgument<T> option) => option.IsSet;

        /// <summary>
        ///     Implicit convertion to T[]
        /// </summary>
        public static implicit operator T[](CliRepeatableArgument<T> cliOption) => cliOption.Values;

        #endregion

        #region ICliConsumer

        void ICliConsumer.CheckConfiguration()
        {
            if (Parser == null)
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
                    
                    var result = Parser.Parse(str);
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

            if (!IsSet)
            {
                foreach (var provider in _defaultValueProviders)
                {
                    if (provider(out values))
                    {
                        Values = values;
                        IsSet = true;
                        break;
                    }
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
            foreach (var provider in _defaultValueProviders)
            {
                if (provider(out var values))
                {
                    defaultValue = string.Join(", ", from value in values select Parser.Format(value));
                    break;
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