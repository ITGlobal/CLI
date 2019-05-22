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

                // colors
                {
                    var cmd = app.Command("colors");
                    cmd.HelpText("Run a 'colors' demo");
                    cmd.OnExecute(_ => { ConsoleColorsDemo.Run(); });
                }

                // table *
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

                // live *
                {
                    var liveCmd = app.Command("live")
                        .HelpText("Run a 'live' demo");
                    
                    {
                        var cmd = liveCmd.Command("progress");
                        cmd.HelpText("Run a 'progress' demo");
                        cmd.OnExecute(_ => { ProgressBarDemo.Run(); });
                    }

                    {
                        var cmd = liveCmd.Command("spinner");
                        cmd.HelpText("Run a 'spinner' demo");
                        cmd.OnExecute(_ => { SpinnerDemo.Run(); });
                    }
                    
                    {
                        var cmd = liveCmd.Command("print");
                        cmd.HelpText("Run a 'live print' demo");
                        cmd.OnExecute(_ => { LiveOutputDemo.Run(); });
                    }
                }

                return app.Parse(args).Run();
            });
        }
    }
}
