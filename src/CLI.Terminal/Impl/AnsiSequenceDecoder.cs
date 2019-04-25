using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class AnsiSequenceDecoder
    {
        private readonly IAnsiCommandHandler _handler;
        private readonly StringBuilder _sb = new StringBuilder();

        private bool _isEscSequence;

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

            if (c == Ansi.ESC)
            {
                _isEscSequence = true;
                return;
            }

            _handler.Write(c);
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
            foreach (var part in parts)
            {
                if (int.TryParse(part, out var f))
                {
                    var attr = (AnsiAttributes) f;
                    if (attr == AnsiAttributes.ATTR_DEFAULT)
                    {
                        _handler.ResetColors();
                    }
                    else
                    {
                        var fg = Ansi.ForegroundColorFromAttributes(attr);
                        var bg = Ansi.BackgroundColorFromAttributes(attr);

                        if (fg != null)
                        {
                            _handler.SetForegroundColor(fg.Value);
                        }

                        if (bg != null)
                        {
                            _handler.SetBackgroundColor(bg.Value);
                        }
                    }
                }
            }
        }
    }
}