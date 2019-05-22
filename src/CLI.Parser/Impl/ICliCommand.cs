using System.Collections.Generic;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal interface ICliCommand
    {
        string GetFullCommandName();
        IEnumerable<string> GetCommandName();
        void Consume(RawCommandLine raw);
        IHelpUsage GetUsage();

        IEnumerable<CliAsyncHandler> EnumerateHooks();
        IEnumerable<CliAsyncHandler> EnumerateHandlers();
    }
}