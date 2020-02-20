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
            for (var index = str.Offset; index < str.Length; index++)
            {
                var c = str.Buffer[index];
                _output.Write(_stream, c, str.ForegroundColor, str.BackgroundColor);
            }
        }
    }
}