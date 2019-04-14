using System;
using System.Text;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Provides methods to temporarily change terminal encoding
    /// </summary>
    [PublicAPI]
    public static class TerminalEncodingHelper
    {
        internal sealed class EncodingChangeToken : IDisposable
        {
            private readonly ITerminal _terminal;
            private readonly Encoding _originalInputEncoding;
            private readonly Encoding _originalOutputEncoding;
            private readonly Encoding _originalErrorEncoding;

            public EncodingChangeToken(ITerminal terminal, Encoding inputEncoding, Encoding outputEncoding)
            {
                _terminal = terminal;
                _originalInputEncoding = _terminal.Stdin.Encoding;
                _originalOutputEncoding = _terminal.Stdout.Encoding;
                _originalErrorEncoding = _terminal.Stderr.Encoding;

                if (inputEncoding != null)
                {
                    _terminal.Stdin.Encoding = inputEncoding;
                }

                if (outputEncoding != null)
                {
                    _terminal.Stdout.Encoding = outputEncoding;
                    _terminal.Stderr.Encoding = outputEncoding;
                }
            }

            public void Dispose()
            {
                _terminal.Stdin.Encoding = _originalInputEncoding;
                _terminal.Stdout.Encoding = _originalOutputEncoding;
                _terminal.Stderr.Encoding = _originalErrorEncoding;
            }
        }
        /// <summary>
        ///     Temporarily changes input and output encoding
        /// </summary>
        [PublicAPI]
        public static IDisposable WithEncoding(this ITerminal terminal, Encoding inputEncoding, Encoding outputEncoding)
            => new EncodingChangeToken(terminal, inputEncoding, outputEncoding);

        /// <summary>
        ///     Temporarily changes input encoding
        /// </summary>
        [PublicAPI]
        public static IDisposable WithInputEncoding(this ITerminal terminal, Encoding encoding)
            => new EncodingChangeToken(terminal, encoding, null);

        /// <summary>
        ///     Temporarily changes output encoding
        /// </summary>
        [PublicAPI]
        public static IDisposable WithOutputEncoding(this ITerminal terminal, Encoding encoding)
            => new EncodingChangeToken(terminal, null, encoding);
    }
}