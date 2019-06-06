namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal interface ICliConsumer
    {
        int Priority { get; }
        void CheckConfiguration();
        void Consume(RawCommandLine raw);
        void BuildUsage(IUsageBuilder builder);
    }
}
