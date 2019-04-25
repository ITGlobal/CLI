using ITGlobal.CommandLine.Parsing;

namespace ITGlobal.CommandLine.Example
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return TerminalErrorHandler.Handle(() =>
            {
                Terminal.Initialize();
                
                var app = CliParser.NewTreeParser(executableName: "cli-features-example");
                app.HelpText("Demo application for IT Global CLI");

                {
                    var cmd = app.Command("colors");
                    cmd.HelpText("Run a 'colors' demo");
                    cmd.OnExecute(_ => { ConsoleColorsDemo.Run(); });
                }

                {
                    var cmd = app.Command("table");
                    cmd.HelpText("Run a 'table' demo");
                    var n = cmd.Option<int>('n', helpText: "Row count").DefaultValue(2);
                    var paged = cmd.Switch('p', helpText: "Enable paging");
                    cmd.HelpText("Run a 'table' demo");
                    cmd.OnExecute(_ => { TableDemo.Run(paged, n); });
                }

                {
                    var cmd = app.Command("progress");
                    cmd.HelpText("Run a 'progressbar' demo");
                    cmd.OnExecute(_ => { ProgressBarDemo.Run(); });
                }

                {
                    var cmd = app.Command("spinner");
                    cmd.HelpText("Run a 'spinner' demo");
                    cmd.OnExecute(_ => { SpinnerDemo.Run(); });
                }


                {
                    var cmd = app.Command("liveoutput");
                    cmd.HelpText("Run a 'liveoutput' demo");
                    cmd.OnExecute(_ => { LiveOutputDemo.Run(); });
                }

                return app.Parse(args).Run();
            });
        }
    }
}
