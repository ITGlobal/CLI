namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal interface IHelpUsage
    {
        bool SupportsHelp { get; }
        string ExecutableName { get; }
        string HelpCommand { get; }
    }
}