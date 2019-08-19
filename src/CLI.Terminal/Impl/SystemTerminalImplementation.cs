using System;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class SystemTerminalImplementation : ITerminalImplementation
    {
        private readonly TextWriter _stderr;
        private readonly TextWriter _stdout;
        
        public SystemTerminalImplementation()
        {
            Console.SetError(new AnsiTextWriter(Console.Error));
            Console.SetOut(new AnsiTextWriter(Console.Out));

            _stderr = Console.Error;
            _stdout = Console.Out;

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
                try
                {
                    var width = Console.WindowWidth;
                    if (width <= 0)
                    {
                        width = Terminal.DefaultWindowWidth;
                    }
                    return width;
                }
                catch (IOException)
                {
                    return Terminal.DefaultWindowWidth;
                }
            }
        }

        public void MoveToLine(int offset)
        {
            try
            {
                var cursorTop = Console.CursorTop;
                cursorTop += offset;
                Console.CursorTop = cursorTop > 0 ? cursorTop : 0;
            }
            catch (IOException) { }
        }

        public void ClearLine()
        {
            try
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
            catch (IOException) { }
        }

        public void Dispose()
        {
            Console.SetError(_stderr);
            Console.SetOut(_stdout);
        }
    }
}
