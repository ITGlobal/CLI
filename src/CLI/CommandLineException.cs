using System;

namespace ITGlobal.CommandLine
{
    public class CommandLineException : Exception
    {
        public CommandLineException()
        {
        }

        public CommandLineException(string message) : base(message)
        {
        }

        public CommandLineException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}