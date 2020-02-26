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

            var wrapAtEolOutput = _impl.IsWrapAtEolOutputEnabled;
            using var _ = _impl.DisableWrapAtEolOutput();
            WriteLoop(str, ref bufferInfo, attrs, wrapAtEolOutput);
        }

        private void WriteLoop(
            AnsiString.Chunk str,
            ref Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo,
            short attrs,
            bool wrapAtEolOutput)
        {
            while (true)
            {
                var windowWidth = _impl.WindowWidth;

                var remainingWidth = windowWidth - bufferInfo.dwCursorPosition.X;
                
                // Special handling for CR/LF (short strings)
                if (TryWriteSpecialString(in str, ref bufferInfo))
                {
                    return;
                }

                if (wrapAtEolOutput && remainingWidth <= 0 || remainingWidth < 0)
                {
                    WriteSpecialString(ref bufferInfo);
                    continue;
                }

                // Special handling for TAB/CR/LF
                if (TryWriteSpecialString(str, ref bufferInfo, attrs, wrapAtEolOutput))
                {
                    return;
                }

                if (str.Length > remainingWidth)
                {
                    // Chunk is too long, will split it into two parts:
                    // - left part has exactly NWidth characters so it'll fit into terminal
                    // - right part is whatever remains to be written

                    var left  = str.Slice(0, remainingWidth);
                    var middle = AnsiString.Chunk.CRLF.WithColors(str.ForegroundColor, str.BackgroundColor);
                    var right = str.Slice(remainingWidth);
                    WriteLoop(left, ref bufferInfo, attrs, wrapAtEolOutput);
                    WriteLoop(middle, ref bufferInfo, attrs, wrapAtEolOutput);

                    str = right;
                }
                else
                {
                    // Chunk fits into terminal as is
                    WriteImpl(str, ref bufferInfo, attrs);
                    return;
                }
            }
        }

        private bool TryWriteSpecialString(AnsiString.Chunk str, ref Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo, short attrs, bool wrapAtEolOutput)
        {
            var i = str.IndexOfAny('\t', '\r', '\n');
            if (i >= 0)
            {
                // Special handling for TAB/CR/LF
                AnsiString.Chunk middle;
                switch (str[i])
                {
                    case '\t':
                        middle = AnsiString.Chunk.TAB;
                        break;
                    case '\r':
                        middle = AnsiString.Chunk.CR;
                        break;
                    case '\n':
                        middle = AnsiString.Chunk.LF;
                        break;
                    default:
                        middle = AnsiString.Chunk.TAB;
                        break;
                }

                var left = str.Slice(0, i);
                middle = middle.WithColors(str.ForegroundColor, str.BackgroundColor);
                var right = str.Slice(i + 1);

                WriteLoop(left, ref bufferInfo, attrs, wrapAtEolOutput);
                WriteLoop(middle, ref bufferInfo, attrs, wrapAtEolOutput);
                WriteLoop(right, ref bufferInfo, attrs, wrapAtEolOutput);

                return true;
            }

            return false;
        }

        private unsafe void WriteImpl(
            AnsiString.Chunk str,
            ref Win32.CONSOLE_SCREEN_BUFFER_INFO bufferInfo,
            short attrs,
            bool forceNewLine = false)
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

            if (forceNewLine)
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
            switch (str.Length)
            {
                case 1:
                    {
                        if (str[0] == '\n')
                        {
                            WriteSpecialString(ref bufferInfo, cr: true, lf: true);
                            return true;
                        }

                        if (str[0] == '\r')
                        {
                            WriteSpecialString(ref bufferInfo, cr: true, lf: false);
                            return true;
                        }

                        return false;
                    }

                case 2:
                    if (str[0] == '\r' && str[1] == '\n')
                    {
                        WriteSpecialString(ref bufferInfo, cr: true, lf: true);
                        return true;
                    }

                    return false;

                default:
                    return false;
            }
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