using System;

namespace ITGlobal.CommandLine.Impl
{
    internal interface IAnsiCommandHandler
    {
        void SetForegroundColor(ConsoleColor color);

        void SetBackgroundColor(ConsoleColor color);
        void SetColors(ConsoleColor foreground, ConsoleColor background);

        void ResetColors();

        void Write(char c);
    }
}