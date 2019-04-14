using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    [PublicAPI]
    public static class NullableWrapperExtensions
    {
        /// <summary>
        ///     Create a nullable wrapper for <see cref="CliArgument{T}"/>
        /// </summary>
        [NotNull]
        public static NullableCliArgument<T> AsNullable<T>(this CliArgument<T> argument)
            where T : struct
            => new NullableCliArgument<T>(argument);

        /// <summary>
        ///     Create a nullable wrapper for <see cref="CliOption{T}"/>
        /// </summary>
        [NotNull]
        public static NullableCliOption<T> AsNullable<T>(this CliOption<T> argument)
            where T : struct
            => new NullableCliOption<T>(argument);
    }
}