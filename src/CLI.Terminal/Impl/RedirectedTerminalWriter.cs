namespace ITGlobal.CommandLine.Impl
{
    internal sealed class RedirectedTerminalWriter : TerminalWriterBase
    {
        private readonly LockedTerminalImplementation _output;
        private readonly StreamType _stream;

        public RedirectedTerminalWriter(LockedTerminalImplementation output, StreamType stream)
        {
            _output = output;
            _stream = stream;
        }

        public override void Write(AnsiString.Chunk str)
        {
            foreach (var c in str.Buffer)
            {
                _output.Write(_stream, c, str.ForegroundColor, str.BackgroundColor);
            }
        }
    }
}