using System;
using System.IO;
using System.Text;
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
            builder.Draw(str => writer.WriteLine((ColoredString)str), maxWidth);
        }

        /// <summary>
        ///     Draws table to specified writer
        /// </summary>
        [PublicAPI]
        public static void Draw([NotNull] this ITableBuilderBase builder, [NotNull] Action<string> writer, int? maxWidth = null)
        {
            using (var w = new CallbackTextWriter(writer))
            {
                builder.Draw(w, maxWidth);
            }
        }

        /// <summary>
        ///     Draws table to string
        /// </summary>
        [PublicAPI]
        public static void Draw([NotNull] this ITableBuilderBase builder, [NotNull] StringBuilder stringBuilder, int? maxWidth = null)
        {
            builder.Draw(str => stringBuilder.AppendLine(str), maxWidth);
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

        internal sealed class CallbackTextWriter : TextWriter
        {
            private readonly StringBuilder _buffer = new StringBuilder();
            private readonly Action<string> _callback;
            private bool _everFlushed;

            public CallbackTextWriter(Action<string> callback)
            {
                _callback = callback;
            }

            public override Encoding Encoding => Encoding.UTF8;

            public override void Write(char value)
            {
                switch (value)
                {
                    case '\r':
                        break;
                    case '\n':
                        FlushBuffer(_everFlushed);
                        break;
                    default:
                        _buffer.Append(value);
                        break;
                }
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);

                FlushBuffer();
            }

            private void FlushBuffer(bool force = false)
            {
                if (_buffer.Length > 0 || force)
                {
                    var str = _buffer.ToString();
                    _callback(str);
                    _buffer.Clear();

                    _everFlushed = true;
                }
            }
        }
    }
}