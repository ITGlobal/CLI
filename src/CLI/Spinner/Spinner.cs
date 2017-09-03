using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class Spinner : ISpinner, ISafeTextWriterOwner
    {
        private readonly TextWriter _stdOut;
        private readonly TextWriter _stdErr;

        private readonly object _consoleLock = new object();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

#if !NET40
        private readonly Task _backgroundTask;
#else
        private readonly Thread _backgroundThread;
#endif

        private readonly SpinnerStyle _style;
        private string _title;

        private int _index;
        private bool _shouldCleanLine = true;

        public Spinner(string title, SpinnerStyle style)
        {
            _title = title;
            _style = style;

            _stdOut = Console.Out;
            _stdErr = Console.Error;

            Console.SetOut(new SafeTextWriter(_stdOut, this));
            Console.SetError(new SafeTextWriter(_stdErr, this));

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
            Console.SetOut(_stdOut);
            Console.SetError(_stdErr);
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

        public void EndPrint()
        {
            Monitor.Exit(_consoleLock);
        }

        public void Redraw()
        {
            lock (_consoleLock)
            {
                DrawOnce();
            }
        }

        private void ClearLine()
        {
            lock (_consoleLock)
            {
                Console.CursorLeft = 0;
                for (var i = 0; i < Console.WindowWidth - 1; i++)
                {
                    _stdOut.Write(' ');
                }
                Console.CursorLeft = 0;
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

                    await Task.Delay(_style.AnimationInterval, token);
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

                Thread.Sleep(_style.AnimationInterval);
                Interlocked.Increment(ref _index);
            }
        }
#endif

        private void DrawOnce()
        {
            var title = Interlocked.CompareExchange(ref _title, null, null);
            var index = Interlocked.CompareExchange(ref _index, 0, 0);
            index = index % _style.Glyphs.Length;

            lock (_consoleLock)
            {
                var isCursorVisible = Console.CursorVisible;
                Console.CursorVisible = false;
                Console.CursorLeft = 0;

                using (WithColors(_style.SpinnerFgColor, _style.SpinnerBgColor))
                {
                    _stdOut.Write(_style.Glyphs[index]);
                }

                _stdOut.Write(' ');
                var maxLabelWidth = Console.WindowWidth - 3;
                var labelWidth = Math.Min(title.Length, maxLabelWidth);
                using (WithColors(_style.TitleFgColor, _style.TitleBgColor))
                {
                    var i = 0;
                    for (; i < labelWidth; i++)
                    {
                        _stdOut.Write(title[i]);
                    }
                    for (; i < maxLabelWidth; i++)
                    {
                        _stdOut.Write(' ');
                    }
                }

                Console.CursorVisible = isCursorVisible;
                _shouldCleanLine = true;
            }
        }
    }
}