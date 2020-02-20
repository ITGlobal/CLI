using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class LiveOutputManagerImpl : ILiveOutputManager, ILiveOutputItemOwner, ITerminalLockOwner
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private const int ANIMATION_STEP_MS = 100;

        private readonly ITerminalLock _terminal;
        private readonly object _syncRoot = new object();

        private readonly List<ILiveOutputItem> _items = new List<ILiveOutputItem>();

        private readonly ISpinnerRenderer _spinnerRenderer;
        private readonly IProgressBarRenderer _progressBarRenderer;

        private readonly Timer _timer;

        private int _time;
        private bool _needsRedraw;

        private bool _cleanupAfter;

        public LiveOutputManagerImpl(ISpinnerRenderer spinnerRenderer, IProgressBarRenderer progressBarRenderer)
        {
            _spinnerRenderer = spinnerRenderer;
            _progressBarRenderer = progressBarRenderer;

            _terminal = Terminal.Lock(this);

            _timer = new Timer(OnTimer, null, ANIMATION_STEP_MS, ANIMATION_STEP_MS);
        }


        public void WipeAfter(bool enable = true)
        {
            _cleanupAfter = enable;
        }

        public ITerminalLiveText CreateText(params AnsiString[] str)
        {
            return Create(() =>
            {
                var item = new TerminalLiveTextImpl(this);
                item.Write(str);
                return item;
            });
        }

        public ITerminalLiveSpinner CreateSpinner(params AnsiString[] str)
        {
            return Create(() =>
            {
                var item = new TerminalLiveSpinnerImpl(this, _spinnerRenderer);
                item.Write(str);
                return item;
            });
        }

        public ITerminalLiveProgressBar CreateProgressBar(int value, AnsiString[] str)
        {
            return Create(() =>
            {
                var item = new TerminalLiveProgressBarImpl(this, _progressBarRenderer);
                item.Write(value, str);
                return item;
            });
        }

        private T Create<T>(Func<T> create)
            where T : ILiveOutputItem
        {
            lock (_syncRoot)
            {
                Clear();

                var item = create();
                _items.Add(item);

                Draw();

                return item;
            }
        }

        public void Dispose()
        {
            _timer.Dispose();

            lock (_syncRoot)
            {
                var time = _time;

                Clear();

                for (var i = 0; i < _items.Count; i++)
                {
                    var item = _items[i];
                    if (item.DrawFinal(_terminal, time, _cleanupAfter))
                    {
                        _terminal.Stderr.WriteLine();
                    }
                }
            }
            
            // Move cursor to the beginning of current line
            _terminal.MoveToLine(0);

            _terminal.Dispose();
        }

        void ITerminalLockOwner.Begin()
        {
            Monitor.Enter(_syncRoot);
            Clear();
        }

        void ITerminalLockOwner.WriteOutput(AnsiChar c)
        {
            var str = new AnsiString(new[] { c, });
            _terminal.Stdout.Write(str);
        }

        void ITerminalLockOwner.WriteError(AnsiChar c)
        {
            var str = new AnsiString(new[] { c });
            _terminal.Stderr.Write(str);
        }

        void ITerminalLockOwner.End()
        {
            // Move cursor to the beginning of current line
            _terminal.MoveToLine(0);

            Draw();
            Monitor.Exit(_syncRoot);
        }

        void ILiveOutputItemOwner.RequestRedraw()
        {
            lock (_syncRoot)
            {
                _needsRedraw = true;
            }
        }

        private void Clear()
        {
            lock (_syncRoot)
            {
                for (var i = _items.Count - 1; i >= 0; i--)
                {
                    var item = _items[i];

                    if (i != _items.Count - 1)
                    {
                        _terminal.MoveToLine(-1);
                    }

                    item.Clear(_terminal);
                }
            }
        }

        private void Draw()
        {
            lock (_syncRoot)
            {
                var time = _time;

                for (var i = 0; i < _items.Count; i++)
                {
                    var item = _items[i];
                    item.Draw(_terminal, time);
                    if (i != _items.Count - 1)
                    {
                        _terminal.Stderr.WriteLine();
                    }
                }
            }
        }

        private void OnTimer(object _)
        {
            lock (_syncRoot)
            {
                _time++;
                var time = _time;

                for (var i = 0; i < _items.Count; i++)
                {
                    var item = _items[i];
                    item.OnTimer(time);
                }

                if (!_needsRedraw)
                {
                    return;
                }

                for (var i = _items.Count - 1; i >= 0; i--)
                {
                    var item = _items[i];

                    if (item.NeedsRedraw)
                    {
                        var offset = _items.Count - i - 1;

                        _terminal.MoveToLine(-offset);

                        item.Clear(_terminal);
                        item.Draw(_terminal, time);

                        _terminal.MoveToLine(offset);
                    }
                }
            }
        }
    }
}