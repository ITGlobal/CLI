using System;
using System.Threading;
using System.Threading.Tasks;

#if !NET40

#endif

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class SpinnerImpl : ISpinner, ITerminalLockOwner
    {
        private readonly ITerminalLock _terminal;

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
        
        public SpinnerImpl(string title, SpinnerRenderer renderer)
        {
            _terminal = Terminal.Lock(this);
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

            _terminal.ClearLine();
            _terminal.Dispose();
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
                _terminal.ClearLine();
                _renderer.Render(_terminal.Stderr, title, index);
            }
        }

        void ITerminalLockOwner.Begin()
        {
            Monitor.Enter(_consoleLock);
            _terminal.ClearLine();
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
            DrawOnce();
            Monitor.Exit(_consoleLock);
        }
    }
}