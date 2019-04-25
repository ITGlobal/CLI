using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class SystemTerminalImplementation : ITerminalImplementation
    {
        private readonly TextWriter _stderr;

        public SystemTerminalImplementation()
        {
            _stderr = Console.Error;


            Stdout = new SystemTerminalWriter(Console.Out);
            Stderr = new SystemTerminalWriter(Console.Error);

        }

        public ITerminalWriter Stdout { get; }

        public ITerminalWriter Stderr { get; }

        public void ClearLine()
        {
            if (Console.CursorLeft > 0)
            {
                var left = Console.CursorLeft;

                Console.ResetColor();

                _stderr.Write('\r');
                for (var i = 0; i < left; i++)
                {
                    _stderr.Write(' ');
                }

                _stderr.Write('\r');
                _stderr.Flush();
            }
        }
    }
}
