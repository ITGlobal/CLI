using System;
using System.Collections.Generic;

#if !NET40
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
#endif

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class SuccessfulCliParserResult : ICliParserResult
    {
        private readonly IEnumerable<CliAsyncHandler> _handlers;
        private readonly ITerminal _terminal;
        private readonly string _logo;
        private readonly CliContext _ctx;

        public SuccessfulCliParserResult(
            IEnumerable<CliAsyncHandler> handlers,
            ITerminal terminal,
            string logo,
            CliContext ctx)
        {
            _handlers = handlers;
            _terminal = terminal;
            _logo = logo;
            _ctx = ctx;
        }

        public int Run()
        {
            try
            {
#if NET40 || NET45
                var exitCode = RunImpl();
#else
                var exitCode = RunAsync().GetAwaiter().GetResult();
#endif

                return exitCode;
            }
            catch (AggregateException e) when (e.InnerException != null)
            {
#if NET40
                throw new Exception(e.InnerException.Message);
#else
                var ex = ExceptionDispatchInfo.Capture(e.InnerException);
                ex.Throw();
                throw;
#endif
            }
        }

#if NET40 || NET45
        private int RunImpl()
        {
            if (!string.IsNullOrEmpty(_logo))
            {
                _terminal.Stdout.WriteLine(_logo.WithForeground(ConsoleColor.Cyan));
                _terminal.Stdout.WriteLine();
            }

            foreach (var handler in _handlers)
            {
                handler(_ctx).Wait();
                if (_ctx.ExitCode != null)
                {
                    return _ctx.ExitCode.Value;
                }
            }

            return _ctx.ExitCode ?? 0;
        }
#else
        private async Task<int> RunAsync()
        {
            if (!string.IsNullOrEmpty(_logo))
            {
                _terminal.Stdout.WriteLine(_logo.WithForeground(ConsoleColor.Cyan));
                _terminal.Stdout.WriteLine();
            }

            foreach (var handler in _handlers)
            {
                await handler(_ctx);
                if (_ctx.ExitCode != null)
                {
                    return _ctx.ExitCode.Value;
                }
            }

            return _ctx.ExitCode ?? 0;
        }
#endif
    }
}