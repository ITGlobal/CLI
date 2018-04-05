using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Extension methods for <see cref="CliArgument{T}"/>
    /// </summary>
    [PublicAPI]
    public static class CliArgumentExtensions
    {
        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public static CliArgument<T> DefaultValue<T>(this CliArgument<T> option, T defaultValue)
        {
            bool Provider(out T value)
            {
                value = defaultValue;
                return true;
            }

            return option.DefaultValue(Provider);
        }

        /// <summary>
        ///     Binds option argument value to an environment variable
        /// </summary>
        [NotNull]
        public static CliArgument<T> FromEnvironmentVariable<T>(this CliArgument<T> option, string name)
        {
            bool Provider(out T value)
            {
                value = default(T);

                var env = Environment.GetEnvironmentVariable(name);
                if (string.IsNullOrEmpty(env))
                {
                    return false;
                }

                var result = option.Parser.Parse(env);
                if (!result.IsSuccess)
                {
                    return false;
                }

                value = result.Value;
                return true;
            }

            return option.DefaultValue(Provider);
        }
    }
}