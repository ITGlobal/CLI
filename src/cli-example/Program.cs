using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ITGlobal.CommandLine.Example
{
    public class Program
    {
        private static ISwitch _verbose;
        private static INamedParameter<int> _count;
        private static ISwitch _paged;

        public static int Main(string[] args)
        {            
            return CLI.HandleErrors(() =>
            {
                var app = CLI.Parser();

                app.ExecutableName("cli-example");
                app.FromAssembly(typeof(Program).GetTypeInfo().Assembly);
                app.HelpText("Demo application for IT Global CLI");
                
                _verbose = app.Switch("v").Alias("verbose").HelpText("Enable vesbose output. This is a global switch");

                var tableCmd = app.Command("table");
                _count = tableCmd.Parameter<int>("n").DefaultValue(2).HelpText("Row count");
                _paged = tableCmd.Switch("p").HelpText("Enable paging");
                tableCmd.HelpText("Run a 'table' demo");
                tableCmd.Handler(TableDemo);

                app.Command("progress")
                    .HelpText("Run a 'progressbar' demo")
                    .Handler(ProgressBarDemo);

                app.Command("spinner")
                    .HelpText("Run a 'spinner' demo")
                    .Handler(SpinnerDemo);

                app.Command("run")
                    .HelpText("Run an 'unconsumed arguments' demo")
                    .Handler(UnconsumedArgumentsDemo);

                app.HelpCommand();

                return app.Parse(args).Run();
            });
        }        

        struct Xyz
        {
            public int X, Y, Z;
        }

        private static int TableDemo(string[] args)
        {            
            var n = _count.Value;
            var data = new List<Xyz>();
            for (var x = 0; x <= n; x++)
            {
                data.Add(new Xyz {X = x, Y = x, Z = x});
            }

            CLI.Table(
                data,
                table =>
                {
                    table.Title("XYZ data");
                    table.EnablePaging(_paged.IsSet);
                    table.Column("Value of X parameter", _ => _.X.ToString(), _ => ConsoleColor.Red);
                    table.Column("Value of Y parameter", _ => _.Y.ToString(), _ => ConsoleColor.Green);
                    table.Column("Value of Z parameter", _ => _.Z.ToString(), _ => ConsoleColor.Blue);
                });

            return 0;
        }

        private static int ProgressBarDemo(string[] args)
        {
            using (var ctrlC = CLI.CtrlC())
            {                
                ctrlC.CancellationToken.Register(() =>
                {
                    Console.WriteLine("Cancelled!");
                });
                Task.Run(async () =>
                {
                    using (var progressBar = CLI.ProgressBar())
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

            return 0;
        }

        private static int SpinnerDemo(string[] args)
        {
            using (var ctrlC = CLI.CtrlC())
            {
                ctrlC.CancellationToken.Register(() =>
                {
                    Console.WriteLine("Cancelled!");
                });
                Task.Run(async () =>
                {
                    using (var spinner = CLI.Spinner(""))
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

            return 0;
        }

        private static int UnconsumedArgumentsDemo(string[] args)
        {
            return 0;
        }
    }
}
