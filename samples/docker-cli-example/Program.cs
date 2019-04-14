using System;
using System.IO;
using ITGlobal.CommandLine.Parsing;

namespace ITGlobal.CommandLine.Example
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var parser = CliParser.NewTreeParser(
                executableName: "docker-cli-example",
                helpText: "An example that implements some docker CLI commands with ITGlobal.CLI"
            );

            // Global options
            // -D, --debug              Enable debug mode
            var debugSwitch = parser.Switch('D', "debug", helpText: "Enable debug mode");

            // -H, --host list          Daemon socket(s) to connect to
            //                          Defaults $DOCKER_HOST or to unix://var/run/docker.sock
            var hostsOption = parser.RepeatableOption<string>('H', "host", helpText: "Daemon socket(s) to connect to")
                .FromEnvironmentVariable("DOCKER_HOST")
                .DefaultValue("unix://var/run/docker.sock");
            
            // -l, --log-level string   Set the logging level
            //                          ("debug" | "info" | "warn" | "error" | "fatal")
            var logLevelOption = parser.Option<LogLevel>('l', "log-level", helpText: "Set the logging level");

            // -v, --version            Print version information and quit
            var versionSwitch = parser.Switch('v', "version", helpText: "Print version information and quit");
            parser.BeforeExecute(ctx =>
            {
                if (versionSwitch)
                {
                    Terminal.Stdout.WriteLine("Version: 1.0.0");
                    ctx.Break(0);
                }
            });


            // docker info command
            {
                var infoCommand = parser.Command("info", helpText: "Display system-wide information");
                infoCommand.OnExecute(_ =>
                {
                    Terminal.Stdout.WriteLine("\"info\" command has been triggered");
                    Terminal.Stdout.WriteLine($"Global options:");
                    Terminal.Stdout.WriteLine($"  debugSwitch:    {debugSwitch.IsSet}");
                    Terminal.Stdout.WriteLine($"  hostsOption:    {string.Join(", ", hostsOption.Values)}");
                    Terminal.Stdout.WriteLine($"  logLevelOption: {logLevelOption.Value}");
                });
            }

            // docker image * command set
            {
                var imageCommands = parser.Command("image", helpText: "Manage images");

                // docker image build command
                {
                    var imageBuildCommand = imageCommands.Command("build", helpText: "Build an image from a Dockerfile");
                    var fileOption = imageBuildCommand
                        .Option<string>('f', "file", helpText: "Name of the Dockerfile")
                        .DefaultValue("./Dockerfile");
                    var tagsOption = imageBuildCommand
                        .RepeatableOption<string>('t', "tags", "Name and optionally a tag in the 'name:tag' format");
                    var labelsOption = imageBuildCommand
                        .RepeatableOption<string>("label", "Set metadata for an image");
                    var quietSwitch = imageBuildCommand
                        .Switch('q', "quiet", helpText: "Suppress the build output and print image ID on success");
                    var buildContextOption = imageBuildCommand
                        .Argument<string>("path", helpText: "Build context path")
                        .Validate(ValidateDirectoryPath) // This parameter must contains a path to an existing directory
                        .Required(); // NOTE this parameter is required

                    imageBuildCommand.OnExecute(_ =>
                    {
                        Terminal.Stdout.WriteLine("\"image build\" command has been triggered");
                        Terminal.Stdout.WriteLine($"Global options:");
                        Terminal.Stdout.WriteLine($"  debugSwitch:        {debugSwitch.IsSet}");
                        Terminal.Stdout.WriteLine($"  hostsOption:        {string.Join(", ", hostsOption.Values)}");
                        Terminal.Stdout.WriteLine($"  logLevelOption:     {logLevelOption.Value}");
                        Terminal.Stdout.WriteLine($"Command options:");
                        Terminal.Stdout.WriteLine($"  fileOption:         {fileOption.Value}");
                        Terminal.Stdout.WriteLine($"  tagsOption:         {string.Join(", ", tagsOption.Values)}");
                        Terminal.Stdout.WriteLine($"  labelsOption:       {string.Join(", ", labelsOption.Values)}");
                        Terminal.Stdout.WriteLine($"  quietSwitch:        {quietSwitch.IsSet}");
                        Terminal.Stdout.WriteLine($"  buildContextOption: {buildContextOption.Value}");
                    });
                }

                // docker image ls command
                {
                    var imageLsCommand = imageCommands.Command("ls", helpText: "List images");
                    imageLsCommand.OnExecute(_ =>
                    {
                        Terminal.Stdout.WriteLine("\"image ls\" command has been triggered");
                    });
                }
            }


            return parser.Parse(args).Run();
        }

        static string ValidateDirectoryPath(string value, bool isSet)
        {
            if (!isSet)
            {
                return null;
            }

            if (Directory.Exists(value))
            {
                return null;
            }

            return $"Directory \"{value}\" doesn't exist";
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}
