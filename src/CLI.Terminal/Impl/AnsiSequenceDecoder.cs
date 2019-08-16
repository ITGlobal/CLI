using System;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class AnsiSequenceDecoder
    {
        private readonly IAnsiCommandHandler _handler;
        private readonly StringBuilder _sb = new StringBuilder();

        private bool _isEscSequence;
        private char _prevChar;

        public AnsiSequenceDecoder(IAnsiCommandHandler handler)
        {
            _handler = handler;
        }

        public void Process(char c)
        {
            if (_isEscSequence)
            {
                ProcessAnsi(c);
                return;
            }

            if (c == Ansi.ESC && _prevChar != '\\')
            {
                _isEscSequence = true;
                return;
            }

            _handler.Write(c);
            _prevChar = c;
        }

        private void ProcessAnsi(char c)
        {
            if (c == Ansi.END)
            {
                _isEscSequence = false;
                ProcessAnsiSequence();
                _sb.Clear();
                return;
            }

            _sb.Append(c);
        }

        private void ProcessAnsiSequence()
        {
            if (_sb.Length == 0)
            {
                return;
            }

            if (_sb[0] != Ansi.SGR_START)
            {
                return;
            }

            var parts = _sb.ToString(1, _sb.Length - 1).Split(Ansi.SGR_SEP);
            ConsoleColor? fg = null;
            ConsoleColor? bg = null;
            var resetColors = false;
            foreach (var part in parts)
            {
                if (int.TryParse(part, out var f))
                {
                    var attr = (AnsiAttributes)f;
                    if (attr == AnsiAttributes.ATTR_DEFAULT)
                    {
                        resetColors = true;
                    }
                    else
                    {
                        fg = fg ?? Ansi.ForegroundColorFromAttributes(attr);
                        bg = bg ?? Ansi.BackgroundColorFromAttributes(attr);
                    }
                }
            }

            if (resetColors)
            {
                _handler.ResetColors();
            }

            if (fg != null && bg != null)
            {
                _handler.SetColors(fg.Value, bg.Value);
            }
            else if (fg != null)
            {
                _handler.SetForegroundColor(fg.Value);
            }
            else if (bg != null)
            {
                _handler.SetBackgroundColor(bg.Value);
            }
        }
    }
}