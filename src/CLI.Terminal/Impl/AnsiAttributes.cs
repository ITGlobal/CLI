using System;

namespace ITGlobal.CommandLine.Impl
{
    [Flags]
    internal enum AnsiAttributes
    {
        ATTR_DEFAULT = 0,
        ATTR_BOLD = 1,
        ATTR_UNDERLINE = 4,
        ATTR_NO_UNDERLINE = 24,
        ATTR_NEGATIVE = 7,
        ATTR_NO_NEGATIVE = 27,

        ATTR_FG_BLACK = 30,
        ATTR_FG_RED = 31,
        ATTR_FG_GREEN = 32,
        ATTR_FG_YELLOW = 33,
        ATTR_FG_BLUE = 34,
        ATTR_FG_MAGENTA = 35,
        ATTR_FG_CYAN = 36,
        ATTR_FG_WHITE = 37,
        ATTR_FG_EXT = 38,
        ATTR_FG_DEFAULT = 39,

        ATTR_BG_BLACK = 40,
        ATTR_BG_RED = 41,
        ATTR_BG_GREEN = 42,
        ATTR_BG_YELLOW = 43,
        ATTR_BG_BLUE = 44,
        ATTR_BG_MAGENTA = 45,
        ATTR_BG_CYAN = 46,
        ATTR_BG_WHITE = 47,
        ATTR_BG_EXT = 48,
        ATTR_BG_DEFAULT = 49,

        ATTR_FG_BRIGHT_BLACK = 90,
        ATTR_FG_BRIGHT_RED = 91,
        ATTR_FG_BRIGHT_GREEN = 92,
        ATTR_FG_BRIGHT_YELLOW = 93,
        ATTR_FG_BRIGHT_BLUE = 94,
        ATTR_FG_BRIGHT_MAGENTA = 95,
        ATTR_FG_BRIGHT_CYAN = 96,
        ATTR_FG_BRIGHT_WHITE = 97,

        ATTR_BG_BRIGHT_BLACK = 100,
        ATTR_BG_BRIGHT_RED = 101,
        ATTR_BG_BRIGHT_GREEN = 102,
        ATTR_BG_BRIGHT_YELLOW = 103,
        ATTR_BG_BRIGHT_BLUE = 104,
        ATTR_BG_BRIGHT_MAGENTA = 105,
        ATTR_BG_BRIGHT_CYAN = 106,
        ATTR_BG_BRIGHT_WHITE = 107,
    }
}