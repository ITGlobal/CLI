using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     A unified error handler for terminal application
    /// </summary>
    [PublicAPI]
    public static class TerminalErrorHandler
    {
        /// <summary>
        ///     Error title text
        /// </summary>
        public static AnsiString ErrorText { get; set; } =  AnsiString.FromString("Error!");

        /// <summary>
        ///     Inner exception separator text
        /// </summary>
        public static AnsiString InnerExceptionText { get; set; } = AnsiString.FromString("--- Inner Exception ---");

        /// <summary>
        ///     Handles errors during execution of an action
        /// </summary>
        [PublicAPI]
        public static int Handle([NotNull] Action action)
        {
            return Handle(() =>
            {
                action();
                return 0;
            });
        }

        /// <summary>
        ///     Handles errors during execution of an action
        /// </summary>
        [PublicAPI]
        public static int Handle([NotNull] Func<int> action)
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
                PrintExceptionImpl(e);
                return e.HResult;
            }
            catch (Exception e)
            {
                PrintExceptionImpl(e);
                return e.HResult;
            }
        }

        /// <summary>
        ///     Handles errors during execution of an async action
        /// </summary>
        [PublicAPI]
        public static Task<int> HandleAsync([NotNull] Func<Task> action)
        {
            return HandleAsync(async () =>
            {
                await action();
                return 0;
            });
        }

        /// <summary>
        ///     Handles errors during execution of an async action
        /// </summary>
        [PublicAPI]
        public static async Task<int> HandleAsync([NotNull] Func<Task<int>> action)
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
                PrintExceptionImpl(e);
                return e.HResult;
            }
            catch (Exception e)
            {
                PrintExceptionImpl(e);
                return e.HResult;
            }
        }

        /// <summary>
        ///     Pretty-prints an exception into console
        /// </summary>
        public static void PrintException([NotNull] Exception exception)
        {
            var e = exception;
            while (e != null)
            {
                if (e != exception)
                {
                    if (!string.IsNullOrEmpty(InnerExceptionText))
                    {
                        Console.Error.WriteLine($"{InnerExceptionText}".WhiteOnDarkRed());
                    }
                }

                switch (e)
                {
                    case CommandLineException ex:
                        {
                            Console.Error.WriteLine(ex.Message.WhiteOnDarkRed());
                        }

                        break;

                    default:
                        Console.Error.WriteLine($"[{e.GetType().FullName}] {e.Message}".WhiteOnDarkRed());
                        Console.Error.WriteLine(e.StackTrace.Red());
                        break;
                }

                e = e.InnerException;
            }
        }

        private static void PrintExceptionImpl(CommandLineException e)
        {
            Console.Error.WriteLine(e.Message.Red());
        }

        private static void PrintExceptionImpl(Exception e)
        {
            if (!string.IsNullOrEmpty(ErrorText))
            {
                Console.Error.Write($"{ErrorText} ".WhiteOnDarkRed());
            }

            Console.Error.WriteLine($"[{e.GetType().FullName}]".WhiteOnDarkRed());
            Console.Error.WriteLine(e.Message.WhiteOnDarkRed());
            Console.Error.WriteLine(e.StackTrace.Red());
        }
    }
}
