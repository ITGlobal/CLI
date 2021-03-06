using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A nullable wrapper for <see cref="CliOption{T}"/>
    /// </summary>
    [PublicAPI]
    public sealed class NullableCliOption<T>
        where T : struct
    {
        #region fields

        private readonly CliOption<T> _option;

        #endregion

        #region .ctor

        internal NullableCliOption(CliOption<T> option)
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
        public T? Value => _option.IsSet ? _option.Value : (T?)null;

        /// <summary>
        ///     option name
        /// </summary>
        [NotNull]
        internal string Name => _option.Name;

        #endregion

        #region operators

        /// <summary>
        ///     Implicit conversion to boolean
        /// </summary>
        public static implicit operator bool(NullableCliOption<T> option) => option.IsSet;

        /// <summary>
        ///     Implicit conversion to T?
        /// </summary>
        public static implicit operator T? (NullableCliOption<T> option) => option.Value;

        #endregion
    }
}