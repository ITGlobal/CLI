namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TerminalLiveProgressBarImpl : ITerminalLiveProgressBar, ILiveOutputItem
    {
        private readonly ILiveOutputItemOwner _owner;
        private readonly IProgressBarRenderer _renderer;

        private readonly object _textLock = new object();
#if !NET45
        private ColoredString[] _text = System.Array.Empty<ColoredString>();
#else
        private ColoredString[] _text = new ColoredString[0];
#endif
        private int _value;
        private bool _needsRedraw = true;
        private bool _isCompleted;

        public TerminalLiveProgressBarImpl(ILiveOutputItemOwner owner, IProgressBarRenderer renderer)
        {
            _owner = owner;
            _renderer = renderer;
        }

        public void Write(int? value, ColoredString[] strs)
        {
            lock (_textLock)
            {
                if (!ColoredStringHelper.AreEqual(_text, strs) ||
                    _value != (value ?? _value) ||
                    _isCompleted)
                {
                    _text = strs ?? _text;
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

        public void Complete(params ColoredString[] strs)
        {
            lock (_textLock)
            {
                if (!ColoredStringHelper.AreEqual(_text, strs) || !_isCompleted)
                {
                    _text = strs;
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

        public bool DrawFinal(ITerminalLock terminal, int time)
        {
            lock (_textLock)
            {
                if (!_isCompleted)
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
                    foreach (var s in _text)
                    {
                        terminal.Stderr.Write(s);
                    }
                }
                else
                {
                    _renderer.Render(terminal, _text, _value, time);
                }

                _needsRedraw = false;
            }
        }
    }
}