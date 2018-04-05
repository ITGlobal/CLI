using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Extension methods for <see cref="CliRepeatableArgument{T}"/>
    /// </summary>
    [PublicAPI]
    public static class CliRepeatableArgumentExtensions
    {
        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public static CliRepeatableArgument<T> DefaultValue<T>(this CliRepeatableArgument<T> option, params T[] defaultValues)
        {
            bool Provider(out T[] values)
            {
                values = defaultValues;
                return true;
            }

            return option.DefaultValue(Provider);
        }

        /// <summary>
        ///     Binds option argument value to an environment variable
        /// </summary>
        [NotNull]
        public static CliRepeatableArgument<T> FromEnvironmentVariable<T>(this CliRepeatableArgument<T> option, string name)
        {
            bool Provider(out T[] values)
            {
                values = default(T[]);

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

                var value = result.Value;
                values = new[] { value };
                return true;
            }

            return option.DefaultValue(Provider);
        }
    }
}