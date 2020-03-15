using System;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class CtrlCInterceptorImpl : ICtrlCInterceptor
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public CancellationToken CancellationToken => _cts.Token;

        public void Trigger()
        {
            _cts.Cancel();
        }

        public void Dispose()
        {
            Terminal.DetachCtrlCInterceptor();
        }
    }
}
