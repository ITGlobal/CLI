using JetBrains.Annotations;
using System;
using System.IO;

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

        /// <summary>
        ///     Converts option's value to nullable
        /// </summary>
        public static T? ToNullable<T>(this CliOption<T> option)
            where T : struct
        {
            return option.IsSet ? option.Value : (T?)null;
        }

        #region FileOption

        /// <summary>
        ///     Add a command line option that is parsed as <see cref="System.IO.FileInfo"/>
        /// </summary>
        public static FileInfoCliOption FileOption(
            this ICliOptionRoot root,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.Option<FileInfo>(shortName, longName, helpText, hidden);
            argument.UseParser(ValueParser.FileInfo);
            return new FileInfoCliOption(argument);
        }

        /// <summary>
        ///     Add a command line option that is parsed as <see cref="System.IO.FileInfo"/>
        /// </summary>
        public static FileInfoCliOption FileOption(
            this ICliOptionRoot root,
            string longName,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.Option<FileInfo>(longName, helpText, hidden);
            argument.UseParser(ValueParser.FileInfo);
            return new FileInfoCliOption(argument);
        }

        /// <summary>
        ///     Add a command line repeatable option that is parsed as <see cref="System.IO.FileInfo"/>
        /// </summary>
        public static FileInfoCliRepeatableOption RepeatableFileOption(
            this ICliOptionRoot root,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.RepeatableOption<FileInfo>(shortName, longName, helpText, hidden);
            argument.UseParser(ValueParser.FileInfo);
            return new FileInfoCliRepeatableOption(argument);
        }

        /// <summary>
        ///     Add a command line repeatable option that is parsed as <see cref="System.IO.FileInfo"/>
        /// </summary>
        public static FileInfoCliRepeatableOption RepeatableFileOption(
            this ICliOptionRoot root,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.RepeatableOption<FileInfo>(longName, helpText, hidden);
            argument.UseParser(ValueParser.FileInfo);
            return new FileInfoCliRepeatableOption(argument);
        }

        #endregion

        #region FileOption

        /// <summary>
        ///     Add a command line option that is parsed as <see cref="System.IO.DirectoryInfo"/>
        /// </summary>
        public static DirectoryInfoCliOption DirectoryOption(
            this ICliOptionRoot root,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.Option<DirectoryInfo>(shortName, longName, helpText, hidden);
            argument.UseParser(ValueParser.DirectoryInfo);
            return new DirectoryInfoCliOption(argument);
        }

        /// <summary>
        ///     Add a command line option that is parsed as <see cref="System.IO.DirectoryInfo"/>
        /// </summary>
        public static DirectoryInfoCliOption DirectoryOption(
            this ICliOptionRoot root,
            string longName,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.Option<DirectoryInfo>(longName, helpText, hidden);
            argument.UseParser(ValueParser.DirectoryInfo);
            return new DirectoryInfoCliOption(argument);
        }

        /// <summary>
        ///     Add a command line repeatable option that is parsed as <see cref="System.IO.DirectoryInfo"/>
        /// </summary>
        public static DirectoryInfoCliRepeatableOption RepeatableDirectoryOption(
            this ICliOptionRoot root,
            char shortName,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.RepeatableOption<DirectoryInfo>(shortName, longName, helpText, hidden);
            argument.UseParser(ValueParser.DirectoryInfo);
            return new DirectoryInfoCliRepeatableOption(argument);
        }

        /// <summary>
        ///     Add a command line repeatable option that is parsed as <see cref="System.IO.DirectoryInfo"/>
        /// </summary>
        public static DirectoryInfoCliRepeatableOption RepeatableDirectoryOption(
            this ICliOptionRoot root,
            string longName = null,
            string helpText = null,
            bool hidden = false)
        {
            var argument = root.RepeatableOption<DirectoryInfo>(longName, helpText, hidden);
            argument.UseParser(ValueParser.DirectoryInfo);
            return new DirectoryInfoCliRepeatableOption(argument);
        }

        #endregion
    }
}
