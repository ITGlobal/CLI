using System;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     An exception for command-line application errors.
    ///     <see cref="TerminalErrorHandler"/> handles this exception automatically.
    /// </summary>
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