using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalImplementation : ITerminalImplementation
    {
        public readonly struct ChangeConsoleModeToken : IDisposable
        {
            private readonly WindowsTerminalImplementation _impl;
            private readonly uint _lpMode;

            public ChangeConsoleModeToken(WindowsTerminalImplementation impl, uint lpMode)
            {
                _impl = impl;
                _lpMode = lpMode;
            }

            public void Dispose() => _impl.SetConsoleMode(_lpMode);
        }

        private IntPtr _hStdErr;
        private IntPtr _hStdOut;
        private IntPtr _hConsoleBuffer;

        private readonly TextWriter _originalStdErr;
        private readonly TextWriter _originalStdOut;

        private readonly WindowsTerminalWriteQueue _writeQueue = new WindowsTerminalWriteQueue();

        public WindowsTerminalImplementation()
        {
            _originalStdErr = Console.Error;
            _originalStdOut = Console.Out;
        }

        public ITerminalWriter Stdout { get; private set; }

        public ITerminalWriter Stderr { get; private set; }

        public string DriverName => "Win32";

        public int WindowWidth
        {
            get
            {
                if (!Win32.GetConsoleScreenBufferInfo(_hStdErr, out var bufferInfo))
                {
                    Trace.WriteLine(
                        $"GetConsoleScreenBufferInfo(0x{_hStdErr.ToInt32():X08}) -> 0x{Marshal.GetLastWin32Error():X08}"
                    );

                    throw new Win32Exception();
                }

                var width = bufferInfo.srWindow.Right - bufferInfo.srWindow.Left;
                return width;
            }
        }

        public ITerminalImplementation Clone()
        {
            return new WindowsTerminalImplementation();
        }

        public void Initialize()
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

            _hStdOut = Win32.GetStdHandle(Win32.STD_OUTPUT_HANDLE);
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
                dwDesiredAccess: Win32.FileAccess.GenericRead | Win32.FileAccess.GenericWrite,
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

            if (TryGetConsoleMode(_hConsoleBuffer, out var mode))
            {
                IsWrapAtEolOutputEnabled = (mode & (uint)Win32.ConsoleOutputModes.ENABLE_WRAP_AT_EOL_OUTPUT) != 0;
            }

            var consoleOutputLock = new object();

            var isStdErrRedirected = IsRedirected(_hStdErr);
            if (!isStdErrRedirected)
            {
                var stderr = new WindowsTerminalWriter(_hStdErr, consoleOutputLock);
                Console.SetError(new WindowsTerminalAnsiTextWriter(Console.Error.Encoding, _writeQueue, ConsoleStream.StdErr));
                Stderr = stderr;
                _writeQueue.StdErrWriter = stderr;
            }
            else
            {
                // StdErr is redirected, won't use WindowsTerminalWriter
                Stderr = new SystemTerminalWriter(Console.Error);
                Console.SetError(new TrimAnsiTextWriter(Console.Error));
                Trace.WriteLine("StdErr is redirected");
            }

            var isStdOutRedirected = IsRedirected(_hStdOut);
            if (!isStdOutRedirected)
            {
                var stdout = new WindowsTerminalWriter(_hStdOut, consoleOutputLock);
                Console.SetOut(new WindowsTerminalAnsiTextWriter(Console.Error.Encoding, _writeQueue, ConsoleStream.StdOut));
                Stdout = stdout;
                _writeQueue.StdOutWriter = stdout;
            }
            else
            {
                // StdOut is redirected, won't use WindowsTerminalWriter
                Stderr = new SystemTerminalWriter(Console.Out);
                Console.SetOut(new TrimAnsiTextWriter(Console.Out));
                Trace.WriteLine("StdOut is redirected");
            }
        }

        public void MoveToLine(int offset)
        {
            var cursorTop = Console.CursorTop;
            cursorTop += offset;
            Console.CursorTop = cursorTop > 0 ? cursorTop : 0;
            Console.CursorLeft = 0;
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

            _writeQueue.Dispose();
        }

        public bool IsWrapAtEolOutputEnabled { get; private set; }

        public ChangeConsoleModeToken? DisableWrapAtEolOutput()
        {
            if (!TryGetConsoleMode(_hConsoleBuffer, out var originalMode))
            {
                return null;
            }

            // Disable auto line wraps. Tables won't be able to print properly otherwise.
            var newMode = originalMode & ~(uint)Win32.ConsoleOutputModes.ENABLE_WRAP_AT_EOL_OUTPUT;
            if (newMode == originalMode)
            {
                return null;
            }

            SetConsoleMode(newMode);
            return new ChangeConsoleModeToken(this, originalMode);
        }

        private static bool TryGetConsoleMode(IntPtr hConsole, out uint lpMode)
        {
            if (!Win32.GetConsoleMode(hConsole, out lpMode))
            {
                Trace.WriteLine(
                    $"GetConsoleMode(0x{hConsole.ToInt32():X08}) -> ERROR 0x{Marshal.GetLastWin32Error():X08}"
                );
                return false;
            }

            return true;
        }

        private void SetConsoleMode(uint mode)
        {
            IsWrapAtEolOutputEnabled = (mode & (uint)Win32.ConsoleOutputModes.ENABLE_WRAP_AT_EOL_OUTPUT) != 0;
            SetConsoleMode(_hConsoleBuffer, mode);
        }

        private static void SetConsoleMode(IntPtr hConsole, uint lpMode)
        {
            if (!Win32.SetConsoleMode(hConsole, lpMode))
            {
                Trace.WriteLine(
                    $"SetConsoleMode(0x{hConsole.ToInt32():X08},  0x{lpMode:X08}) -> ERROR 0x{Marshal.GetLastWin32Error():X08}"
                );
                return;
            }
        }

        private static bool IsRedirected(IntPtr hConsole)
        {
            if (!TryGetConsoleMode(hConsole, out var lpMode))
            {
                return true;
            }

            if (lpMode == 0)
            {
                return true;
            }

            return false;
        }
    }
}