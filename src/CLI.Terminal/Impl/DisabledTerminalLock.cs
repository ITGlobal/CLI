namespace ITGlobal.CommandLine.Impl
{
    internal sealed class DisabledTerminalLock : ITerminalLock
    {
        private readonly ITerminal _terminal;

        public DisabledTerminalLock(ITerminal terminal)
        {
            _terminal = terminal;
        }

        public ITerminalOutput Stdout => _terminal.Stdout;
        public ITerminalOutput Stderr => _terminal.Stderr;

        public void Dispose() { }
    }
}