namespace ITGlobal.CommandLine.Parsing
{
    public interface IHelpUsage
    {
        bool SupportsHelp { get; }
        string ExecutableName { get; }
        string HelpCommand { get; }
    }
}