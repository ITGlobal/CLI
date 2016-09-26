using System;
using System.Threading;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Provides an <see cref="CancellationToken"/> that is triggered on Ctrl+C
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