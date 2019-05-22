using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownCommandException : Exception
    {
        public UnknownCommandException(string commandName, string[] commandNameCandidates, IHelpUsage usage)
        {
            CommandName = commandName;
            CommandNameCandidates = commandNameCandidates;
            Usage = usage;
        }

        public string CommandName { get; }
        public string[] CommandNameCandidates { get; }
        public IHelpUsage Usage { get; }
    }
}