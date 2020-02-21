using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class WindowsTerminalWriter : TerminalWriterBase
    {
        private readonly WindowsTerminalImplementation _impl;
        private readonly IntPtr _hConsole;
        private readonly IntPtr _hConsoleBuffer;

        public WindowsTerminalWriter(WindowsTerminalImplementation impl, IntPtr hConsole, IntPtr hConsoleBuffer)
        {
            _impl = impl;
            _hConsole = hConsole;
            _hConsoleBuffer = hConsoleBuffer;
        }

        public override void Write(AnsiString.Chunk str)
        {
            if (str.Length == 0)
            {
                return;
            }

            GetConsoleScreenBufferInfo(out var bufferInfo);

            if (TryWriteSpecialString(in str, ref bufferInfo))
            {
                return;
            }

            var fg = str.ForegroundColor ?? Terminal.DefaultForegroundColor;
            var bg = str.BackgroundColor ?? Terminal.DefaultBackgroundColor;
            var attrs = WindowsTerminalImplementation.GetCharAttributes(fg, bg);

            using var _ = _impl.DisableWrapAtEolOutput();
            while (true)
            {
                var windowWidth = _impl.WindowWidth;
                if (!_impl.IsWrapAtEolOutputEnabled)
                {
                    windowWidth++;
                }

                var remainingWidth = windowWidth - bufferInfo.dwCursorPosition.X;

                if (remainingWidth <= 0)
                {
                    WriteSpecialString(ref bufferInfo);
                    continue;
                }

                if (str.Length > remainingWidth)
                {
                    // Chunk is too long, will split it into two parts:
                    // - left part has exactly NWidth characters so it'll fit into terminal
                    // - right part is whatever remains to be written

                    var left = str.Slice(0, remainingWidth);
                    var right = str.Slice(remainingWidth);
                    WriteImpl(left, ref bufferInfo, attrs, windowWidth);

                    str = right;
                }
                else
                {
                    // Chunk fits into terminal as is
                    WriteImpl(str, ref bufferInfo, attrs, windowWidth);
                    break;
                }
            }
        }

        private unsafe void WriteImpl(AnsiString.Chunk str, ref Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo, short attrs, int width)
        {
            if (str.Length == 0)
            {
                return;
            }

            if (TryWriteSpecialString(in str, ref bufferInfo))
            {
                return;
            }

            Win32.CHAR_INFO* chars = stackalloc Win32.CHAR_INFO[str.Length];

            for (var i = 0; i < str.Length; i++)
            {
                chars[i].UnicodeChar = str[i];
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
            WriteConsoleOutput(chars, str.Length, in dwBufferSize, in dwBufferCoord, ref lpWriteRegion);

            var dwCoord = new Win32.COORD
            {
                X = (short)(bufferInfo.dwCursorPosition.X + str.Length),
                Y = bufferInfo.dwCursorPosition.Y,
            };

            if (dwCoord.X >= width && _impl.IsWrapAtEolOutputEnabled)
            {
                // Advance to a new line
                dwCoord.Y++;
                dwCoord.X = 0;
            }

            SetConsoleCursorPosition(in dwCoord);
            GetConsoleScreenBufferInfo(out bufferInfo);
        }

        private bool TryWriteSpecialString(in AnsiString.Chunk str, ref Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo)
        {
            if (str.Length != 1)
            {
                return false;
            }

            var lf = false;
            var cr = false;

            if (str[0] == '\n')
            {
                lf = true;
            }
            else if (str[0] == '\r')
            {
                cr = true;
            }

            if (!cr! && !lf)
            {
                return false;
            }

            WriteSpecialString(ref bufferInfo, true, lf);
            return true;

        }

        private void WriteSpecialString(ref Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo, bool cr = true, bool lf = true)
        {
            var cursor = new Win32.COORD
            {
                X = bufferInfo.dwCursorPosition.X,
                Y = bufferInfo.dwCursorPosition.Y,
            };
            if (cr)
            {
                cursor.X = 0;
            }
            if (lf)
            {
                cursor.Y++;
            }

            SetConsoleCursorPosition(in cursor);
            GetConsoleScreenBufferInfo(out bufferInfo);
        }

        #region Win32 wrappers

        private void GetConsoleScreenBufferInfo(out Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo)
        {
            if (!Win32.GetConsoleScreenBufferInfo(_hConsole, out bufferInfo))
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

        private void SetConsoleCursorPosition(in Win32.COORD cursor)
        {
            if (!Win32.SetConsoleCursorPosition(_hConsole, cursor))
            {
                Trace.WriteLine(
                    string.Format(
                        "SetConsoleCursorPosition(h: 0x{0:X08}, {{ X: {1}, Y: {2} }}) -> 0x{3:X08} {4}",
                        _hConsole.ToInt32(),
                        cursor.X,
                        cursor.Y,
                        Marshal.GetLastWin32Error(),
                        new Win32Exception(Marshal.GetLastWin32Error()).Message
                    )
                );
                //throw new Win32Exception();
            }
        }

        private unsafe void WriteConsoleOutput(
            Win32.CHAR_INFO* chars,
            int length,
            in Win32.COORD dwBufferSize,
            in Win32.COORD dwBufferCoord,
            ref Win32.SMALL_RECT lpWriteRegion)
        {
            if (!Win32.WriteConsoleOutputW(_hConsoleBuffer, chars, dwBufferSize, dwBufferCoord, ref lpWriteRegion))
            {
                Trace.WriteLine(
                    string.Format(
                        "WriteConsoleOutput(h: 0x{0:X08}, [{1}], {{ X: {2}, Y: {3} }}, ...) -> 0x{4:X08} {5}",
                        _hConsoleBuffer.ToInt32(),
                        length,
                        dwBufferSize.X,
                        dwBufferSize.Y,
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