using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliRepeatableArgument{T}"/> that contains a <see cref="System.IO.FileInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class FileInfoCliRepeatableArgument
    {
        #region fields

        private readonly CliRepeatableArgument<FileInfo> _argument;

        #endregion

        #region .ctor

        internal FileInfoCliRepeatableArgument(CliRepeatableArgument<FileInfo> argument)
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
        public FileInfo[] Values => _argument.IsSet ? _argument.Values : null;
        
        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableArgument HelpText([NotNull] string text)
        {
            _argument.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks argument as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableArgument Hidden(bool hidden = true)
        {
            _argument.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets argument default value provider
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableArgument DefaultValue([NotNull] DefaultValueProvider<FileInfo[]> provider)
        {
            _argument.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableArgument DefaultValue([NotNull] params string[] defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out FileInfo[] infos)
            {
                infos = defaultValue.Select(p => new FileInfo(p)).ToArray();
                return true;
            }
        }

        /// <summary>
        ///     Marks argument as required
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableArgument Required(string errorMessage = null)
        {
            _argument.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableArgument Validate([NotNull] ValueValidator<FileInfo[]> validator)
        {
            _argument.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified files must exist
        /// </summary>
        [NotNull]
        public FileInfoCliRepeatableArgument MustExist()
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
        public FileInfoCliRepeatableArgument MustNotExist()
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
        public static implicit operator bool(FileInfoCliRepeatableArgument option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="FileInfo"/>
        /// </summary>
        public static implicit operator FileInfo[](FileInfoCliRepeatableArgument option) => option.Values;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string[](FileInfoCliRepeatableArgument option) 
            => option.Values.Select(_ => _.FullName).ToArray();

        #endregion
    }
}