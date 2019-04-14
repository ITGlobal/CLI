using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITGlobal.CommandLine.Parsing;
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

        class TableRow
        {
            public TableRow(string id, string image, string created, string status, bool isRunning)
            {
                Id = id;
                Image = image;
                Created = created;
                Status = status;
                IsRunning = isRunning;
            }

            public string Id { get; }
            public string Image { get; }
            public string Created { get; }
            public string Status { get; }
            public bool IsRunning{ get; }
        }

        private static void TableDemo()
        {
            var n = _count.Value;
            var data = new List<TableRow>();
            for (var x = 0; x <= n; x++)
            {
                data.Add(new TableRow(
                    "16ecd05ab21c",
                    "foobar/image:latest",
                    x%3==0?"1 month ago": "2 weeks ago",
                    x % 3 == 1 ? "Up 2 days" : "Exited (0) 2 days ago",
                    x % 3 == 2
                ));
            }

            var table = TerminalTable.Create(data, _paged.IsSet ? TableRenderer.Paged() : null);

            table.Column("ID", _ => _.Id);
            table.Column("Image", _ => _.Image);
            table.Column("Created", _ => _.Created);
            table.Column("Status", _ => _.Status, fg: _ => _.IsRunning ? ConsoleColor.Red : (ConsoleColor?)null);
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
