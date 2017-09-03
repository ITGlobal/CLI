using System;
using System.Threading;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class CtrlCInterceptor : ICtrlCInterceptor
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public CtrlCInterceptor()
        {
            Console.CancelKeyPress += OnCancelKeyPress;
        }

        public CancellationToken CancellationToken => _cts.Token;

        public void Dispose()
        {
            Console.CancelKeyPress -= OnCancelKeyPress;
            _cts.Dispose();
        }

        private void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _cts.Cancel();
        }
    }
}