namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TerminalLiveSpinnerImpl : ITerminalLiveSpinner, ILiveOutputItem
    {
        private readonly ILiveOutputItemOwner _owner;
        private readonly ISpinnerRenderer _renderer;

        private readonly object _textLock = new object();
#if !NET45
        private ColoredString[] _text = System.Array.Empty<ColoredString>();
#else
        private ColoredString[] _text = new ColoredString[0];
#endif
        private bool _needsRedraw = true;
        private bool _isCompleted;
        private bool? _wipeAfter;

        public TerminalLiveSpinnerImpl(ILiveOutputItemOwner owner, ISpinnerRenderer renderer)
        {
            _owner = owner;
            _renderer = renderer;
        }

        public void WipeAfter(bool enable = true)
        {
            _wipeAfter = enable;
        }

        public void Write(params ColoredString[] strs)
        {
            lock (_textLock)
            {
                if (!ColoredStringHelper.AreEqual(_text, strs))
                {
                    _text = strs;
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
                _text = strs;
                _isCompleted = true;
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

                DrawCompleted(terminal);

                return true;
            }
        }

        void ILiveOutputItem.OnTimer(int time)
        {
            lock (_textLock)
            {
                _needsRedraw = true;
            }

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
                    _renderer.Render(terminal, _text, time);
                }

                _needsRedraw = false;
            }
        }

        private void DrawCompleted(ITerminalLock terminal)
        {
            lock (_textLock)
            {
                foreach (var s in _text)
                {
                    terminal.Stderr.Write(s);
                }

                _needsRedraw = false;
            }
        }
    }
}