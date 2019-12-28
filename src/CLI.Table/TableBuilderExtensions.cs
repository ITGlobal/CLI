using System;
using System.IO;
using System.Text;
using ITGlobal.CommandLine.Impl;
using ITGlobal.CommandLine.Table.Impl;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Table
{
    /// <summary>
    ///     Extension methods for <see cref="ITableBuilderBase"/>
    /// </summary>
    [PublicAPI]
    public static class TableBuilderExtensions
    {
        /// <summary>
        ///     Draws table to screen
        /// </summary>
        [PublicAPI]
        public static void Draw([NotNull] this ITableBuilderBase builder, int? maxWidth = null)
        {
            builder.Draw(Console.Out, maxWidth);
        }

        /// <summary>
        ///     Draws table to specified writer
        /// </summary>
        [PublicAPI]
        public static void Draw([NotNull] this ITableBuilderBase builder, [NotNull] ITerminalWriter writer, int? maxWidth = null)
        {
            builder.Draw(str => writer.WriteLine((AnsiString)str), maxWidth);
        }

        /// <summary>
        ///     Draws table to specified writer
        /// </summary>
        [PublicAPI]
        public static void Draw([NotNull] this ITableBuilderBase builder, [NotNull] Action<string> writer, int? maxWidth = null, bool trimAnsi = true)
        {
            TextWriter w = new CallbackTextWriter(writer);
            if (trimAnsi)
            {
                w = new TrimAnsiTextWriter(w);
            }

            using (w)
            {
                builder.Draw(w, maxWidth);
            }
        }

        /// <summary>
        ///     Draws table to string
        /// </summary>
        [PublicAPI]
        public static void Draw([NotNull] this ITableBuilderBase builder, [NotNull] StringBuilder stringBuilder, int? maxWidth = null, bool trimAnsi = true)
        {
            builder.Draw(str => stringBuilder.AppendLine(str), maxWidth, trimAnsi);
        }

        /// <summary>
        ///     Draws table to string
        /// </summary>
        [PublicAPI]
        public static string DrawToString([NotNull] this ITableBuilderBase builder, int? maxWidth = null)
        {
            var stringBuilder = new StringBuilder();
            builder.Draw(stringBuilder, maxWidth);
            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Draws table to ANSI string
        /// </summary>
        [PublicAPI]
        public static string DrawToAnsiString([NotNull] this ITableBuilderBase builder, int? maxWidth = null)
        {
            var stringBuilder = new StringBuilder();
            builder.Draw(stringBuilder, maxWidth, trimAnsi: false);
            return stringBuilder.ToString();
        }
    }
}