namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TerminalLiveTextImpl : ITerminalLiveText, ILiveOutputItem
    {
        private readonly ILiveOutputItemOwner _owner;

        private readonly object _textLock = new object();
        private AnsiString _text = AnsiString.Empty;
        private bool _needsRedraw = true;
        private bool? _wipeAfter;

        public TerminalLiveTextImpl(ILiveOutputItemOwner owner)
        {
            _owner = owner;
        }

        public void WipeAfter(bool enable = true)
        {
            _wipeAfter = enable;
        }

        public void Write(params AnsiString[] strs)
        {
            var s = AnsiString.Concat(strs);
            lock (_textLock)
            {
                if (s != _text)
                {
                    _text = s;
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
            Draw(terminal);
        }

        bool ILiveOutputItem.DrawFinal(ITerminalLock terminal, int time, bool defaultWipeAfter)
        {
            lock (_textLock)
            {
                if (_wipeAfter ?? defaultWipeAfter)
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
                terminal.Stderr.Write(_text);
                _needsRedraw = false;
            }
        }
    }
}
