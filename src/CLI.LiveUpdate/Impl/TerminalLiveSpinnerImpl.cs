using System;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class TerminalLiveSpinnerImpl : ITerminalLiveSpinner, ILiveOutputItem
    {
        private readonly ILiveOutputItemOwner _owner;
        private readonly ISpinnerRenderer _renderer;

        private readonly object _textLock = new object();
        private ColoredString[] _text = Array.Empty<ColoredString>();
        private bool _needsRedraw = true;
        private bool _isCompleted;

        public TerminalLiveSpinnerImpl(ILiveOutputItemOwner owner, ISpinnerRenderer renderer)
        {
            _owner = owner;
            _renderer = renderer;
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
                    _renderer.Render(terminal, _text, time);
                }

                _needsRedraw = false;
            }
        }
    }
}