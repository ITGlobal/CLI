using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine.Errors
{
    [PublicAPI]
    public static class TerminalErrorHandler
    {
        [NotNull]
        public static string ErrorText { get; set; } = "Error!";

        [NotNull]
        public static string InnerExceptionText { get; set; } = "--- Inner Exception ---";

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
#if !NET40
                return e.HResult;
#else
                return -1;        
#endif
                
            }
            catch (Exception e)
            {
                PrintExceptionImpl(e);
#if !NET40
                return e.HResult;
#else
                return -1;        
#endif
            }
        }

        /// <summary>
        ///     Handles errors during execution of an async action
        /// </summary>
        [PublicAPI]
#if !NET40
        public static Task<int> HandleAsync([NotNull] Func<Task> action)
        {
            return HandleAsync(async () =>
            {
                await action();
                return 0;
            });
        }
#else
        public static Task<int> HandleAsync([NotNull] Func<Task> action)
        {
            return HandleAsync(() =>
            {
                return action().ContinueWith(_=>0, TaskContinuationOptions.OnlyOnRanToCompletion);
            });
        }
#endif

        /// <summary>
        ///     Handles errors during execution of an async action
        /// </summary>
        [PublicAPI]
#if !NET40
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

#else
        public static Task<int> HandleAsync([NotNull] Func<Task<int>> action)
        {
            return action().ContinueWith(task => {
                if(task.IsCanceled)
                {
                    return -1;
                }

                if(task.IsFaulted)
                {
                    var commandLineException = task.Exception?.InnerException as CommandLineException;
                    if(commandLineException != null)
                    {
                         PrintExceptionImpl(commandLineException);
                    }
                    else
                    {
                       PrintExceptionImpl(task.Exception?.InnerException);
                    }
                    
                    return -1;
                }

                 return task.Result;
            });
        }
#endif

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
                    using (Terminal.Stdout.WithForeground(ConsoleColor.DarkRed))
                    {
                        Terminal.Stdout.WriteLine(InnerExceptionText);
                    }
                }

                switch (e)
                {
                    case CommandLineException ex:
                        using (Terminal.Stdout.WithColors(ConsoleColor.White, ConsoleColor.DarkRed))
                        {
                            Terminal.Stdout.WriteLine(ex.Message);
                        }

                        break;

                    default:
                        using (Terminal.Stdout.WithColors(ConsoleColor.White, ConsoleColor.DarkRed))
                        {
                            Terminal.Stdout.WriteLine($"[{e.GetType().FullName}] {e.Message}");
                        }

                        using (Terminal.Stdout.WithForeground(ConsoleColor.Red))
                        {
                            Terminal.Stdout.WriteLine(e.StackTrace);
                        }

                        break;
                }

                e = e.InnerException;
            }
        }

        private static void PrintExceptionImpl(CommandLineException e)
        {
            using (Terminal.Stdout.WithForeground(ConsoleColor.Red))
            {
                Terminal.Stdout.WriteLine(e.Message);
            }
        }

        private static void PrintExceptionImpl(Exception e)
        {
            using (Terminal.Stdout.WithColors(ConsoleColor.White, ConsoleColor.DarkRed))
            {
                Terminal.Stdout.WriteLine($"{ErrorText} [{e.GetType().FullName}]");
            }

            using (Terminal.Stdout.WithColors(ConsoleColor.White, ConsoleColor.DarkRed))
            {
                Terminal.Stdout.WriteLine(e.Message);
            }

            using (Terminal.Stdout.WithForeground(ConsoleColor.Red))
            {
                Terminal.Stdout.WriteLine(e.StackTrace);
            }
        }
    }
}
