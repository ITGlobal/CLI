using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class EncodingChangeToken : IDisposable
    {
        private readonly Encoding _originalInputEncoding;
        private readonly Encoding _originalOutputEncoding;

        public EncodingChangeToken(Encoding inputEncoding, Encoding outputEncoding)
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
            Console.InputEncoding = _originalInputEncoding;
            Console.OutputEncoding = _originalOutputEncoding;
        }
    }
}