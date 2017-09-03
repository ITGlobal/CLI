using System;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Console spinner
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