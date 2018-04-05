using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Extension methods for <see cref="CliOption{T}"/>
    /// </summary>
    [PublicAPI]
    public static class CliOptionExtensions
    {
        /// <summary>
        ///     Sets option default value
        /// </summary>
        [NotNull]
        public static CliOption<T> DefaultValue<T>(this CliOption<T> option, T defaultValue)
        {
            bool Provider(out T value)
            {
                value = defaultValue;
                return true;
            }

            return option.DefaultValue(Provider);
        }

        /// <summary>
        ///     Binds option default value to an environment variable
        /// </summary>
        [NotNull]
        public static CliOption<T> FromEnvironmentVariable<T>(this CliOption<T> option, string name)
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
