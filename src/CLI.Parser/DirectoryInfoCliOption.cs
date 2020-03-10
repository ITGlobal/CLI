using System.IO;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliOption{T}"/> that contains a <see cref="System.IO.DirectoryInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class DirectoryInfoCliOption
    {
        #region fields

        private readonly CliOption<DirectoryInfo> _option;

        #endregion

        #region .ctor

        internal DirectoryInfoCliOption(CliOption<DirectoryInfo> option)
        {
            _option = option;
        }

        #endregion

        #region properties
        
        /// <summary>
        ///     Gets a value indicating whether an option was present in command line
        /// </summary>
        public bool IsSet => _option.IsSet;

        /// <summary>
        ///     Gets an option value
        /// </summary>
        [PublicAPI]
        public DirectoryInfo Value => _option.IsSet ? _option.Value : null;

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public DirectoryInfoCliOption HelpText([NotNull] string text)
        {
            _option.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks option as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public DirectoryInfoCliOption Hidden(bool hidden = true)
        {
            _option.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets option default value provider
        /// </summary>
        [NotNull]
        public DirectoryInfoCliOption DefaultValue([NotNull] DefaultValueProvider<DirectoryInfo> provider)
        {
            _option.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets option default value
        /// </summary>
        [NotNull]
        public DirectoryInfoCliOption DefaultValue([NotNull] string defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out DirectoryInfo info)
            {
                info = new DirectoryInfo(defaultValue);
                return true;
            }
        }

        /// <summary>
        ///     Marks option as required
        /// </summary>
        [NotNull]
        public DirectoryInfoCliOption Required(string errorMessage = null)
        {
            _option.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public DirectoryInfoCliOption Validate([NotNull] ValueValidator<DirectoryInfo> validator)
        {
            _option.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified directory must exist
        /// </summary>
        [NotNull]
        public DirectoryInfoCliOption MustExist()
        {
            _option.Validate((value, isSet) =>
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
        public DirectoryInfoCliOption MustNotExist()
        {
            _option.Validate((value, isSet) =>
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
        public static implicit operator bool(DirectoryInfoCliOption option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="DirectoryInfo"/>
        /// </summary>
        public static implicit operator DirectoryInfo(DirectoryInfoCliOption option) => option.Value;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string(DirectoryInfoCliOption option) => option.Value.FullName;

        #endregion
    }
}