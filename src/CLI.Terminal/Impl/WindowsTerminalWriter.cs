using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalWriter : TerminalWriterBase
    {
        private readonly IntPtr _hConsole;
        private readonly object _consoleOutputLock;

        public WindowsTerminalWriter(IntPtr hConsole, object consoleOutputLock)
        {
            _hConsole = hConsole;
            _consoleOutputLock = consoleOutputLock;
        }

        public override void Write(AnsiString.Chunk str)
        {
            if (str.Length == 0)
            {
                return;
            }

            DoWrite(str);
        }

        private unsafe void DoWrite(AnsiString.Chunk str)
        {
            var fg = str.ForegroundColor ?? Terminal.DefaultForegroundColor;
            var bg = str.BackgroundColor ?? Terminal.DefaultBackgroundColor;
            var attrs = WindowsTerminalImplementation.GetCharAttributes(fg, bg);
            
            lock (_consoleOutputLock)
            {
                GetConsoleScreenBufferInfo(out var bufferInfo);

                try
                {
                    if (attrs != bufferInfo.wAttributes)
                    {
                        SetConsoleTextAttribute(attrs);
                    }

                    var buffer = stackalloc char[str.Length];
                    for (var i = 0; i < str.Length; i++)
                    {
                        buffer[i] = str[i];
                    }

                    var written = 0;
                    WriteConsole(buffer, str.Length, &written, null);
                }
                finally
                {
                    if (attrs != bufferInfo.wAttributes)
                    {
                        SetConsoleTextAttribute(bufferInfo.wAttributes);
                    }
                }
            }
        }

        #region Win32 wrappers

        private void GetConsoleScreenBufferInfo(out Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo)
        {
            var result = Win32.GetConsoleScreenBufferInfo(_hConsole, out bufferInfo);
            if (!result)
            {
                Trace.WriteLine(
                    string.Format(
                        "GetConsoleScreenBufferInfo(h: 0x{0:X08}) -> 0x{1:X08} {2}",
                        _hConsole.ToInt32(),
                        Marshal.GetLastWin32Error(),
                        new Win32Exception(Marshal.GetLastWin32Error()).Message
                    )
                );
                throw new Win32Exception();
            }
        }

        private void SetConsoleTextAttribute(short wAttributes)
        {
            if (!Win32.SetConsoleTextAttribute(_hConsole, wAttributes))
            {
                Trace.WriteLine(
                    string.Format(
                        "SetConsoleTextAttribute(0x{0:X08}, 0x{1:X04}) -> 0x{2:X08} {3}",
                        _hConsole.ToInt32(),
                        wAttributes,
                        Marshal.GetLastWin32Error(),
                        new Win32Exception(Marshal.GetLastWin32Error()).Message
                    )
                );
                throw new Win32Exception();
            }
        }

        private unsafe void WriteConsole(
            void* lpBuffer,
            int nNumberOfCharsToWrite,
            int* lpNumberOfCharsWritten,
            void* lpReserved
        )
        {
            if (!Win32.WriteConsole(_hConsole, lpBuffer, nNumberOfCharsToWrite, lpNumberOfCharsWritten, lpReserved))
            {
                Trace.WriteLine(
                    string.Format(
                        "WriteConsole(0x{0:X08}, ...) -> 0x{1:X08} {2}",
                        _hConsole.ToInt32(),
                        Marshal.GetLastWin32Error(),
                        new Win32Exception(Marshal.GetLastWin32Error()).Message
                    )
                );
                throw new Win32Exception();
            }
        }

        #endregion
    }
}