using ITGlobal.CommandLine.Parsing.Help;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal interface ICliParserInternal
    {
        string ExecutableName { get; }
        string Logo { get; }
        string HelpText { get; }
        CliParserFlags Flags { get; }
        IHelpPrinter HelpPrinter { get; }
    }
}