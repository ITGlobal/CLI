#if NET40

namespace System.Reflection
{
    using System.Linq;

    internal static class AssemblyExt
    {
        public static T GetCustomAttribute<T>(this Assembly assembly)
            where T : Attribute
        {
            return assembly
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .FirstOrDefault();
        }
    }
}

#endif

#if NET40 || NET45

namespace System.Threading.Tasks
{
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
}

#endif