// ReSharper disable once CheckNamespace
using System;

namespace ITGlobal.CommandLine
{

    internal sealed class CommandParserHookResult : ICliParserResult
    {
        private readonly int _exitCode;

        public CommandParserHookResult(int exitCode)
        {
            _exitCode = exitCode;
        }

        public int Run() => _exitCode;
    }
}