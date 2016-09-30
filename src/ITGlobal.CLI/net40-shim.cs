#if NET40

using System.Linq;

namespace System.Reflection
{
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