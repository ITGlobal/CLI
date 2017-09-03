// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class CommandParserResult : ICommandParserResult
    {
        private readonly CommandParser _parser;
        private readonly CommandHandler _handler;
        private readonly CommandHook _hook;
        private readonly CommandLineInfo _commandLine;

        public CommandParserResult(
            CommandParser parser,
            CommandHandler handler,
            CommandHook hook,
            CommandLineInfo commandLine)
        {
            _parser = parser;
            _handler = handler;
            _hook = hook;
            _commandLine = commandLine;
        }

        public int Run()
        {
            _parser.PrintLogo();

            if (_hook != null)
            {
                var result = _hook();
                if (result != null)
                {
                    return result.Value;
                }
            }

            var exitCode = _handler(_commandLine.UnconsumedArgs.ToArray());
            return exitCode;
        }
    }
}