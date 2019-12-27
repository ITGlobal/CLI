using System;
using System.Text;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A disposable token for terminal encoding change
    /// </summary>
    public readonly struct EncodingChangeToken : IDisposable
    {
        private readonly Encoding _originalInputEncoding;
        private readonly Encoding _originalOutputEncoding;

        /// <summary>
        ///     .ctor
        /// </summary>
        internal EncodingChangeToken(Encoding inputEncoding, Encoding outputEncoding)
        {
            _originalInputEncoding = Console.InputEncoding;
            _originalOutputEncoding = Console.OutputEncoding;

            if (inputEncoding != null)
            {
                Console.InputEncoding = inputEncoding;
            }

            if (outputEncoding != null)
            {
                Console.OutputEncoding = outputEncoding;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_originalInputEncoding != null)
            {
                Console.InputEncoding = _originalInputEncoding;
            }

            if (_originalOutputEncoding != null)
            {
                Console.OutputEncoding = _originalOutputEncoding;
            }
        }
    }
}