using System;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class UnknownCommandException : Exception
    {
        public UnknownCommandException(string commandName, IHelpUsage usage)
        {
            CommandName = commandName;
            Usage = usage;
        }

        public string CommandName { get; }
        public IHelpUsage Usage { get; }
    }
}