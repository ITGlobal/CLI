using System;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class CtrlCInterceptorImpl : ICtrlCInterceptor
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public CtrlCInterceptorImpl()
        {
            Console.CancelKeyPress += OnCancelKeyPress;
        }

        public CancellationToken CancellationToken => _cts.Token;

        public void Dispose()
        {
            Console.CancelKeyPress -= OnCancelKeyPress;
        }

        private void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _cts.Cancel();
        }
    }

}
