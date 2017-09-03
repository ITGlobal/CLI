using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Creates a progress bar
        /// </summary>
        /// <returns>
        ///     A console process bar object
        /// </returns>
        [PublicAPI, NotNull]
        public static IProgressBar ProgressBar()
            => new ProgressBar(ProgressBarStyle.Default);

        /// <summary>
        ///     Creates a progress bar
        /// </summary>
        /// <param name="style">
        ///     Progress bar style
        /// </param>
        /// <returns>
        ///     A console process bar object
        /// </returns>
        [PublicAPI, NotNull]
        public static IProgressBar ProgressBar([NotNull] ProgressBarStyle style)
            => new ProgressBar(style);
        
    }
}
