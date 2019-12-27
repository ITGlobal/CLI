namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TrimAnsiTerminalWriter : TerminalWriterBase
    {
        private readonly ITerminalWriter _writer;

        public TrimAnsiTerminalWriter(ITerminalWriter writer)
        {
            _writer = writer;
        }

        public override void Write(AnsiString.Chunk str)
        {
            str = new AnsiString.Chunk(str.Buffer, null, null);
            _writer.Write(str);
        }
    }
}