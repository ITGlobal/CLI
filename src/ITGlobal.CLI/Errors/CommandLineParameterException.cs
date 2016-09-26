using System;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    public class CommandLineParameterException : CommandLineException
    {
        public CommandLineParameterException()
        {
        }

        public CommandLineParameterException(string message) 
            : base(message)
        {
        }

        public CommandLineParameterException(string message, Exception inner) 
            : base(message, inner)
        {
        }
    }
}