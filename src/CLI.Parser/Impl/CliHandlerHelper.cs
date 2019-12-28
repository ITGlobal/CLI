using System.Collections.Generic;

#if NET45
using ITGlobal.CommandLine.Impl;
#else
using System.Threading.Tasks;
#endif

namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal static class CliHandlerHelper
    {
#if NET45
        public static void Run(this IEnumerable<CliAsyncHook> hooks, CliContext ctx)
        {
            foreach (var hook in hooks)
            {
                hook(ctx).Wait();
                if (ctx.ExitCode != null)
                {
                    break;
                }
            }
        }
#else
        public static void Run(this IEnumerable<CliAsyncHook> hooks, CliContext ctx)
        {
            RunAsync(hooks, ctx).GetAwaiter().GetResult();
        }

        private static async Task RunAsync(IEnumerable<CliAsyncHook> hooks, CliContext ctx)
        {
            foreach (var hook in hooks)
            {
                await hook(ctx);
                if (ctx.ExitCode != null)
                {
                    break;
                }
            }
        }
#endif

#if NET45
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

        public static CliAsyncHook ToAsyncHook(this CliHook handler)
        {
            return ctx =>
            {
                handler(ctx);
#if NET45
                return TaskExt.CompletedTask;
#else
                return Task.CompletedTask;
#endif
            };
        }

        public static CliAsyncHandler ToAsyncHandler(this CliHandler handler)
        {
            return ctx =>
            {
                handler(ctx);
#if NET45
                return TaskExt.CompletedTask;
#else
                return Task.CompletedTask;
#endif
            };
        }
    }
}
