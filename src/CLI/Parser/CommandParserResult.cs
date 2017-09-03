// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class CommandParserResult : ICommandParserResult
    {
        private readonly CommandParser _parser;
        private readonly CommandHandler _handler;
        private readonly CommandLineInfo _commandLine;

        public CommandParserResult(
            CommandParser parser,
            CommandHandler handler,
            CommandLineInfo commandLine)
        {
            _parser = parser;
            _handler = handler;
            _commandLine = commandLine;
        }

        public int Run()
        {
            _parser.PrintLogo();
            
            var exitCode = _handler(_commandLine.UnconsumedArgs.ToArray());
            return exitCode;
        }
    }
}