using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A wrapper for <see cref="CliRepeatableOption{T}"/> that contains a <see cref="System.IO.DirectoryInfo"/>
    /// </summary>
    [PublicAPI]
    public sealed class DirectoryInfoCliRepeatableOption
    {
        #region fields

        private readonly CliRepeatableOption<DirectoryInfo> _option;

        #endregion

        #region .ctor

        internal DirectoryInfoCliRepeatableOption(CliRepeatableOption<DirectoryInfo> option)
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
        public DirectoryInfo[] Values => _option.IsSet ? _option.Values : null;

        #endregion

        #region methods

        /// <summary>
        ///     Sets a help text
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableOption HelpText([NotNull] string text)
        {
            _option.HelpText(text);
            return this;
        }

        /// <summary>
        ///     Marks option as hidden (won't be shown in usage)
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableOption Hidden(bool hidden = true)
        {
            _option.Hidden(hidden);
            return this;
        }

        /// <summary>
        ///     Sets option default value provider
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableOption DefaultValue([NotNull] DefaultValueProvider<DirectoryInfo[]> provider)
        {
            _option.DefaultValue(provider);
            return this;
        }

        /// <summary>
        ///     Sets option default value
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableOption DefaultValue([NotNull] params string[] defaultValue)
        {
            return DefaultValue(Provider);

            bool Provider(out DirectoryInfo[] infos)
            {
                infos = defaultValue.Select(p => new DirectoryInfo(p)).ToArray();
                return true;
            }
        }

        /// <summary>
        ///     Marks option as required
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableOption Required(string errorMessage = null)
        {
            _option.Required(errorMessage);
            return this;
        }

        /// <summary>
        ///     Adds a value validator
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableOption Validate([NotNull] ValueValidator<DirectoryInfo[]> validator)
        {
            _option.Validate(validator);
            return this;
        }

        /// <summary>
        ///     Adds a value validator - specified directories must exist
        /// </summary>
        [NotNull]
        public DirectoryInfoCliRepeatableOption MustExist()
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
        public DirectoryInfoCliRepeatableOption MustNotExist()
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
        public static implicit operator bool(DirectoryInfoCliRepeatableOption option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to <see cref="DirectoryInfo"/>
        /// </summary>
        public static implicit operator DirectoryInfo[](DirectoryInfoCliRepeatableOption option) => option.Values;

        /// <summary>
        ///     Implicit conversion to <see cref="string"/>
        /// </summary>
        public static implicit operator string[](DirectoryInfoCliRepeatableOption option)
            => option.Values.Select(_ => _.FullName).ToArray();

        #endregion
    }
}