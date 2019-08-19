using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalImplementation : ITerminalImplementation
    {
        private readonly IntPtr _hStdErr;
        private readonly IntPtr _hStdOut;
        private readonly IntPtr _hConsoleBuffer;

        private readonly TextWriter _originalStdErr;
        private readonly TextWriter _originalStdOut;

        public WindowsTerminalImplementation()
        {
            _hStdErr = Win32.GetStdHandle(Win32.STD_ERROR_HANDLE);
            if (_hStdErr == Win32.INVALID_HANDLE_VALUE)
            {
                Trace.WriteLine(
                    string.Format(
                        "GetStdHandle({0}) -> {1}, 0x{2:X08}",
                        Win32.STD_ERROR_HANDLE,
                        _hStdErr.ToInt32(),
                        Marshal.GetLastWin32Error()
                    )
                );

                throw new Win32Exception();
            }

            var _hStdOut = Win32.GetStdHandle(Win32.STD_OUTPUT_HANDLE);
            if (_hStdErr == Win32.INVALID_HANDLE_VALUE)
            {
                Trace.WriteLine(
                    string.Format(
                        "GetStdHandle({0}) -> {1}, 0x{2:X08}",
                        Win32.STD_OUTPUT_HANDLE,
                        _hStdErr.ToInt32(),
                        Marshal.GetLastWin32Error()
                    )
                );

                throw new Win32Exception();
            }

            _hConsoleBuffer = Win32.CreateFile(
                lpFileName: "CONOUT$",
                dwDesiredAccess: Win32.FileAccess.GenericRead|Win32.FileAccess.GenericWrite,
                dwShareMode: Win32.FileShare.Write,
                lpSecurityAttributes: IntPtr.Zero,
                dwCreationDisposition: Win32.CreationDisposition.OpenAlways,
                dwFlagsAndAttributes: 0,
                hTemplateFile: IntPtr.Zero
            );
            if (_hConsoleBuffer == Win32.INVALID_HANDLE_VALUE)
            {
                Trace.WriteLine(
                    string.Format(
                        "CreateFile(\"{0}\", ...) -> {1}, 0x{2:X08}",
                        "CONOUT$",
                        _hConsoleBuffer.ToInt32(),
                        Marshal.GetLastWin32Error()
                    )
                );

                throw new Win32Exception();
            }

            var stderr = new WindowsTerminalWriter(_hStdErr, _hConsoleBuffer);
            var stdout = new WindowsTerminalWriter(_hStdOut, _hConsoleBuffer);

            _originalStdErr = Console.Error;
            _originalStdOut = Console.Out;

            Console.SetError(new AnsiTextWriter(Console.Error));
            Console.SetOut(new AnsiTextWriter(Console.Out));

            Stderr = stderr;
            Stdout = stdout;
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
                    Trace.WriteLine(
                        string.Format(
                            "GetConsoleScreenBufferInfo(0x{0:X08}) -> 0x{1:X08}",
                            _hStdErr.ToInt32(),
                            Marshal.GetLastWin32Error()
                        )
                    );

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
                Trace.WriteLine(
                    string.Format(
                        "GetConsoleScreenBufferInfo(0x{0:X08}) -> 0x{1:X08}",
                        _hStdErr.ToInt32(),
                        Marshal.GetLastWin32Error()
                    )
                );

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
                Trace.WriteLine(
                    string.Format(
                        "FillConsoleOutputAttribute(0x{0:X08}, {1}, {2}, {{ X: {3}, Y: {4} }}) -> 0x{5:X08}",
                        _hStdErr.ToInt32(),
                        0,
                        (uint)width,
                        coord.X,
                        coord.Y,
                        Marshal.GetLastWin32Error()
                    )
                );

                throw new Win32Exception();
            }

            if (!Win32.FillConsoleOutputCharacter(_hStdErr, ' ', (uint)width, coord, out _))
            {
                Trace.WriteLine(
                    string.Format(
                        "FillConsoleOutputCharacter(0x{0:X08}, \"{1}\", {2}, {{ X: {3}, Y: {4} }}) -> 0x{5:X08}",
                        _hStdErr.ToInt32(),
                        ' ',
                        (uint)width,
                        coord.X,
                        coord.Y,
                        Marshal.GetLastWin32Error()
                    )
                );
                throw new Win32Exception();
            }

            if (!Win32.SetConsoleCursorPosition(_hStdErr, coord))
            {
                Trace.WriteLine(
                    string.Format(
                        "SetConsoleCursorPosition(0x{0:X08}, {{ X: {1}, Y: {2} }}) -> 0x{3:X08}",
                        _hStdErr.ToInt32(),
                        coord.X,
                        coord.Y,
                        Marshal.GetLastWin32Error()
                    )
                );

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

        public void Dispose()
        {
            Console.SetError(_originalStdErr);
            Console.SetOut(_originalStdOut);

            Win32.CloseHandle(_hConsoleBuffer);
            Win32.CloseHandle(_hStdOut);
            Win32.CloseHandle(_hStdErr);
        }
    }
}