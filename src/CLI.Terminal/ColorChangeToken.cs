using System;
using JetBrains.Annotations;

namespace ITGlobal.CommandLine
{
    /// <summary>
    ///     Default color change disposable token
    /// </summary>
    [PublicAPI]
    public struct ColorChangeToken : IDisposable
    {
        private readonly ConsoleColor _originalForeground;
        private readonly ConsoleColor _originalBackground;

        internal ColorChangeToken(ConsoleColor? fg, ConsoleColor? bg)
        {
            _originalForeground = Console.ForegroundColor;
            _originalBackground = Console.BackgroundColor;

            if (fg != null)
            {
                Console.ForegroundColor = fg.Value;
            }

            if (bg != null)
            {
                Console.BackgroundColor = bg.Value;
            }
        }

        public void Dispose()
        {
            Console.ForegroundColor = _originalForeground;
            Console.BackgroundColor = _originalBackground;
        }
    }
}