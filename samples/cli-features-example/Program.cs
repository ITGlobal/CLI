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
        private static CliOption<int> _count;
        private static CliSwitch _paged;

        public static int Main(string[] args)
        {
            return TerminalErrorHandler.Handle(() =>
            {
                var app = CliParser.NewTreeParser(executableName:"cli-features-example");
                app.HelpText("Demo application for IT Global CLI");
                
                var tableCmd = app.Command("table");
                _count = tableCmd.Option<int>('n', helpText: "Row count").DefaultValue(2);
                _paged = tableCmd.Switch('p', helpText: "Enable paging");
                tableCmd.HelpText("Run a 'table' demo");
                tableCmd.OnExecute(_ =>
                {
                    TableDemo();
                });

                app.Command("progress")
                    .HelpText("Run a 'progressbar' demo")
                    .OnExecute(_ =>
                    {
                        ProgressBarDemo();
                    });

                app.Command("spinner")
                    .HelpText("Run a 'spinner' demo")
                    .OnExecute(_ =>
                    {
                        SpinnerDemo();
                    });
                
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
    }
}
