using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalWriter : TerminalWriterBase
    {
        private readonly IntPtr _hConsole;
        private readonly IntPtr _hConsoleBuffer;

        public WindowsTerminalWriter(IntPtr hConsole, IntPtr hConsoleBuffer)
        {
            _hConsole = hConsole;
            _hConsoleBuffer = hConsoleBuffer;
        }

        protected override void WriteImpl(ColoredString str)
        {
            if (str.Length == 0)
            {
                return;
            }

            if (!Win32.GetConsoleScreenBufferInfo(_hConsole, out var bufferInfo))
            {
                Trace.WriteLine(
                    string.Format(
                        "GetConsoleScreenBufferInfo(h: 0x{0:X08}) -> 0x{1:X08}",
                        _hConsole.ToInt32(),
                        Marshal.GetLastWin32Error()
                    )
                );
                throw new Win32Exception();
            }

            if (str.Text == "\n")
            {
                var cursor = new Win32.COORD
                {
                    X = 0,
                    Y = (short)(bufferInfo.dwCursorPosition.Y + 1),
                };
                if (!Win32.SetConsoleCursorPosition(_hConsole, cursor))
                {
                    Trace.WriteLine(
                        string.Format(
                            "SetConsoleCursorPosition(h: 0x{0:X08}, {{ X: {1}, Y: {2} }}) -> 0x{3:X08}",
                            _hConsole.ToInt32(),
                            cursor.X,
                            cursor.Y,
                            Marshal.GetLastWin32Error()
                        )
                    );
                    throw new Win32Exception();
                }
                return;
            }

            var fg = str.ForegroundColor ?? Console.ForegroundColor;
            var bg = str.BackgroundColor ?? Console.BackgroundColor;

            var attrs = WindowsTerminalImplementation.GetCharAttributes(fg, bg);

            var chars = new Win32.CHAR_INFO[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                chars[i].Char.UnicodeChar = str.Text[i];
                chars[i].Attributes = attrs;
            }

            var dwBufferSize = new Win32.COORD
            {
                X = (short)str.Length,
                Y = 1
            };
            var dwBufferCoord = new Win32.COORD
            {
                X = 0,
                Y = 0,
            };
            var lpWriteRegion = new Win32.SMALL_RECT
            {
                Top = bufferInfo.dwCursorPosition.Y,
                Bottom = bufferInfo.dwCursorPosition.Y,
                Left = bufferInfo.dwCursorPosition.X,
                Right = (short)(bufferInfo.dwCursorPosition.X + dwBufferSize.X),
            };
            if (!Win32.WriteConsoleOutput(_hConsoleBuffer, chars, dwBufferSize, dwBufferCoord, ref lpWriteRegion))
            {
                Trace.WriteLine(
                    string.Format(
                        "WriteConsoleOutput(h: 0x{0:X08}, [{1}], {{ X: {2}, Y: {3} }}, ...) -> 0x{4:X08}",
                        _hConsoleBuffer.ToInt32(),
                        chars.Length,
                        dwBufferSize.X,
                        dwBufferSize.Y,
                        Marshal.GetLastWin32Error()
                    )
                );
                throw new Win32Exception();
            }

            var dwCoord = new Win32.COORD
            {
                X = (short)(bufferInfo.dwCursorPosition.X + str.Length),
                Y = bufferInfo.dwCursorPosition.Y,
            };
            if (!Win32.SetConsoleCursorPosition(_hConsole, dwCoord))
            {
                Trace.WriteLine(
                    string.Format(
                        "SetConsoleCursorPosition(h: 0x{0:X08}, {{ X: {1}, Y: {2} }}) -> 0x{3:X08}",
                        _hConsole.ToInt32(),
                        dwCoord.X,
                        dwCoord.Y,
                        Marshal.GetLastWin32Error()
                    )
                );
                throw new Win32Exception();
            }
        }
    }
}