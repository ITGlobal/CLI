using System.Collections.Generic;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class DefaultCliParserResultFactory : ICliParserResultFactory
    {
        public ICliParserResult ValidationErrors(ICliParser parser, IList<string> errors, IHelpUsage helpUsage)
        {
            return new InvalidCliParserResult(errors, helpUsage);
        }

        public ICliParserResult UnknownOptions(ICliParser parser, IList<string> unknownOptions, IHelpUsage helpUsage)
        {
            return new UnknownOptionsCliParserResult(unknownOptions, helpUsage);
        }

        public ICliParserResult UnknownArguments(ICliParser parser, IList<string> unknownArguments, IHelpUsage helpUsage)
        {
            return new UnknownArgumentsCliParserResult(unknownArguments, helpUsage);
        }

        public ICliParserResult UnknownCommand(ICliParser parser, string command, string[] commandNameCandidates, IHelpUsage helpUsage)
        {
            return new UnknownCommandCliParserResult(command, commandNameCandidates, helpUsage);
        }
    }
}