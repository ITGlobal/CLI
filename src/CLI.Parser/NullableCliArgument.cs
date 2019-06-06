using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     A nullable wrapper for <see cref="CliArgument{T}"/>
    /// </summary>
    [PublicAPI]
    public sealed class NullableCliArgument<T>
        where T : struct
    {
        #region fields

        private readonly CliArgument<T> _argument;

        #endregion

        #region .ctor

        internal NullableCliArgument(CliArgument<T> argument)
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
        public T? Value => _argument.IsSet ? _argument.Value : (T?)null;

        /// <summary>
        ///     Argument name
        /// </summary>
        [NotNull]
        internal string Name => _argument.Name;

        #endregion

        #region operators

        /// <summary>
        ///     Implicit convertion to boolean
        /// </summary>
        public static implicit operator bool(NullableCliArgument<T> option) => option.IsSet;

        /// <summary>
        ///     Implicit convertion to T?
        /// </summary>
        public static implicit operator T? (NullableCliArgument<T> option) => option.Value;

        #endregion
    }
}