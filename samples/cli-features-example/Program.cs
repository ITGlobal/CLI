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

                // nested-colors
                {
                    var cmd = app.Command("nested-colors");
                    cmd.HelpText("Run a 'nested-colors' demo");
                    cmd.OnExecute(_ => { ConsoleNestedColorsDemo.Run(); });
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
                        var type = cmd.Option<ProgressBarDemo.Type>('t', "type")
                            .HelpText("Progress bar type")
                            .DefaultValue(ProgressBarDemo.Type.Arrow);
                        var wipe = cmd.Switch('w', "wipe")
                            .HelpText("Wipe out progress bar from screen when completed");
                        cmd.OnExecute(_ => { ProgressBarDemo.Run(type, wipe); });
                    }

                    
                    {
                        var cmd = liveCmd.Command("progress-complex");
                        cmd.HelpText("Run a 'progress-complex' demo");
                        var type = cmd.Option<ComplexProgressBarDemo.Type>('t', "type")
                            .HelpText("Progress bar type")
                            .DefaultValue(ComplexProgressBarDemo.Type.Arrow);
                        var wipe = cmd.Switch('w', "wipe")
                            .HelpText("Wipe out progress bar from screen when completed");
                        cmd.OnExecute(_ => { ComplexProgressBarDemo.Run(type, wipe); });
                    }

                    {
                        var cmd = liveCmd.Command("spinner");
                        cmd.HelpText("Run a 'spinner' demo");
                        var type = cmd.Option<SpinnerDemo.Type>('t', "type")
                            .HelpText("Spinner type")
                            .DefaultValue(SpinnerDemo.Type.RotatingBar);
                        cmd.OnExecute(_ => { SpinnerDemo.Run(type); });
                    }
                    
                    {
                        var cmd = liveCmd.Command("print");
                        cmd.HelpText("Run a 'live print' demo");
                        cmd.OnExecute(_ => { LiveOutputDemo.Run(); });
                    }
                    
                    {
                        var cmd = liveCmd.Command("print-complex");
                        cmd.HelpText("Run a 'live print-complex' demo");
                        cmd.OnExecute(_ => { ComplexLiveOutputDemo.Run(); });
                    }
                }

                // sample *
                SamplesCommand.Setup(app);

                return app.Parse(args).Run();
            });
        }
    }
}
