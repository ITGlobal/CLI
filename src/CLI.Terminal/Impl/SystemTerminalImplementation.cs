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
            Stdout = new SystemTerminalWriter(Console.Out);
            Stderr = new SystemTerminalWriter(Console.Error);
            
            _stderr = Console.Error;
            _stdout = Console.Out;
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

        public ITerminalImplementation Clone()
        {
            return new SystemTerminalImplementation();
        }

        public void Initialize()
        {
            Console.SetOut(new AnsiTextWriter(Stdout, Console.Out.Encoding));
            Console.SetError(new AnsiTextWriter(Stderr, Console.Error.Encoding));
        }

        public void MoveToLine(int offset)
        {
            try
            {
                var cursorTop = Console.CursorTop;
                cursorTop += offset;
                Console.CursorTop = cursorTop > 0 ? cursorTop : 0;
                Console.CursorLeft = 0;
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
