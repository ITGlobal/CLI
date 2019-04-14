namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class HookCliParserResult : ICliParserResult
    {
        private readonly int _exitCode;

        public HookCliParserResult(int exitCode)
        {
            _exitCode = exitCode;
        }

        public int Run()
        {
            return _exitCode;
        }
    }
}