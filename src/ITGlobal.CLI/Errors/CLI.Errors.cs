using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Handles errors during execution of an action
        /// </summary>
        [PublicAPI]
        public static int HandleErrors([NotNull] Action action)
        {
            return HandleErrors(() =>
            {
                action();
                return 0;
            });
        }

        /// <summary>
        ///     Handles errors during execution of an action
        /// </summary>
        [PublicAPI]
        public static int HandleErrors([NotNull] Func<int> action)
        {
            try
            {
                var exitCode = action();
                return exitCode;
            }
            catch (OperationCanceledException)
            {
                return -1;
            }
            catch (CommandLineException e)
            {
                PrintException(e);
                return e.HResult;
            }
            catch (Exception e)
            {
                PrintException(e);
                return e.HResult;
            }
        }

        /// <summary>
        ///     Handles errors during execution of an async action
        /// </summary>
        [PublicAPI]
        public static Task<int> HandleErrorsAsync([NotNull] Func<Task> action)
        {
            return HandleErrorsAsync(async () =>
            {
                await action();
                return 0;
            });
        }

        /// <summary>
        ///     Handles errors during execution of an async action
        /// </summary>
        [PublicAPI]
        public static async Task<int> HandleErrorsAsync([NotNull] Func<Task<int>> action)
        {
            try
            {
                var exitCode = await action();
                return exitCode;
            }
            catch (OperationCanceledException)
            {
                return -1;
            }
            catch (CommandLineException e)
            {
                PrintException(e);
                return e.HResult;
            }
            catch (Exception e)
            {
                PrintException(e);
                return e.HResult;
            }
        }

        private static void PrintException(CommandLineException e)
        {
            using (WithForeground(ConsoleColor.Red))
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintException(Exception e)
        {
            using (WithColors(ConsoleColor.White, ConsoleColor.DarkRed))
            {
                Console.WriteLine($"{Text.Error}! [{e.GetType().FullName}]");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
