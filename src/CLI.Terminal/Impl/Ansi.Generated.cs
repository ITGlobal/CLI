using System;

namespace ITGlobal.CommandLine.Impl
{
    partial class Ansi
    {
        public static AnsiAttributes ForegroundColorToAttributes(ConsoleColor? color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return AnsiAttributes.ATTR_FG_BLACK;
                case ConsoleColor.DarkRed:
                    return AnsiAttributes.ATTR_FG_RED;
                case ConsoleColor.DarkGreen:
                    return AnsiAttributes.ATTR_FG_GREEN;
                case ConsoleColor.DarkYellow:
                    return AnsiAttributes.ATTR_FG_YELLOW;
                case ConsoleColor.DarkBlue:
                    return AnsiAttributes.ATTR_FG_BLUE;
                case ConsoleColor.DarkMagenta:
                    return AnsiAttributes.ATTR_FG_MAGENTA;
                case ConsoleColor.DarkCyan:
                    return AnsiAttributes.ATTR_FG_CYAN;
                case ConsoleColor.DarkGray:
                    return AnsiAttributes.ATTR_FG_WHITE;
                case ConsoleColor.Gray:
                    return AnsiAttributes.ATTR_FG_BRIGHT_BLACK;
                case ConsoleColor.Red:
                    return AnsiAttributes.ATTR_FG_BRIGHT_RED;
                case ConsoleColor.Green:
                    return AnsiAttributes.ATTR_FG_BRIGHT_GREEN;
                case ConsoleColor.Yellow:
                    return AnsiAttributes.ATTR_FG_BRIGHT_YELLOW;
                case ConsoleColor.Blue:
                    return AnsiAttributes.ATTR_FG_BRIGHT_BLUE;
                case ConsoleColor.Magenta:
                    return AnsiAttributes.ATTR_FG_BRIGHT_MAGENTA;
                case ConsoleColor.Cyan:
                    return AnsiAttributes.ATTR_FG_BRIGHT_CYAN;
                case ConsoleColor.White:
                    return AnsiAttributes.ATTR_FG_BRIGHT_WHITE;

                default:
                    return 0;
            }
        }

        public static AnsiAttributes BackgroundColorToAttributes(ConsoleColor? color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return AnsiAttributes.ATTR_BG_BLACK;
                case ConsoleColor.DarkRed:
                    return AnsiAttributes.ATTR_BG_RED;
                case ConsoleColor.DarkGreen:
                    return AnsiAttributes.ATTR_BG_GREEN;
                case ConsoleColor.DarkYellow:
                    return AnsiAttributes.ATTR_BG_YELLOW;
                case ConsoleColor.DarkBlue:
                    return AnsiAttributes.ATTR_BG_BLUE;
                case ConsoleColor.DarkMagenta:
                    return AnsiAttributes.ATTR_BG_MAGENTA;
                case ConsoleColor.DarkCyan:
                    return AnsiAttributes.ATTR_BG_CYAN;
                case ConsoleColor.DarkGray:
                    return AnsiAttributes.ATTR_BG_WHITE;
                case ConsoleColor.Gray:
                    return AnsiAttributes.ATTR_BG_BRIGHT_BLACK;
                case ConsoleColor.Red:
                    return AnsiAttributes.ATTR_BG_BRIGHT_RED;
                case ConsoleColor.Green:
                    return AnsiAttributes.ATTR_BG_BRIGHT_GREEN;
                case ConsoleColor.Yellow:
                    return AnsiAttributes.ATTR_BG_BRIGHT_YELLOW;
                case ConsoleColor.Blue:
                    return AnsiAttributes.ATTR_BG_BRIGHT_BLUE;
                case ConsoleColor.Magenta:
                    return AnsiAttributes.ATTR_BG_BRIGHT_MAGENTA;
                case ConsoleColor.Cyan:
                    return AnsiAttributes.ATTR_BG_BRIGHT_CYAN;
                case ConsoleColor.White:
                    return AnsiAttributes.ATTR_BG_BRIGHT_WHITE;

                default:
                    return 0;
            }
        }

        public static ConsoleColor? ForegroundColorFromAttributes(AnsiAttributes attributes)
        {
            switch(attributes)
            {
                case AnsiAttributes.ATTR_FG_BLACK:
                    return ConsoleColor.Black;
                case AnsiAttributes.ATTR_FG_RED:
                    return ConsoleColor.DarkRed;
                case AnsiAttributes.ATTR_FG_GREEN:
                    return ConsoleColor.DarkGreen;
                case AnsiAttributes.ATTR_FG_YELLOW:
                    return ConsoleColor.DarkYellow;
                case AnsiAttributes.ATTR_FG_BLUE:
                    return ConsoleColor.DarkBlue;
                case AnsiAttributes.ATTR_FG_MAGENTA:
                    return ConsoleColor.DarkMagenta;
                case AnsiAttributes.ATTR_FG_CYAN:
                    return ConsoleColor.DarkCyan;
                case AnsiAttributes.ATTR_FG_WHITE:
                    return ConsoleColor.DarkGray;
                case AnsiAttributes.ATTR_FG_BRIGHT_BLACK:
                    return ConsoleColor.Gray;
                case AnsiAttributes.ATTR_FG_BRIGHT_RED:
                    return ConsoleColor.Red;
                case AnsiAttributes.ATTR_FG_BRIGHT_GREEN:
                    return ConsoleColor.Green;
                case AnsiAttributes.ATTR_FG_BRIGHT_YELLOW:
                    return ConsoleColor.Yellow;
                case AnsiAttributes.ATTR_FG_BRIGHT_BLUE:
                    return ConsoleColor.Blue;
                case AnsiAttributes.ATTR_FG_BRIGHT_MAGENTA:
                    return ConsoleColor.Magenta;
                case AnsiAttributes.ATTR_FG_BRIGHT_CYAN:
                    return ConsoleColor.Cyan;
                case AnsiAttributes.ATTR_FG_BRIGHT_WHITE:
                    return ConsoleColor.White;

                default:
                    return null;
            }
        }

        public static ConsoleColor? BackgroundColorFromAttributes(AnsiAttributes attributes)
        {
            switch(attributes)
            {
                case AnsiAttributes.ATTR_BG_BLACK:
                    return ConsoleColor.Black;
                case AnsiAttributes.ATTR_BG_RED:
                    return ConsoleColor.DarkRed;
                case AnsiAttributes.ATTR_BG_GREEN:
                    return ConsoleColor.DarkGreen;
                case AnsiAttributes.ATTR_BG_YELLOW:
                    return ConsoleColor.DarkYellow;
                case AnsiAttributes.ATTR_BG_BLUE:
                    return ConsoleColor.DarkBlue;
                case AnsiAttributes.ATTR_BG_MAGENTA:
                    return ConsoleColor.DarkMagenta;
                case AnsiAttributes.ATTR_BG_CYAN:
                    return ConsoleColor.DarkCyan;
                case AnsiAttributes.ATTR_BG_WHITE:
                    return ConsoleColor.DarkGray;
                case AnsiAttributes.ATTR_BG_BRIGHT_BLACK:
                    return ConsoleColor.Gray;
                case AnsiAttributes.ATTR_BG_BRIGHT_RED:
                    return ConsoleColor.Red;
                case AnsiAttributes.ATTR_BG_BRIGHT_GREEN:
                    return ConsoleColor.Green;
                case AnsiAttributes.ATTR_BG_BRIGHT_YELLOW:
                    return ConsoleColor.Yellow;
                case AnsiAttributes.ATTR_BG_BRIGHT_BLUE:
                    return ConsoleColor.Blue;
                case AnsiAttributes.ATTR_BG_BRIGHT_MAGENTA:
                    return ConsoleColor.Magenta;
                case AnsiAttributes.ATTR_BG_BRIGHT_CYAN:
                    return ConsoleColor.Cyan;
                case AnsiAttributes.ATTR_BG_BRIGHT_WHITE:
                    return ConsoleColor.White;

                default:
                    return null;
            }
        }
    }
}