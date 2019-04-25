using System;
using System.Threading.Tasks;

namespace ITGlobal.CommandLine.Example
{
    public static class SpinnerDemo
    {
        public static void Run()
        {
            using (var ctrlC = Terminal.OnCtrlC())
            {
                ctrlC.CancellationToken.Register(() =>
                {
                    Terminal.Stderr.WriteLine((ColoredString)"Cancelled!");
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
                                Terminal.Stderr.WriteLine($"Starting operation {op}...");

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