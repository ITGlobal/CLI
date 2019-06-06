using System.Collections.Generic;
using System.Threading.Tasks;
using ITGlobal.CommandLine.Impl;

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal static class CliHandlerHelper
    {
#if NET40 || NET45
        public static void Run(this IEnumerable<CliAsyncHandler> handlers, CliContext ctx)
        {
            foreach (var handler in handlers)
            {
                handler(ctx).Wait();
                if (ctx.ExitCode != null)
                {
                    break;
                }
            }
        }
#else
        public static void Run(this IEnumerable<CliAsyncHandler> handlers, CliContext ctx)
        {
            RunAsync(handlers, ctx).GetAwaiter().GetResult();
        }

        private static async Task RunAsync(IEnumerable<CliAsyncHandler> handlers, CliContext ctx)
        {
            foreach (var handler in handlers)
            {
                await handler(ctx);
                if (ctx.ExitCode != null)
                {
                    break;
                }
            }
        }
#endif

        public static CliAsyncHandler ToAsyncHandler(this CliHandler handler)
        {
            return ctx =>
            {
                handler(ctx);
#if NET40 || NET45
                return TaskExt.CompletedTask;
#else
                return Task.CompletedTask;
#endif
            };
        }
    }
}
