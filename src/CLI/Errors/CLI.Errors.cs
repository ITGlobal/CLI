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
        public static Task<int> HandleErrorsAsync([NotNull] Func<Task> action)
        {
            return HandleErrorsAsync(async () =>
            {
                await action();
                return 0;
            });
        }
#else
        public static Task<int> HandleErrorsAsync([NotNull] Func<Task> action)
        {
            return HandleErrorsAsync(() =>
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
        public static Task<int> HandleErrorsAsync([NotNull] Func<Task<int>> action)
        {
            return action().ContinueWith(task => {
                if(task.IsCanceled)
                {
                    return -1;
                }

                if(task.IsFaulted)
                {
                    var commandLineException = task.Exception.InnerException as CommandLineException;
                    if(commandLineException != null)
                    {
                         PrintExceptionImpl(commandLineException);
                    }
                    else
                    {
                       PrintExceptionImpl(task.Exception.InnerException);
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
            using (WithColors(ConsoleColor.White, ConsoleColor.DarkRed))
            {
                var e = exception;
                while (e != null)
                {
                    if (e != exception)
                    {
                        Console.WriteLine("--- Inner Exception ---");
                    }

                    switch (e)
                    {
                        case CommandLineException ex:
                            Console.WriteLine(ex.Message);
                            break;

                        default:
                            Console.WriteLine($"[{e.GetType().FullName}] {e.Message}");
                            Console.WriteLine(e.StackTrace);
                            break;
                    }

                    e = e.InnerException;
                }
            }
        }

        private static void PrintExceptionImpl(CommandLineException e)
        {
            using (WithForeground(ConsoleColor.Red))
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintExceptionImpl(Exception e)
        {
            using (WithColors(ConsoleColor.White, ConsoleColor.DarkRed))
            {
                Console.WriteLine($"{Text.Error} [{e.GetType().FullName}]");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
