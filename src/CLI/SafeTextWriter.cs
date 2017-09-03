using System.IO;
using System.Text;

namespace ITGlobal.CommandLine
{
    internal sealed class SafeTextWriter : TextWriter
    {
        private readonly TextWriter _writer;
        private readonly ISafeTextWriterOwner _progressBar;

        public SafeTextWriter(TextWriter writer, ISafeTextWriterOwner progressBar)
        {
            _writer = writer;
            _progressBar = progressBar;
        }

        public override Encoding Encoding => _writer.Encoding;

        public override void Write(char value)
        {
            _progressBar.BeginPrint();

            switch (value)
            {
                case '\n':
                    _writer.WriteLine();
                    _progressBar.Redraw();
                    break;
                case '\r':
                    break;
                default:
                    _writer.Write(value);
                    break;

            }

            _progressBar.EndPrint();
        }
    }
}