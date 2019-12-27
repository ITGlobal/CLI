namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TerminalLiveProgressBarImpl : ITerminalLiveProgressBar, ILiveOutputItem
    {
        private readonly ILiveOutputItemOwner _owner;
        private readonly IProgressBarRenderer _renderer;

        private readonly object _textLock = new object();
        private AnsiString _text = AnsiString.Empty;
        private int _value;
        private bool _needsRedraw = true;
        private bool _isCompleted;
        private bool? _wipeAfter;

        public TerminalLiveProgressBarImpl(ILiveOutputItemOwner owner, IProgressBarRenderer renderer)
        {
            _owner = owner;
            _renderer = renderer;
        }

        public void WipeAfter(bool enable = true)
        {
            _wipeAfter = enable;
        }

        public void Write(params AnsiString[] strs) => Write(null, strs);

        public void Write(int? value, AnsiString[] strs)
        {
            lock (_textLock)
            {
                var s = strs != null ? AnsiString.Concat(strs) : _text;

                if (s != _text ||
                    _value != (value ?? _value) ||
                    _isCompleted)
                {
                    _text = s;
                    _value = value ?? _value;
                    _isCompleted = false;
                    _needsRedraw = true;
                }
                else
                {
                    return;
                }
            }

            _owner.RequestRedraw();
        }

        public void Complete(params AnsiString[] strs)
        {
            var s = AnsiString.Concat(strs);
            lock (_textLock)
            {
                if (s != _text || !_isCompleted)
                {
                    _text = s;
                    _isCompleted = true;
                    _needsRedraw = true;
                }
                else
                {
                    return;
                }
            }

            _owner.RequestRedraw();
        }

        bool ILiveOutputItem.NeedsRedraw
        {
            get
            {
                lock (_textLock)
                {
                    return _needsRedraw;
                }
            }
        }

        void ILiveOutputItem.Clear(ITerminalLock terminal)
        {
            terminal.ClearLine();
        }

        void ILiveOutputItem.Draw(ITerminalLock terminal, int time)
        {
            Draw(terminal, time);
        }

        bool ILiveOutputItem.DrawFinal(ITerminalLock terminal, int time, bool defaultWipeAfter)
        {
            lock (_textLock)
            {
                if (_wipeAfter ?? defaultWipeAfter)
                {
                    return false;
                }

                Draw(terminal, time);
                return true;
            }
        }

        void ILiveOutputItem.OnTimer(int time)
        {
            _owner.RequestRedraw();
        }

        private void Draw(ITerminalLock terminal, int time)
        {
            lock (_textLock)
            {
                if (_isCompleted)
                {
                    DrawCompleted(terminal);
                }
                else
                {
                    _renderer.Render(terminal, _text, _value, time);
                }

                _needsRedraw = false;
            }
        }

        private void DrawCompleted(ITerminalLock terminal)
        {
            lock (_textLock)
            {
                terminal.Stderr.Write(_text);

                _needsRedraw = false;
            }
        }
    }
}