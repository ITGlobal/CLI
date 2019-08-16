using System;
using System.ComponentModel;
using System.IO;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalImplementation : ITerminalImplementation
    {
        private readonly IntPtr _hStdErr;

        public WindowsTerminalImplementation()
        {
            _hStdErr = Win32.GetStdHandle(Win32.STD_ERROR_HANDLE);
            if (_hStdErr == Win32.INVALID_HANDLE_VALUE)
            {
                throw new Win32Exception();
            }

            var hStdOut = Win32.GetStdHandle(Win32.STD_OUTPUT_HANDLE);
            if (_hStdErr == Win32.INVALID_HANDLE_VALUE)
            {
                throw new Win32Exception();
            }

            var hConsoleBuffer = Win32.CreateFile(
                fileName: "CONOUT$",
                fileAccess: 0x40000000,
                fileShare: 2,
                securityAttributes: IntPtr.Zero,
                creationDisposition: FileMode.Open,
                flags: 0,
                template: IntPtr.Zero
            );
            if (hConsoleBuffer.IsInvalid)
            {
                throw new Win32Exception();
            }


            Console.SetError(new AnsiTextWriter(Console.Error));
            Console.SetOut(new AnsiTextWriter(Console.Out));

            Stderr = new WindowsTerminalWriter(_hStdErr, hConsoleBuffer.DangerousGetHandle());
            Stdout = new WindowsTerminalWriter(hStdOut, hConsoleBuffer.DangerousGetHandle());
        }

        public ITerminalWriter Stdout { get; }

        public ITerminalWriter Stderr { get; }

        public string DriverName => "Win32";

        public int WindowWidth
        {
            get
            {
                if (!Win32.GetConsoleScreenBufferInfo(_hStdErr, out var bufferInfo))
                {
                    throw new Win32Exception();
                }

                return bufferInfo.dwSize.X;
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
            if (!Win32.GetConsoleScreenBufferInfo(_hStdErr, out var bufferInfo))
            {
                throw new Win32Exception();
            }

            var width = bufferInfo.dwSize.X;

            var coord = new Win32.COORD
            {
                X = 0,
                Y = bufferInfo.dwCursorPosition.Y
            };

            if (!Win32.FillConsoleOutputAttribute(_hStdErr, 0, (uint)width, coord, out _))
            {
                throw new Win32Exception();
            }

            if (!Win32.FillConsoleOutputCharacter(_hStdErr, ' ', (uint)width, coord, out _))
            {
                throw new Win32Exception();
            }

            if (!Win32.SetConsoleCursorPosition(_hStdErr, coord))
            {
                throw new Win32Exception();
            }

            Console.ResetColor();
        }

        public static short GetCharAttributes(ConsoleColor fg, ConsoleColor bg)
        {
            var fgAttr = (Win32.Color)(int)fg;
            var bgAttr = (Win32.Color)((int)bg << 4);

            return (short)(fgAttr | bgAttr);
        }
    }
}