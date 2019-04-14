using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Extension methods for <see cref="CliRepeatableOption{T}"/>
    /// </summary>
    [PublicAPI]
    public static class CliRepeatableOptionExtensions
    {
        /// <summary>
        ///     Sets option default value
        /// </summary>
        [NotNull]
        public static CliRepeatableOption<T> DefaultValue<T>(this CliRepeatableOption<T> option, params T[] defaultValues)
        {
            bool Provider(out T[] value)
            {
                value = defaultValues;
                return true;
            }

            return option.DefaultValue(Provider);
        }

        /// <summary>
        ///     Binds option default value to an environment variable
        /// </summary>
        [NotNull]
        public static CliRepeatableOption<T> FromEnvironmentVariable<T>(this CliRepeatableOption<T> option, string name)
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