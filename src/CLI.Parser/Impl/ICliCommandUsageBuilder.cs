namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal interface ICliCommandUsageBuilder : IUsageBuilder
    {
        CliCommandUsageBuilder AddCommand(string[] names, string helpText, bool isHidden, int displayOrder);
    }
}