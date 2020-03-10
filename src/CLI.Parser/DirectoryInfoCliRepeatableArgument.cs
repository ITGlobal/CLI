using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliRepeatableArgument{T}"/> that contains a <see cref="System.IO.DirectoryInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class DirectoryInfoCliRepeatableArgument
    {
        #region fields

        private readonly CliRepeatableArgument<DirectoryInfo> _argument;

        #endregion

        #region .ctor

        internal DirectoryInfoCliRepeatableArgument(CliRepeatableArgument<DirectoryInfo> argument)
        {
            _argument = argument;
        }

        #endregion

        #region properties

        /// <summary>
        ///     Argument index
        /// </summary>
        public int Position => _argument.Position;

        /// <summary>
        ///     Gets a value indicating whether an argument was present in command line
        /// </summary>
        public bool IsSet => _argument.IsSet;

        /// <summary>
        ///     Gets an argument value
        /// </summary>
        [PublicAPI]
        public DirectoryInfo[] Values => _argument.IsSet ? _argument.Values : null;
        
        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument HelpText([NotNull] string text)
        {
            _argument.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks argument as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument Hidden(bool hidden = true)
        {
            _argument.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets argument default value provider
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument DefaultValue([NotNull] DefaultValueProvider<DirectoryInfo[]> provider)
        {
            _argument.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument DefaultValue([NotNull] params string[] defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out DirectoryInfo[] infos)
            {
                infos = defaultValue.Select(p => new DirectoryInfo(p)).ToArray();
                return true;
            }
        }

        /// <summary>
        ///     Marks argument as required
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument Required(string errorMessage = null)
        {
            _argument.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument Validate([NotNull] ValueValidator<DirectoryInfo[]> validator)
        {
            _argument.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified directories must exist
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument MustExist()
        {
            _argument.Validate((value, isSet) =>
            {
                if (!isSet || value == null)
                {
                    return null;
                }

                foreach (var info in value)
                {
                    if (!info.Exists)
                    {
                        return $"Directory \"{info.FullName}\" doesn't exist";
                    }
                }

                return null;
            });

            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified directories must not exist
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableArgument MustNotExist()
        {
            _argument.Validate((value, isSet) =>
            {
                if (!isSet || value == null)
                {
                    return null;
                }

                foreach (var info in value)
                {
                    if (!info.Exists)
                    {
                        return $"Directory \"{info.FullName}\" already exists";
                    }
                }

                return null;
            });

            return this;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (!IsSet)
            {
                return string.Empty;
            }

            return string.Join(";", from i in Values select i.FullName);
        }

        #endregion

        #region operators

        /// <summary>
        ///     Implicit conversion to boolean
        /// </summary>
        public static implicit operator bool(DirectoryInfoCliRepeatableArgument option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="DirectoryInfo"/>
        /// </summary>
        public static implicit operator DirectoryInfo[](DirectoryInfoCliRepeatableArgument option) => option.Values;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string[](DirectoryInfoCliRepeatableArgument option) 
            => option.Values.Select(_ => _.FullName).ToArray();

        #endregion
    }
}