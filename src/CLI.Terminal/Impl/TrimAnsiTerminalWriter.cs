namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TrimAnsiTerminalWriter : TerminalWriterBase
    {
        private readonly ITerminalWriter _writer;

        public TrimAnsiTerminalWriter(ITerminalWriter writer)
        {
            _writer = writer;
        }

        protected override void WriteImpl(ColoredString str)
        {
            _writer.Write(str.Text.Colored());
        }
    }
}