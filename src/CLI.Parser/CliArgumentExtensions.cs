using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Parsing
{
    /// <summary>
    ///     Extension methods for <see cref="CliOption{T}"/>
    /// </summary>
    [PublicAPI]
    public static class CliArgumentExtensions
    {
        /// <summary>
        ///     Sets argument default value
        /// </summary>
        [NotNull]
        public static CliArgument<T> DefaultValue<T>(this CliArgument<T> argument, T defaultValue)
        {
            bool Provider(out T value)
            {
                value = defaultValue;
                return true;
            }

            return argument.DefaultValue(Provider);
        }

        /// <summary>
        ///     Binds argument argument value to an environment variable
        /// </summary>
        [NotNull]
        public static CliArgument<T> FromEnvironmentVariable<T>(this CliArgument<T> argument, string name)
        {
            bool Provider(out T value)
            {
                value = default(T);

                var env = Environment.GetEnvironmentVariable(name);
                if (string.IsNullOrEmpty(env))
                {
                    return false;
                }

                var result = argument.Parser.Parse(env);
                if (!result.IsSuccess)
                {
                    return false;
                }

                value = result.Value;
                return true;
            }

            return argument.DefaultValue(Provider);
        }

        /// <summary>
        ///     Converts argument's value to nullable
        /// </summary>
        public static T? ToNullable<T>(this CliArgument<T> argument)
            where T : struct
        {
            return argument.IsSet ? argument.Value : (T?)null;
        }

        #region FileArgument

        /// <summary>
        ///     Add a command line positional argument that is parsed as <see cref="System.IO.FileInfo"/>
        /// </summary>
        public static FileInfoCliArgument FileArgument(
            this ICliArgumentRoot root,
            string displayName,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.Argument(displayName, helpText, hidden, ValueParser.FileInfo);
            return new FileInfoCliArgument(argument);
        }

        /// <summary>
        ///     Add a command line repeatable positional argument that is parsed as <see cref="System.IO.FileInfo"/>
        /// </summary>
        public static FileInfoCliRepeatableArgument RepeatableFileArgument(
            this ICliArgumentRoot root,
            string displayName,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.RepeatableArgument(displayName, helpText, hidden, ValueParser.FileInfo);
            return new FileInfoCliRepeatableArgument(argument);
        }

        #endregion

        #region DirectoryArgument

        /// <summary>
        ///     Add a command line positional argument that is parsed as <see cref="System.IO.DirectoryInfo"/>
        /// </summary>
        public static DirectoryInfoCliArgument DirectoryArgument(
            this ICliArgumentRoot root,
            string displayName,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.Argument(displayName, helpText, hidden, ValueParser.DirectoryInfo);
            return new DirectoryInfoCliArgument(argument);
        }

        /// <summary>
        ///     Add a command line repeatable positional argument that is parsed as <see cref="System.IO.DirectoryInfo"/>
        /// </summary>
        public static DirectoryInfoCliRepeatableArgument RepeatableDirectoryArgument(
            this ICliArgumentRoot root,
            string displayName,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.RepeatableArgument(displayName, helpText, hidden, ValueParser.DirectoryInfo);
            return new DirectoryInfoCliRepeatableArgument(argument);
        }

        #endregion
    }
}