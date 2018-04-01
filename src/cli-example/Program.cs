using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITGlobal.CommandLine.Errors;
using ITGlobal.CommandLine.Parsing;
using ITGlobal.CommandLine.ProgressBars;
using ITGlobal.CommandLine.Spinners;
using ITGlobal.CommandLine.Table;

namespace ITGlobal.CommandLine.Example
{
    public class Program
    {
        private static ISwitch _verbose;
        private static INamedParameter<int> _count;
        private static ISwitch _paged;

        public static int Main(string[] args)
        {
            return TerminalErrorHandler.Handle(() =>
            {
                var app = CLI.Parser();

                app.ExecutableName("cli-example");
                app.HelpText("Demo application for IT Global CLI");

                _verbose = app.Switch("v").Alias("verbose").HelpText("Enable verbose output. This is a global switch");

                var tableCmd = app.Command("table");
                _count = tableCmd.Parameter<int>("n").DefaultValue(2).HelpText("Row count");
                _paged = tableCmd.Switch("p").HelpText("Enable paging");
                tableCmd.HelpText("Run a 'table' demo");
                tableCmd.Handler(_ =>
                {
                    TableDemo();
                    return 0;
                });

                app.Command("progress")
                    .HelpText("Run a 'progressbar' demo")
                    .Handler(_ =>
                    {
                        ProgressBarDemo();
                        return 0;
                    });

                app.Command("spinner")
                    .HelpText("Run a 'spinner' demo")
                    .Handler(_ =>
                    {
                        SpinnerDemo();
                        return 0;
                    });

                app.Command("run")
                    .HelpText("Run an 'unconsumed arguments' demo")
                    .Handler(_ =>
                    {
                        UnconsumedArgumentsDemo(_);
                        return 0;
                    });

                app.Command("simple-parser-help")
                    .HelpText("Run an 'simple parser help' demo")
                    .Handler(_ =>
                    {
                        SimpleParserHelpDemo();
                        return 0;
                    });

                app.Command("tree-parser-help")
                    .HelpText("Run an 'tree parser help' demo")
                    .Handler(_ =>
                    {
                        TreeParserHelpDemo();
                        return 0;
                    });

                app.HelpCommand();
                app.HelpSwitch();

                return app.Parse(args).Run();
            });
        }

        struct Xyz
        {
            public int X, Y, Z;
        }

        private static void TableDemo()
        {
            var n = _count.Value;
            var data = new List<Xyz>();
            for (var x = 0; x <= n; x++)
            {
                data.Add(new Xyz { X = x, Y = x, Z = x });
            }

            var table = TerminalTable.Create(data, _paged.IsSet ? TableRenderer.Paged() : null);

            table.Column("Value of X parameter", _ => _.X.ToString(), _ => ConsoleColor.Red);
            table.Column("Value of Y parameter", _ => _.Y.ToString(), _ => ConsoleColor.Green);
            table.Column("Value of Z parameter", _ => _.Z.ToString(), _ => ConsoleColor.Blue);
            table.Draw();
        }

        private static void ProgressBarDemo()
        {
            using (var ctrlC = Terminal.Current.AttachCtrlCInterceptor())
            {
                ctrlC.CancellationToken.Register(() =>
                {
                    Console.WriteLine("Cancelled!");
                });
                Task.Run(async () =>
                {
                    using (var progressBar = TerminalProgressBar.Create())
                    {
                        var descr = new[] { "preparing", "fetching", "pulling", "pushing" };
                        while (true)
                        {
                            var progress = 0;
                            foreach (var op in descr)
                            {
                                Console.WriteLine("Starting operation {0}...", op);

                                progressBar.SetState(text: op);
                                for (var i = 0; i < 25; i++)
                                {
                                    progress++;
                                    await Task.Delay(50);
                                    progressBar.SetState(progress);

                                    if (ctrlC.CancellationToken.IsCancellationRequested)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }).Wait();
            }
        }

        private static void SpinnerDemo()
        {
            using (var ctrlC = Terminal.Current.AttachCtrlCInterceptor())
            {
                ctrlC.CancellationToken.Register(() =>
                {
                    Console.WriteLine("Cancelled!");
                });
                Task.Run(async () =>
                {
                    using (var spinner = TerminalSpinner.Create())
                    {
                        var descr = new[] { "preparing", "fetching", "pulling", "pushing" };
                        while (true)
                        {
                            var progress = 0;
                            foreach (var op in descr)
                            {
                                Console.WriteLine("Starting operation {0}...", op);

                                spinner.SetTitle(op);
                                for (var i = 0; i < 25; i++)
                                {
                                    progress++;
                                    await Task.Delay(50);

                                    if (ctrlC.CancellationToken.IsCancellationRequested)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }).Wait();
            }
        }

        private static void UnconsumedArgumentsDemo(string[] args)
        {
            Console.WriteLine($"Arguments: [{string.Join(", ", args)}");
        }

        private static void SimpleParserHelpDemo()
        {
            var parser = CliParser.NewSimpleParser();
            parser.Logo(@"

  ___ _____ ____ _       _           _        ____ _     ___ 
 |_ _|_   _/ ___| | ___ | |__   __ _| |      / ___| |   |_ _|
  | |  | || |  _| |/ _ \| '_ \ / _` | |     | |   | |    | | 
  | |  | || |_| | | (_) | |_) | (_| | |  _  | |___| |___ | | 
 |___| |_| \____|_|\___/|_.__/ \__,_|_| (_)  \____|_____|___|
                                                             

");
            parser.Argument("command", 0).HelpText("Command name").Required();
            parser.MultiArgument("args", 1).HelpText("Command arguments");
            parser.Switch("version").HelpText("Print version and exit");
            parser.Option("name").HelpText("Set container name");
            parser.MultiOption('e', "env").HelpText("Set environment variable");
            parser.Parse("--help").Run();
        }

        private static void TreeParserHelpDemo()
        {
            var parser = CliParser.NewTreeParser();
            parser.Logo(@"

  ___ _____ ____ _       _           _        ____ _     ___ 
 |_ _|_   _/ ___| | ___ | |__   __ _| |      / ___| |   |_ _|
  | |  | || |  _| |/ _ \| '_ \ / _` | |     | |   | |    | | 
  | |  | || |_| | | (_) | |_) | (_| | |  _  | |___| |___ | | 
 |___| |_| \____|_|\___/|_.__/ \__,_|_| (_)  \____|_____|___|
                                                             

");
            var hostOption = parser.Option('H')
                .HelpText("Docker daemon hostname")
                .DefaultValueFromEnvironmentVariable("DOCKER_HOST")
                .Required();

            var infoCommand = parser.Command("info")
                .HelpText("Display system-wide information");

            var imageCommand = parser.Command("image")
                .HelpText("Manage images");

            var imageLsCommand = imageCommand.Command("ls")
                .HelpText("List images");

            parser.Parse("image").Run();
        }
    }
}
