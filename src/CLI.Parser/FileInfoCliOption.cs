using System.IO;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliOption{T}"/> that contains a <see cref="System.IO.FileInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class FileInfoCliOption
    {
        #region fields

        private readonly CliOption<FileInfo> _option;

        #endregion

        #region .ctor

        internal FileInfoCliOption(CliOption<FileInfo> option)
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
        public FileInfo Value => _option.IsSet ? _option.Value : null;

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public FileInfoCliOption HelpText([NotNull] string text)
        {
            _option.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks option as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public FileInfoCliOption Hidden(bool hidden = true)
        {
            _option.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets option default value provider
        /// </summary>
        [NotNull]
        public FileInfoCliOption DefaultValue([NotNull] DefaultValueProvider<FileInfo> provider)
        {
            _option.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets option default value
        /// </summary>
        [NotNull]
        public FileInfoCliOption DefaultValue([NotNull] string defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out FileInfo info)
            {
                info = new FileInfo(defaultValue);
                return true;
            }
        }

        /// <summary>
        ///     Marks option as required
        /// </summary>
        [NotNull]
        public FileInfoCliOption Required(string errorMessage = null)
        {
            _option.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public FileInfoCliOption Validate([NotNull] ValueValidator<FileInfo> validator)
        {
            _option.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified file must exist
        /// </summary>
        [NotNull]
        public FileInfoCliOption MustExist()
        {
            _option.Validate((value, isSet) =>
            {
                if (!isSet)
                {
                    return null;
                }

                if (!value.Exists)
                {
                    return $"File \"{value.FullName}\" doesn't exist";
                }

                return null;
            });

            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified file must not exist
        /// </summary>
        [NotNull]
        public FileInfoCliOption MustNotExist()
        {
            _option.Validate((value, isSet) =>
            {
                if (!isSet)
                {
                    return null;
                }

                if (!value.Exists)
                {
                    return $"File \"{value.FullName}\" already exists";
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
        public static implicit operator bool(FileInfoCliOption option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="FileInfo"/>
        /// </summary>
        public static implicit operator FileInfo(FileInfoCliOption option) => option.Value;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string(FileInfoCliOption option) => option.Value.FullName;

        #endregion
    }
}