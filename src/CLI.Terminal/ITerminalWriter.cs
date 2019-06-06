using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal standard output/error writer
    /// </summary>
    [PublicAPI]
    public interface ITerminalWriter
    {
        /// <summary>
        ///     Writes a colored string
        /// </summary>
        void Write(ColoredString str);

#if !NET45
        /// <summary>
        ///     Writes a colored string
        /// </summary>
        void Write(System.FormattableString str);
#endif

        /// <summary>
        ///     Writes a list of colored strings
        /// </summary>
        void Write(params ColoredString[] strs);

#if !NET45
        /// <summary>
        ///     Writes a colored string with a newline
        /// </summary>
        void WriteLine(System.FormattableString str);
#endif

        /// <summary>
        ///     Writes a colored string with a newline
        /// </summary>
        void WriteLine(ColoredString str);

        /// <summary>
        ///     Writes a list of colored strings with a newline
        /// </summary>
        void WriteLine(params ColoredString[] strs);

        /// <summary>
        ///     Writes a newline
        /// </summary>
        void WriteLine();
    }
}