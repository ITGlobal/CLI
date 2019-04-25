using System;
using System.Linq;

namespace ITGlobal.CommandLine.Example
{
    public static class ConsoleColorsDemo
    {
        public static void Run()
        {
            foreach (var fg in Colors)
            {
                Console.WriteLine($"{fg} text on default background:\t{"Text".Fg(fg)}");
            }

            foreach (var bg in Colors)
            {
                Console.WriteLine($"Default text on {bg} background:\t{"Text".Bg(bg)}");
            }

            Console.Write($"{"".PadRight(12)} ");
            foreach (var fg in Colors)
            {
                Console.Write($"{$"{fg}".PadRight(12)} ");
            }
            Console.WriteLine();


            foreach (var bg in Colors)
            {
                Console.Write($"{$"{bg}".PadRight(12)} ");
                foreach (var fg in Colors)
                {
                    Console.Write($"{"TEXT".PadRight(12).Colored(fg, bg)} ");
                }
                Console.WriteLine();
            }
        }

        private static ConsoleColor[] Colors { get; } =
            Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().ToArray();
    }
}