using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliRepeatableOption{T}"/> that contains a <see cref="System.IO.FileInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class FileInfoCliRepeatableOption
    {
        #region fields

        private readonly CliRepeatableOption<FileInfo> _option;

        #endregion

        #region .ctor

        internal FileInfoCliRepeatableOption(CliRepeatableOption<FileInfo> option)
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
        public FileInfo[] Values => _option.IsSet ? _option.Values : null;

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption HelpText([NotNull] string text)
        {
            _option.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks option as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption Hidden(bool hidden = true)
        {
            _option.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets option default value provider
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption DefaultValue([NotNull] DefaultValueProvider<FileInfo[]> provider)
        {
            _option.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets option default value
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption DefaultValue([NotNull] params string[] defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out FileInfo[] infos)
            {
                infos = defaultValue.Select(p => new FileInfo(p)).ToArray();
                return true;
            }
        }

        /// <summary>
        ///     Marks option as required
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption Required(string errorMessage = null)
        {
            _option.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption Validate([NotNull] ValueValidator<FileInfo[]> validator)
        {
            _option.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified files must exist
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption MustExist()
        {
            _option.Validate((value, isSet) =>
            {
                if (!isSet || value == null)
                {
                    return null;
                }

                foreach (var info in value)
                {
                    if (!info.Exists)
                    {
                        return $"File \"{info.FullName}\" doesn't exist";
                    }
                }

                return null;
            });

            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified files must not exist
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableOption MustNotExist()
        {
            _option.Validate((value, isSet) =>
            {
                if (!isSet || value == null)
                {
                    return null;
                }

                foreach (var info in value)
                {
                    if (!info.Exists)
                    {
                        return $"File \"{info.FullName}\" already exists";
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
        public static implicit operator bool(FileInfoCliRepeatableOption option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="FileInfo"/>
        /// </summary>
        public static implicit operator FileInfo[](FileInfoCliRepeatableOption option) => option.Values;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string[](FileInfoCliRepeatableOption option)
            => option.Values.Select(_ => _.FullName).ToArray();

        #endregion
    }
}