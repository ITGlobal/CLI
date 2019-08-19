using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class SystemTerminalImplementation : ITerminalImplementation
    {
        private readonly TextWriter _stderr;

        public SystemTerminalImplementation()
        {
            Console.SetError(new AnsiTextWriter(Console.Error));
            Console.SetOut(new AnsiTextWriter(Console.Out));

            _stderr = Console.Error;

            Stdout = new SystemTerminalWriter(Console.Out);
            Stderr = new SystemTerminalWriter(Console.Error);
        }

        public ITerminalWriter Stdout { get; }

        public ITerminalWriter Stderr { get; }
        public string DriverName => "SystemConsole";

        public int WindowWidth
        {
            get
            {
                var width = Console.WindowWidth;
                if (width <= 0)
                {
                    width = Terminal.DefaultWindowWidth;
                }
                return width;
            }
        }

        public void MoveToLine(int offset)
        {
            var cursorTop = Console.CursorTop;
            cursorTop += offset;
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
                width = Terminal.WindowWidth - 1;
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
