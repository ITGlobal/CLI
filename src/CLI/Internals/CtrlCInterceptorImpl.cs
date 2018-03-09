using System;
using System.Threading;

namespace ITGlobal.CommandLine.Internals
{
    internal sealed class CtrlCInterceptorImpl : ICtrlCInterceptor
    {
        private readonly ITerminal _terminal;
        private readonly IDisposable _disposable;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public CtrlCInterceptorImpl(ITerminal terminal)
        {
            _terminal = terminal;
            _disposable = _terminal.Stdin.AttachCancelKeyHandler(OnCancelKeyPress);
        }

        public CancellationToken CancellationToken => _cts.Token;

        public void Dispose()
        {
            _disposable.Dispose();
            _cts.Dispose();
        }

        private bool OnCancelKeyPress()
        {
            _cts.Cancel();

            return true;
        }
    }

}
