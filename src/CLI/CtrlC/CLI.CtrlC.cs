using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Temporarily intercets Ctrl+C key press to trigger a <see cref="System.Threading.CancellationToken"/>
        /// </summary>
        /// <returns>
        ///     A Ctrl+C interceptor object
        /// </returns>
        [PublicAPI, NotNull]
        public static ICtrlCInterceptor CtrlC() => new CtrlCInterceptor();
    }
}
