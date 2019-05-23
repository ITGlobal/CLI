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

        public void MoveToLine(int offset)
        {
            var cursorTop = Console.CursorTop;
            cursorTop -= offset;
            Console.CursorTop = cursorTop > 0 ? cursorTop : 0;
        }

        public void ClearLine()
        {
            int width;
            if (Console.CursorLeft > 0)
            {
                width = Console.CursorLeft;
            }
            else
            {
                width = Console.WindowWidth - 1;
            }

            Console.ResetColor();

            _stderr.Write('\r');
            for (var i = 0; i < width; i++)
            {
                _stderr.Write(' ');
            }

            _stderr.Write('\r');
            _stderr.Flush();
        }
    }
}
