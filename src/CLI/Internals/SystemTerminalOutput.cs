using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Internals
{
    /// <summary>
    ///     Terminal standard output/error wrapper
    /// </summary>
    internal sealed class SystemTerminalOutput : ITerminalOutput
    {
        private readonly TextWriter _writer;

        public SystemTerminalOutput(TextWriter writer, bool isRedirected)
        {
            _writer = writer;
            IsRedirected = isRedirected;
        }

        /// <summary>
        ///     Returns true if standard output/error is redirected
        /// </summary>
        public bool IsRedirected { get; }

        /// <summary>
        ///     Standard output/error encoding
        /// </summary>
        public Encoding Encoding
        {
            get => Console.OutputEncoding;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Console.OutputEncoding = value;
            }
        }

        /// <summary>
        ///     Terminal window height
        /// </summary>
        public int WindowHeight => Console.WindowHeight;

        /// <summary>
        ///     Terminal window width
        /// </summary>
        public int WindowWidth => Console.WindowWidth;

        /// <summary>
        ///     Gets or sets cursor visibility
        /// </summary>
        public bool IsCursorVisible
        {
            get => Console.CursorVisible;
            set => Console.CursorVisible  = value;
        }

        /// <summary>
        ///     Created a writer for standard output/error stream
        /// </summary>
        public TextWriter CreateWriter() => new StdTextWriter(_writer);

        /// <summary>
        ///     Moves cursor
        /// </summary>
        public void MoveCursor(int? left = null, int? top = null)
        {
            if (left != null)
            {
                Console.CursorLeft = left.Value;
            }

            if (top != null)
            {
                Console.CursorTop = top.Value;
            }
        }

        /// <summary>
        ///     Writes a colored string
        /// </summary>
        public void Write(TerminalString str)
        {
            using (WithColors(str.ForegroundColor, str.BackgroundColor))
            {
                _writer.Write(str.Value);
            }
        }

        /// <summary>
        ///     Writes a list of colored strings
        /// </summary>
        public void Write(params TerminalString[] strs)
        {
            if (strs == null)
            {
                throw new ArgumentNullException(nameof(strs));
            }

            foreach (var str in strs)
            {
                Write(str);
            }
        }

        /// <summary>
        ///     Writes a formatted colored string
        /// </summary>
        public void Write(string format, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var tokens = StringFormatParser.Tokenize(format, args);
            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case StringFormatParser.TokenType.Plain:
                        _writer.Write((string)token.Value);
                        break;

                    case StringFormatParser.TokenType.Field:
                        switch (token.Value)
                        {
                            case TerminalString str:
                                Write(str);
                                break;

                            case null:
                                break;

                            default:
                                _writer.Write(token.Value);
                                break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        ///     Writes a newline
        /// </summary>
        public void WriteLine()
        {
            _writer.WriteLine();
        }

        /// <summary>
        ///     Writes a colored string with a newline
        /// </summary>
        public void WriteLine(TerminalString str)
        {
            Write(str);
            WriteLine();
        }

        /// <summary>
        ///     Writes a list of colored strings with a newline
        /// </summary>
        public void WriteLine(params TerminalString[] strs)
        {
            Write(strs);
            WriteLine();
        }

        /// <summary>
        ///     Writes a formatted colored string with a newline
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            Write(format, args);
            WriteLine();
        }

        /// <summary>
        ///     Clear terminal
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        ///     Set default foreground and background colors
        /// </summary>
        public ColorChangeToken WithColors(ConsoleColor? fg, ConsoleColor? bg)
            => new ColorChangeToken(fg, bg);

        /// <summary>
        ///     Set default foreground color
        /// </summary>
        public ColorChangeToken WithForeground(ConsoleColor color)
            => new ColorChangeToken(color, null);

        /// <summary>
        ///     Set default background color
        /// </summary>
        public ColorChangeToken WithBackground(ConsoleColor color)
            => new ColorChangeToken(null, color);

        private sealed class StdTextWriter : TextWriter
        {
            private readonly TextWriter _writer;

            public StdTextWriter(TextWriter writer)
            {
                _writer = writer;
            }

            public override Encoding Encoding => _writer.Encoding;

            public override void Write(char value) => _writer.Write(value);
        }
    }
}