using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ITGlobal.CommandLine.Impl;
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

                // sample long-text
                {
                    var cmd = command.Command("long-text", helpText: "Test long text wrapping/clipping");
                    cmd.OnExecute(_ => { LongTextWrapping(); });
                }

                // sample win32-buffer-scroll
                {
                    var cmd = command.Command("win32-buffer-scroll", helpText: "Test Win32 buffer scrolling");
                    cmd.OnExecute(_ => { Win32BufferScroll(); });
                }

                // sample unicode
                {
                    var cmd = command.Command("unicode", helpText: "Test Win32 unicode output");
                    cmd.OnExecute(_ => { Unicode(); });
                }

                // sample concurrent
                {
                    var cmd = command.Command("concurrent", helpText: "Test interleaved writes both to stdout and stderr");
                    cmd.OnExecute(_ => { ConcurrentWriteToStdErrAndStdOut(); });
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

        private static void LongTextWrapping()
        {
            const string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, \n" +
                                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
                                "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia " +
                                "deserunt mollit anim id est laborum.";


            // First try to write a long text into terminal using direct access to ITerminalWriter
            Terminal.Stdout.Write("............");
            var str = AnsiString.Create(text);
            var chunks = str.SplitIntoChunks();
            foreach (var c in chunks)
            {
                Terminal.Stdout.Write(c);
            }
            Terminal.Stdout.WriteLine();

            // Then try again using a Console class
            Console.Out.WriteLine();
            Console.Out.Write("............");
            Console.Out.WriteLine(text);
        }

        private static void Win32BufferScroll()
        {
            // First, try to resize console buffer
            var hConsole = Win32.GetStdHandle(Win32.STD_OUTPUT_HANDLE);
            if (!Win32.GetConsoleScreenBufferInfo(hConsole, out var bufferInfo))
            {
                throw new Win32Exception();
            }

            var dwSize = new Win32.COORD
            {
                X = bufferInfo.dwMaximumWindowSize.X,
                Y = bufferInfo.dwMaximumWindowSize.Y,
            };
            if (!Win32.SetConsoleScreenBufferSize(hConsole, dwSize))
            {
                throw new Win32Exception();
            }

            Console.WriteLine($"// Will print {dwSize.Y + 10} lines");
            Console.WriteLine($"// Press <Enter> to continue");
            Console.ReadLine();

            // Then, print enough lines to fill console buffer to make it scroll
            var i = 0;
            foreach (var c in EnumerateChars().Take(dwSize.Y + 10))
            {
                var str = new string(c, 24);

                Console.Out.Write($"#{i + 1,4} ");
                Console.Out.WriteLine(str);
                i++;
            }

            static IEnumerable<char> EnumerateChars()
            {
                while (true)
                {
                    for (var c = '0'; c < '9'; c++)
                    {
                        yield return c;
                    }

                    for (var c = 'A'; c < 'Z'; c++)
                    {
                        yield return c;
                    }
                }
            }
        }

        private static void Unicode()
        {
            const string text = "Lorem ipsum dolor sit amet, id eum impedit suavitate, iriure\n" + // latin
                                "Лорем ипсум долор сит амет, цу про утинам лабитур персеяуерис\n" + // cyrrilic translit
                                "गटकउसि विभाजन किएलोग जनित सक्षम संपुर्ण केन्द्रित प्राधिकरन पहोच। जनित\n" + // hindi
                                "غير الدمج بوابة الشمال كل. سقطت لمحاكم البشريةً دنو مع"; // arabic

            Console.Out.WriteLine(text);
        }

        private static void ConcurrentWriteToStdErrAndStdOut()
        {
            const string foo = "foo";
            const string bar = "bar";

            const int count = 100;

            for (var i = 0; i < count; i++)
            {
                Console.Out.Write(foo);
                Console.Error.Write(bar);
                Console.Out.WriteLine();
            }

            Console.Error.Flush();
            Console.Out.Flush();
        }
    }
}
