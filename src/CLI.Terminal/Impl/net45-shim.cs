using System.Threading.Tasks;

namespace ITGlobal.CommandLine.Impl
{
#if NET45

    internal static class TaskExt
    {
        public static System.Threading.Tasks.Task CompletedTask {get; }

        static TaskExt()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.TrySetResult(null);
            CompletedTask = tcs.Task;
        }
    }

#endif
}