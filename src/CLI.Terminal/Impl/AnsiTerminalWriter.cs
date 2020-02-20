using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class AnsiTerminalWriter : TerminalWriterBase
    {
        private readonly TextWriter _writer;

        public AnsiTerminalWriter(TextWriter writer)
        {
            _writer = writer;
        }

        public override void Write(AnsiString.Chunk str)
        {
            var sgr = Ansi.SGR(str.ForegroundColor, str.BackgroundColor);
            var hasSgr = !string.IsNullOrEmpty(sgr);
            if (hasSgr)
            {
                _writer.Write(sgr);
            }

            _writer.Write(str.Buffer, str.Offset, str.Length);

            if (hasSgr)
            {
                _writer.Write(Ansi.SGR_DEFAULT);
            }
        }
    }
}