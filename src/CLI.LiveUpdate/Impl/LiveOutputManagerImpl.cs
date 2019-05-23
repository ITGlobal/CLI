using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class LiveOutputManagerImpl : ILiveOutputManager, ILiveOutputItemOwner, ITerminalLockOwner
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private const int ANIMATION_STEP_MS = 250;

        private readonly ITerminalLock _terminal;
        private readonly object _outputLock = new object();

        private readonly object _syncRoot = new object();

        private readonly List<ILiveOutputItem> _items = new List<ILiveOutputItem>();

        private readonly ISpinnerRenderer _spinnerRenderer;
        private readonly IProgressBarRenderer _progressBarRenderer;

        private readonly Timer _timer;

        private int _time;
        private bool _needsRedraw;

        public LiveOutputManagerImpl(ISpinnerRenderer spinnerRenderer, IProgressBarRenderer progressBarRenderer)
        {
            _spinnerRenderer = spinnerRenderer;
            _progressBarRenderer = progressBarRenderer;

            _terminal = Terminal.Lock(this);

            _timer = new Timer(OnTimer, null, ANIMATION_STEP_MS, ANIMATION_STEP_MS);
        }


        public ITerminalLiveText CreateText(params ColoredString[] str)
        {
            TerminalLiveTextImpl item;

            lock (_syncRoot)
            {
                item = new TerminalLiveTextImpl(this);
                _items.Add(item);
            }

            item.Write(str);

            Redraw();
            return item;
        }

        public ITerminalLiveSpinner CreateSpinner(params ColoredString[] str)
        {
            TerminalLiveSpinnerImpl item;

            lock (_syncRoot)
            {
                item = new TerminalLiveSpinnerImpl(this, _spinnerRenderer);
                _items.Add(item);
            }

            item.Write(str);

            Redraw();
            return item;
        }

        public ITerminalLiveProgressBar CreateProgressBar(int value, ColoredString[] str)
        {
            TerminalLiveProgressBarImpl item;

            lock (_syncRoot)
            {
                item = new TerminalLiveProgressBarImpl(this, _progressBarRenderer);
                _items.Add(item);
            }

            item.Write(value, str);

            Redraw();
            return item;
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
                    if (item.DrawFinal(_terminal, time))
                    {
                        _terminal.Stderr.WriteLine();
                    }
                }
            }

            _terminal.Dispose();
        }

        void ITerminalLockOwner.Begin()
        {
            Monitor.Enter(_syncRoot);
            Monitor.Enter(_outputLock);
            Clear();
        }

        void ITerminalLockOwner.WriteOutput(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var str = new ColoredString(new string(c, 1), foregroundColor, backgroundColor);
            _terminal.Stdout.Write(str);
        }

        void ITerminalLockOwner.WriteError(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var str = new ColoredString(new string(c, 1), foregroundColor, backgroundColor);
            _terminal.Stderr.Write(str);
        }

        void ITerminalLockOwner.End()
        {
            Draw();
            Monitor.Exit(_outputLock);
            Monitor.Exit(_syncRoot);
        }

        void ILiveOutputItemOwner.RequestRedraw()
        {
            lock (_syncRoot)
            {
                _needsRedraw = true;
            }
        }

        private void Redraw()
        {
            lock (_syncRoot)
            {
                lock (_outputLock)
                {
                    Clear();
                    Draw();

                    _needsRedraw = false;
                }
            }
        }

        private void Clear()
        {
            lock (_syncRoot)
            {
                lock (_outputLock)
                {
                    for (var i = _items.Count - 1; i >= 0; i--)
                    {
                        var item = _items[i];

                        var offset = _items.Count - i - 1;
                        _terminal.MoveToLine(offset);
                        item.Clear(_terminal);
                    }
                }
            }
        }

        private void Draw()
        {
            lock (_syncRoot)
            {
                lock (_outputLock)
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


                var currentLine = _items.Count;

                for (var i = _items.Count - 1; i >= 0; i--)
                {
                    var item = _items[i];

                    if (item.NeedsRedraw)
                    {
                        var offset = _items.Count - i - 1;
                        
                        _terminal.MoveToLine(offset);

                        item.Clear(_terminal);
                        item.Draw(_terminal, time);

                        _terminal.MoveToLine(-offset);
                    }
                }

                if (currentLine != _items.Count)
                {
                    _terminal.MoveToLine(_items.Count - currentLine);
                }
            }

            Redraw();
        }
    }
}