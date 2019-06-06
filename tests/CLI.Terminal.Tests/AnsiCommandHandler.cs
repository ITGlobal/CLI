using System;
using System.Collections.Generic;
using ITGlobal.CommandLine.Impl;
using Xunit;
using Xunit.Abstractions;

namespace ITGlobal.CommandLine
{
    public sealed class AnsiCommandHandler : IAnsiCommandHandler
    {
        private readonly ITestOutputHelper _output;
        private readonly List<AnsiCommand> _commands = new List<AnsiCommand>();

        public AnsiCommandHandler(ITestOutputHelper output)
        {
            _output = output;
        }

        public void Verify(AnsiCommand[] commands)
        {
            var matches = commands.Length == _commands.Count;
            for (var i = 0; i < Math.Min(commands.Length, _commands.Count); i++)
            {
                matches &= commands[i].Equals(_commands[i]);
            }

            if (!matches)
            {
                _output.WriteLine($"EXPECTED: {string.Join<AnsiCommand>("; ", commands)}");
                _output.WriteLine($"ACTUAL:   {string.Join<AnsiCommand>("; ", _commands)}");
                Assert.True(false);
            }
        }

        void IAnsiCommandHandler.SetForegroundColor(ConsoleColor color)
        {
            _commands.Add(AnsiCommand.SetForegroundColor(color));
        }

        void IAnsiCommandHandler.SetBackgroundColor(ConsoleColor color)
        {
            _commands.Add(AnsiCommand.SetBackgroundColor(color));
        }

        void IAnsiCommandHandler.ResetColors()
        {
            _commands.Add(AnsiCommand.ResetColors());
        }

        void IAnsiCommandHandler.Write(char c)
        {
            _commands.Add(AnsiCommand.Write(c));
        }
    }
}