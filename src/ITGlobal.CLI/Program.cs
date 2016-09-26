using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITGlobal.CommandLine
{
    public class Program
    {
        struct Xyz
        {
            public int X, Y, Z;
        }

        public static void Main(string[] args)
        {
            //  TableDemo();
            //  ProgressBarDemo();
            //    SpinnerDemo();
            CliDemo();
        }

        private static void TableDemo()
        {
            var data = new List<Xyz>();
            for (var x = 0; x <= 1; x++)
                for (var y = 0; y <= 1; y++)
                    for (var z = 0; z <= 1; z++)
                    {
                        data.Add(new Xyz { X = x, Y = y, Z = z });
                    }

            CLI.Table(
                data,
                table =>
                {
                    table.Title("XYZ data");
                    table.Column("X", _ => _.X.ToString(), _ => ConsoleColor.Red);
                    table.Column("Y", _ => _.Y.ToString(), _ => ConsoleColor.Green);
                    table.Column("Z", _ => _.Z.ToString(), _ => ConsoleColor.Blue);
                });
        }


        private static void ProgressBarDemo()
        {
            using (var ctrlC = CLI.CtrlC())
            {
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
        }


        private static void SpinnerDemo()
        {
            using (var ctrlC = CLI.CtrlC())
            {
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
        }

        private static void CliDemo()
        {
            var app = CLI.Parser();

            app.ExecutableName("my-app");
            app.Title("Demo app").Version("1.0.0").HelpText("Demo application for ITG CLI");
            var verbose = app.Switch("v").Alias("verbose").HelpText("Enable vesbose output");
            var help = app.Switch("help").Alias("help").HelpText("Display help");

            // var helpCmd = app.HelpCommand();
            var pullCmd = app.Command("pull").HelpText("Pull something from remote");
            var pullBranchParam = pullCmd.Parameter<string>("b").Alias("branch").DefaultValue("master").HelpText("Branch to pull");
            pullCmd.Callback(_ =>
            {
                Console.WriteLine($"pull -b {pullBranchParam.Value}{(verbose.IsSet?" -v":"")}{(help.IsSet ? " --help" : "")}");

                return 0;
            });

            var pushCmd = app.Command("push").HelpText("Push something into remote");
            var pushRemote = pushCmd.Parameter<string>(0, "remote").Required().HelpText("Remote to push");
            var pushBranch = pushCmd.Parameter<string>(1, "branch").DefaultValue("master").HelpText("Branch to push");
            pushCmd.Callback(_ =>
            {
                Console.WriteLine($"push {pushRemote.Value} {pushBranch.Value} {(verbose.IsSet ? " -v" : "")}{(help.IsSet ? " --help" : "")}");

                return 0;
            });

            //var helpCmd = app.Command("help").HelpText("Get some help");
            //helpCmd.Callback(_ =>
            //{
            //    Console.WriteLine("========================================");
            //    app.Usage().Print();
            //    Console.WriteLine("========================================");
            //    app.Usage("push").Print();
            //    Console.WriteLine("========================================");
            //    app.Usage("pull").Print();
            //    Console.WriteLine("========================================");
            //    app.Usage("help").Print();
            //    return 0;
            //});
            app.HelpCommand();
            
            //app.Run("pull", "-v");
            //app.Run("pull", "-v", "-b", "dev");
            //app.Run("pull", "-v", "-b", "release");
            ////app.Run("push --help");
            //app.Run("push origin dev --help");
            //app.Run("push origin -- dev --help");
            //app.Run("push --help -foobar");
            app.Run("help push");
        }
    }

}

