using System;
using System.Text;

namespace ITGlobal.CommandLine
{
    public readonly struct EncodingChangeToken : IDisposable
    {
        private readonly Encoding _originalInputEncoding;
        private readonly Encoding _originalOutputEncoding;

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