using System;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    public class CommandNotFoundException : CommandLineException
    {
        public CommandNotFoundException(string commandName) 
            : base(GetMessage(commandName) )
        {
            CommandName = commandName;
        }

        public CommandNotFoundException(string commandName, Exception inner)
            : base(GetMessage(commandName) , inner)
        {
            CommandName = commandName;
        }

        public string CommandName { get; }

        private static string GetMessage(string commandName) => string.Format(CLI.Text.UnknownCommand, commandName);
    }
}