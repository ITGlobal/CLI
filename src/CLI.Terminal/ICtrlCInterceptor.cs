using System;
using System.Threading;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Provides an <see cref="CancellationToken"/> that is triggered on Ctrl+C/SIGINT
    /// </summary>
    [PublicAPI]
    public interface ICtrlCInterceptor : IDisposable
    {
        /// <summary>
        ///     Cancellation token
        /// </summary>
        [PublicAPI]
        CancellationToken CancellationToken { get; }
    }
}