using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Table.Impl
{
    internal sealed class CallbackTextWriter : TextWriter
    {
        private readonly StringBuilder _buffer = new StringBuilder();
        private readonly Action<string> _callback;
        private bool _everFlushed;

        public CallbackTextWriter(Action<string> callback)
        {
            _callback = callback;
        }

        public override Encoding Encoding => Encoding.UTF8;

        public override void Write(char value)
        {
            switch (value)
            {
                case '\r':
                    break;
                case '\n':
                    FlushBuffer(_everFlushed);
                    break;
                default:
                    _buffer.Append(value);
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            FlushBuffer();
        }

        private void FlushBuffer(bool force = false)
        {
            if (_buffer.Length > 0 || force)
            {
                var str = _buffer.ToString();
                _callback(str);
                _buffer.Clear();

                _everFlushed = true;
            }
        }
    }
}