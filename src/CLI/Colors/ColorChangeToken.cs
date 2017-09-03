using System;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class ColorChangeToken : IDisposable
    {
        private readonly ConsoleColor _originalForeground;
        private readonly ConsoleColor _originalBackground;

        public ColorChangeToken(ConsoleColor? fg, ConsoleColor? bg)
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