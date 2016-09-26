using System;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    public class CommandLineValidationException : CommandLineException
    {
        public CommandLineValidationException(string[] errors)
        {
            ValidationErrors = errors;
        }

        public CommandLineValidationException(string[] errors, Exception inner) 
            : base(GetMessage(errors), inner)
        {
            ValidationErrors = errors;
        }

        public string[] ValidationErrors { get; }

        private static string GetMessage(string[] errors) => string.Join("\n", errors);
    }
}