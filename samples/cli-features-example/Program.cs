using ITGlobal.CommandLine.Parsing;
using ITGlobal.CommandLine.Table;

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
                    var tableCmd = app.Command("table")
                        .HelpText("Run a 'table' demo");

                    {
                        var cmd = tableCmd.Command("fluent", helpText: "Run a 'fluent table' demo");
                        cmd.OnExecute(_ => { FluentTableDemo.Run(); });
                    }

                    {
                        var cmd = tableCmd.Command("generated", helpText: "Run a 'generated table' demo");
                        var n = cmd.Option<int>('n', helpText: "Row count").DefaultValue(10);
                        cmd.OnExecute(_ => { GeneratedTableDemo.Run(n); });
                    }
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
