using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Result for <see cref="IValueParser{T}"/>
    /// </summary>
    [PublicAPI]
    public struct ValueParserResult<T>
    {
        internal ValueParserResult(T value, bool isSuccess, string errorMessage)
        {
            Value = value;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        internal T Value { get; }
        internal bool IsSuccess { get; }
        internal string ErrorMessage { get; }
    }

    /// <summary>
    ///     Factory for <see cref="ValueParserResult{T}"/>
    /// </summary>
    [PublicAPI]
    public static class ValueParserResult
    {
        /// <summary>
        ///     Creates successful result
        /// </summary>
        public static ValueParserResult<T> Success<T>(T value)
            => new ValueParserResult<T>(value, true, null);

        /// <summary>
        ///     Creates unsuccessful result
        /// </summary>
        public static ValueParserResult<T> Error<T>([NotNull] string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException(nameof(errorMessage));
            }

            return new ValueParserResult<T>(default(T), false, errorMessage);
        }
    }
}