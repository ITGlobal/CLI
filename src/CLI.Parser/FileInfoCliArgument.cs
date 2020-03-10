using System.IO;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliArgument{T}"/> that contains a <see cref="System.IO.FileInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class FileInfoCliArgument
    {
        #region fields

        private readonly CliArgument<FileInfo> _argument;

        #endregion

        #region .ctor

        internal FileInfoCliArgument(CliArgument<FileInfo> argument)
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
        public FileInfo Value => _argument.IsSet ? _argument.Value : null;
        
        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public FileInfoCliArgument HelpText([NotNull] string text)
        {
            _argument.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks argument as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public FileInfoCliArgument Hidden(bool hidden = true)
        {
            _argument.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets argument default value provider
        /// </summary>
        [NotNull]
        public FileInfoCliArgument DefaultValue([NotNull] DefaultValueProvider<FileInfo> provider)
        {
            _argument.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public FileInfoCliArgument DefaultValue([NotNull] string defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out FileInfo info)
            {
                info = new FileInfo(defaultValue);
                return true;
            }
        }

        /// <summary>
        ///     Marks argument as required
        /// </summary>
        [NotNull]
        public FileInfoCliArgument Required(string errorMessage = null)
        {
            _argument.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public FileInfoCliArgument Validate([NotNull] ValueValidator<FileInfo> validator)
        {
            _argument.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified file must exist
        /// </summary>
        [NotNull]
        public FileInfoCliArgument MustExist()
        {
            _argument.Validate((value, isSet) =>
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
        public FileInfoCliArgument MustNotExist()
        {
            _argument.Validate((value, isSet) =>
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
        public static implicit operator bool(FileInfoCliArgument option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="FileInfo"/>
        /// </summary>
        public static implicit operator FileInfo(FileInfoCliArgument option) => option.Value;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string(FileInfoCliArgument option) => option.Value.FullName;

        #endregion
    }
}