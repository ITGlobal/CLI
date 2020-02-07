using System;
using ITGlobal.CommandLine.Parsing;
using ITGlobal.CommandLine.Table;

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

                // sample info
                {
                    var cmd = command.Command("info", helpText: "Test for https://github.com/ITGlobal/CLI/issues/17");
                    cmd.OnExecute(_ => { Info(); });
                }

                // sample streams
                {
                    var cmd = command.Command("streams", helpText: "Test output into StdErr/StdOut");
                    cmd.OnExecute(_ => { Streams(); });
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

        private static void Info()
        {
            var t = Terminal.GetImplementation();
            Console.WriteLine($"Driver:                 {t.DriverName}");
            Console.WriteLine($"WindowWidth (Driver):   {t.WindowWidth}");
            Console.WriteLine($"WindowWidth (Terminal): {Terminal.WindowWidth}");
            Console.WriteLine($"DefaultForegroundColor: {Terminal.DefaultForegroundColor}");
            Console.WriteLine($"DefaultBackgroundColor: {Terminal.DefaultBackgroundColor}");
        }

        private static void Streams()
        {
            Console.Out.WriteLine($"Write to StdOut");
            Console.Out.WriteLine($"Write to StdOut (colored)".Cyan());
            Console.Error.WriteLine($"Write to StdErr");
            Console.Error.WriteLine($"Write to StdErr (colored)".Cyan());
        }
    }
}
