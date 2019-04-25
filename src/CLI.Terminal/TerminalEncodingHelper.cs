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
        /// <summary>
        ///     Temporarily changes input and output encoding
        /// </summary>
        [PublicAPI]
        public static EncodingChangeToken WithEncoding(Encoding inputEncoding = null, Encoding outputEncoding = null)
            => new EncodingChangeToken(inputEncoding, outputEncoding);

        /// <summary>
        ///     Temporarily changes input encoding
        /// </summary>
        [PublicAPI]
        public static EncodingChangeToken WithInputEncoding(Encoding encoding)
            => new EncodingChangeToken(encoding, null);

        /// <summary>
        ///     Temporarily changes output encoding
        /// </summary>
        [PublicAPI]
        public static EncodingChangeToken WithOutputEncoding(Encoding encoding)
            => new EncodingChangeToken(null, encoding);
    }
}