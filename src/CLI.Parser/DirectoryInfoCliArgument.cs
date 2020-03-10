using System.IO;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliArgument{T}"/> that contains a <see cref="System.IO.DirectoryInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class DirectoryInfoCliArgument
    {
        #region fields

        private readonly CliArgument<DirectoryInfo> _argument;

        #endregion

        #region .ctor

        internal DirectoryInfoCliArgument(CliArgument<DirectoryInfo> argument)
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
        public DirectoryInfo Value => _argument.IsSet ? _argument.Value : null;
        
        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument HelpText([NotNull] string text)
        {
            _argument.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks argument as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument Hidden(bool hidden = true)
        {
            _argument.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets argument default value provider
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument DefaultValue([NotNull] DefaultValueProvider<DirectoryInfo> provider)
        {
            _argument.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument DefaultValue([NotNull] string defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out DirectoryInfo info)
            {
                info = new DirectoryInfo(defaultValue);
                return true;
            }
        }

        /// <summary>
        ///     Marks argument as required
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument Required(string errorMessage = null)
        {
            _argument.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument Validate([NotNull] ValueValidator<DirectoryInfo> validator)
        {
            _argument.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified directory must exist
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument MustExist()
        {
            _argument.Validate((value, isSet) =>
            {
                if (!isSet)
                {
                    return null;
                }

                if (!value.Exists)
                {
                    return $"Directory \"{value.FullName}\" doesn't exist";
                }

                return null;
            });

            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified directory must not exist
        /// </summary>
        [NotNull]
        public DirectoryInfoCliArgument MustNotExist()
        {
            _argument.Validate((value, isSet) =>
            {
                if (!isSet)
                {
                    return null;
                }

                if (!value.Exists)
                {
                    return $"Directory \"{value.FullName}\" already exists";
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

            return Value.ToString();
        }

        #endregion

        #region operators

        /// <summary>
        ///     Implicit conversion to boolean
        /// </summary>
        public static implicit operator bool(DirectoryInfoCliArgument option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="DirectoryInfo"/>
        /// </summary>
        public static implicit operator DirectoryInfo(DirectoryInfoCliArgument option) => option.Value;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string(DirectoryInfoCliArgument option) => option.Value.FullName;

        #endregion
    }
}