namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TerminalLiveTextImpl : ITerminalLiveText, ILiveOutputItem
    {
        private readonly ILiveOutputItemOwner _owner;

        private readonly object _textLock = new object();
#if !NET45
        private ColoredString[] _text = System.Array.Empty<ColoredString>();
#else
        private ColoredString[] _text = new ColoredString[0];
#endif
        private bool _needsRedraw = true;
        private bool _isCompleted;

        public TerminalLiveTextImpl(ILiveOutputItemOwner owner)
        {
            _owner = owner;
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
            Draw(terminal);
        }

        bool ILiveOutputItem.DrawFinal(ITerminalLock terminal, int time)
        {
            lock (_textLock)
            {
                if (!_isCompleted)
                {
                    return false;
                }

                Draw(terminal);
                return true;
            }
        }

        void ILiveOutputItem.OnTimer(int time) { }

        private void Draw(ITerminalLock terminal)
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
