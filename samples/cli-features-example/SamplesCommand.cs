using System;
using ITGlobal.CommandLine.Parsing;

namespace ITGlobal.CommandLine.Example
{
    public static class SamplesCommand
    {
        public static void Setup(ICliCommandRoot app)
        {
            // sample *
            {
                var command = app.Command("sample")
                    .HelpText("Various samples");

                // sample nested-ansi
                {
                    var cmd = command.Command("nested-ansi", helpText: "Test for https://github.com/ITGlobal/CLI/issues/18");
                    cmd.OnExecute(_ => { NestedAnsiOutput(); });
                }
            }
        }

        private static void NestedAnsiOutput()
        {
            Console.WriteLine("Normal demo");
            Console.WriteLine();
            Console.WriteLine("(Default colors)");
            Console.WriteLine($"Cyan            {"Green      ".Green()}       Cyan".Cyan());
            Console.WriteLine("(Default colors)");
            Console.WriteLine($"DarkCyanOnWhite {"BlackOnCyan".BlackOnCyan()} DarkCyanOnWhite".DarkCyanOnWhite());
            Console.WriteLine("(Default colors)");
            Console.WriteLine($"OnDarkRed       {"OnDarkBlue ".OnDarkBlue()}  OnDarkRed".OnDarkRed());
            Console.WriteLine("(Default colors)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Locked terminal demo");
            Console.WriteLine();
            using (LiveOutputManager.Create())
            {
                Console.WriteLine("(Default colors)");
                Console.WriteLine($"Cyan            {"Green      ".Green()}       Cyan".Cyan());
                Console.WriteLine("(Default colors)");
                Console.WriteLine($"DarkCyanOnWhite {"BlackOnCyan".BlackOnCyan()} DarkCyanOnWhite".DarkCyanOnWhite());
                Console.WriteLine("(Default colors)");
                Console.WriteLine($"OnDarkRed       {"OnDarkBlue ".OnDarkBlue()}  OnDarkRed".OnDarkRed());
                Console.WriteLine("(Default colors)");
            }
        }
    }
}
