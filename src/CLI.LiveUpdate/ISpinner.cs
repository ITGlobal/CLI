using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal spinner
    /// </summary>
    [PublicAPI]
    public interface ISpinner : IDisposable
    {
        /// <summary>
        ///     Updates spinner text
        /// </summary>
        /// <param name="title">
        ///     Spinner text
        /// </param>
        [PublicAPI]
        void SetTitle([NotNull] string title);
    }
}