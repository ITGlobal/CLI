using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Temporarily changes input and output encoding
        /// </summary>
        [PublicAPI]
        public static IDisposable WithEncoding(Encoding inputEncoding, Encoding outputEncoding)
            => new EncodingChangeToken(inputEncoding, outputEncoding);

        /// <summary>
        ///     Temporarily changes input encoding
        /// </summary>
        [PublicAPI]
        public static IDisposable WithInputEncoding(Encoding encoding)
            => new EncodingChangeToken(encoding, null);

        /// <summary>
        ///     Temporarily changes output encoding
        /// </summary>
        [PublicAPI]
        public static IDisposable WithOutputEncoding(Encoding encoding)
            => new EncodingChangeToken(null, encoding);
    }
}
