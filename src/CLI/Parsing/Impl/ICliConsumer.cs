namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal interface ICliConsumer
    {
        void CheckConfiguration();
        void Consume(RawCommandLine raw);
        void BuildUsage(IUsageBuilder builder);
    }
}
