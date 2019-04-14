using System;
using System.IO;
using System.Text;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal standard input wrapper
    /// </summary>
    [PublicAPI]
    public interface ITerminalInput
    {
        /// <summary>
        ///     Returns true if standard input is redirected
        /// </summary>
        bool IsRedirected { get; }

        /// <summary>
        ///     Standard input encoding
        /// </summary>
        [NotNull]
        Encoding Encoding { get; set; }

        /// <summary>
        ///     Created a reader for standard input stream
        /// </summary>
        [NotNull]
        TextReader CreateReader();

        /// <summary>
        ///     Attaches a temporary CtrlC/SIGINT handler
        /// </summary>
        [NotNull]
        IDisposable AttachCancelKeyHandler(CancelKeyHandler handler);

        /// <summary>
        ///     Reads a key from a standard input stream
        /// </summary>
        ConsoleKeyInfo ReadKey(bool intercept = true);
    }
}