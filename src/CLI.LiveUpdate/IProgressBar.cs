using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Terminal progress bar
    /// </summary>
    [PublicAPI]
    public interface IProgressBar : IDisposable
    {
        /// <summary>
        ///     Updates process bar state
        /// </summary>
        /// <param name="progress">
        ///     Process value (in percent). Valid range is from 0 to 100.
        /// </param>
        /// <param name="text">
        ///     Text description. Will be trimmed if longer than <see cref="Consts.PROGRESS_BAR_LABEL_WIDTH"/>.
        /// </param>
        [PublicAPI]
        void SetState(int? progress = null, string text = null);
    }
}