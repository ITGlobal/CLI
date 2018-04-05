using System;
using System.IO;
using System.Text;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal standard output/error wrapper
    /// </summary>
    [PublicAPI]
    public interface ITerminalOutput
    {
        /// <summary>
        ///     Returns true if standard output/error is redirected
        /// </summary>
        bool IsRedirected { get; }

        /// <summary>
        ///     Standard output/error encoding
        /// </summary>
        [NotNull]
        Encoding Encoding { get; set; }

        /// <summary>
        ///     Terminal window height
        /// </summary>
        int WindowHeight { get; }

        /// <summary>
        ///     Terminal window width
        /// </summary>
        int WindowWidth { get; }

        /// <summary>
        ///     Gets or sets cursor visibility
        /// </summary>
        bool IsCursorVisible { get; set; }

        /// <summary>
        ///     Created a writer for standard output/error stream
        /// </summary>
        [NotNull]
        TextWriter CreateWriter();

        /// <summary>
        ///     Moves cursor
        /// </summary>
        void MoveCursor(int? left = null, int? top = null);

        /// <summary>
        ///     Writes a colored string
        /// </summary>
        void Write(TerminalString str);

        /// <summary>
        ///     Writes a list of colored strings
        /// </summary>
        void Write(params TerminalString[] strs);

        /// <summary>
        ///     Writes a formatted colored string
        /// </summary>
        [StringFormatMethod("format")]
        void Write(string format, params object[] args);

        /// <summary>
        ///     Writes a newline
        /// </summary>
        void WriteLine();

        /// <summary>
        ///     Writes a colored string with a newline
        /// </summary>
        void WriteLine(TerminalString str);

        /// <summary>
        ///     Writes a list of colored strings with a newline
        /// </summary>
        void WriteLine(params TerminalString[] strs);

        /// <summary>
        ///     Writes a formatted colored string with a newline
        /// </summary>
        [StringFormatMethod("format")]
        void WriteLine(string format, params object[] args);

        /// <summary>
        ///     Clear terminal
        /// </summary>
        void Clear();

        /// <summary>
        ///     Set default foreground and background colors
        /// </summary>
        ColorChangeToken WithColors(ConsoleColor? fg, ConsoleColor? bg);

        /// <summary>
        ///     Set default foreground color
        /// </summary>
        ColorChangeToken WithForeground(ConsoleColor color);

        /// <summary>
        ///     Set default background color
        /// </summary>
        ColorChangeToken WithBackground(ConsoleColor color);
    }
}