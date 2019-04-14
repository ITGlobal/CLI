using System;
using System.Threading;
using ITGlobal.CommandLine.Impl;

#if !NET40
using System.Threading.Tasks;
#endif

namespace ITGlobal.CommandLine
{
    internal sealed class SpinnerImpl : ISpinner, ITerminalLockOwner
    {
        private readonly ITerminal _terminal;
        private readonly ITerminalLock _terminalLock;

        private readonly SpinnerRenderer _renderer;

        private readonly object _consoleLock = new object();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

#if !NET40
        private readonly Task _backgroundTask;
#else
        private readonly Thread _backgroundThread;
#endif

        private string _title;

        private int _index;
        private bool _shouldCleanLine = true;
        
        public SpinnerImpl(ITerminal terminal, string title, SpinnerRenderer renderer)
        {
            _terminal = terminal;
            _terminalLock = terminal.Lock(this);
            _title = title;
            _renderer = renderer;

            DrawOnce();

#if !NET40
            _backgroundTask = Task.Run(RedrawWorkerAsync);
#else
            _backgroundThread = new Thread(RedrawWorker);
            _backgroundThread.Start();
#endif      
        }

        public void SetTitle(string title)
        {
            Interlocked.Exchange(ref _title, title);
        }

        public void Dispose()
        {
            _cts.Cancel();
#if !NET40
            _backgroundTask.Wait();
#else
            _backgroundThread.Join();
#endif    

            ClearLine();
            _terminalLock.Dispose();
        }

        public void BeginPrint()
        {
            Monitor.Enter(_consoleLock);

            if (_shouldCleanLine)
            {
                ClearLine();
                _shouldCleanLine = false;
            }
        }

        public void Redraw()
        {
            lock (_consoleLock)
            {
                DrawOnce();
            }
        }

        public void EndPrint()
        {
            Monitor.Exit(_consoleLock);
        }

        private void ClearLine()
        {
            lock (_consoleLock)
            {
                _terminalLock.Stdout.MoveCursor(0);
                for (var i = 0; i < _terminalLock.Stdout.WindowWidth - 1; i++)
                {
                    _terminalLock.Stdout.Write(' ');
                }
                _terminalLock.Stdout.MoveCursor(0);
            }
        }

#if !NET40
        private async Task RedrawWorkerAsync()
        {
            try
            {
                var token = _cts.Token;
                while (!token.IsCancellationRequested)
                {
                    DrawOnce();

                    await Task.Delay(_renderer.AnimationStep, token);
                    Interlocked.Increment(ref _index);
                }
            }
            catch (OperationCanceledException) { }
        }
#else
        private void RedrawWorker()
        {
            var token = _cts.Token;
            while (!token.IsCancellationRequested)
            {
                DrawOnce();

                Thread.Sleep(_renderer.AnimationStep);
                Interlocked.Increment(ref _index);
            }
        }
#endif

        private void DrawOnce()
        {
            var title = Interlocked.CompareExchange(ref _title, null, null);
            var index = Interlocked.CompareExchange(ref _index, 0, 0);

            lock (_consoleLock)
            {
                var isCursorVisible = _terminalLock.Stdout.IsCursorVisible;
                _terminalLock.Stdout.IsCursorVisible = false;
                _terminalLock.Stdout.MoveCursor(0);

                _renderer.Render(_terminalLock.Stdout, title, index);
                
                _terminalLock.Stdout.IsCursorVisible = isCursorVisible;
                _shouldCleanLine = true;
            }
        }
    }
}