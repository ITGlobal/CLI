namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal interface IUsageBuilder
    {
        string[] GetOptionNames(char? shortName, string longName);

        void AddSwitch(CliSwitchUsage usage);

        void AddOption(CliOptionUsage usage);

        void AddArgument(CliArgumentUsage usage);
    }
}