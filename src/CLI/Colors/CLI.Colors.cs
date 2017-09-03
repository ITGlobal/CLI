using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CLI
    {
        /// <summary>
        ///     Temporarily changes console foreground and/or background colors
        /// </summary>
        /// <param name="fg">
        ///     Foreground color
        /// </param>
        /// <param name="bg">
        ///     Background color
        /// </param>
        /// <returns>
        ///     Disposable token to restore original colors
        /// </returns>
        [PublicAPI, NotNull]
        public static IDisposable WithColors(ConsoleColor? fg, ConsoleColor? bg) => new ColorChangeToken(fg, bg);

        /// <summary>
        ///     Temporarily changes console foreground color
        /// </summary>
        /// <param name="color">
        ///     Foreground color
        /// </param>
        /// <returns>
        ///     Disposable token to restore original colors
        /// </returns>
        [PublicAPI, NotNull]
        public static IDisposable WithForeground(ConsoleColor color) => WithColors(color, null);

        /// <summary>
        ///     Temporarily changes console background color
        /// </summary>
        /// <param name="color">
        ///     Background color
        /// </param>
        /// <returns>
        ///     Disposable token to restore original colors
        /// </returns>
        [PublicAPI, NotNull]
        public static IDisposable WithBackground(ConsoleColor color) => WithColors(null, color);
    }
}
