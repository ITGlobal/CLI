using System;
using System.Reflection;

namespace ITGlobal.CommandLine.GitExample
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var app = CLI.Parser()
                .Title("my-git")
                .ExecutableName("my-git")
                .Version("1.0.0")
                .HelpText("git wannabe");
            
            // Global '--version' switch
            var versionSwitch = app.Switch("version").HelpText("Print app version and exit");
            app.Hook(() =>
            {
                if (versionSwitch.IsSet)
                {
                    var version = typeof(CLI).GetTypeInfo().Assembly
                        .GetCustomAttribute<AssemblyFileVersionAttribute>()
                        .Version;
                    Console.WriteLine($"my-git version {version}");
                    return 0;
                }

                return null;
            });

            // 'clone' command
            CloneCommand(app);

            // 'init' command
            InitCommand(app);

            // 'add' command
            AddCommand(app);

            // 'reset' command
            ResetCommand(app);

            // 'pull' command
            PullCommand(app);

            // 'push' command
            PushCommand(app);

            // 'commit' command
            CommitCommand(app);

            // An auto-generated '--help' switch
            app.HelpSwitch();

            // Parse command line and execute command
            return CLI.HandleErrors(() => app.Parse(args).Run());
        }

        private static void CloneCommand(ICommandParser app)
        {
            var command = app.Command("clone");
            command.HelpText("Clone a repository into a new directory");

            var repositoryParameter = command.Parameter<string>(0, "repository")
                .HelpText("The (possibly remote) repository to clone from")
                .Required();

            var directoryParameter = command.Parameter<string>(1, "directory")
                .HelpText("The name of a new directory to clone into");

            var branchParameter = command.Parameter<string>("b")
                .Alias("branch")
                .HelpText("The name of a branch to checkout");

            command.Handler(_ =>
            {
                Console.WriteLine($"command:    clone");
                Console.WriteLine($"repository: {repositoryParameter.Value}");
                Console.WriteLine($"directory:  {(directoryParameter.IsSet ? directoryParameter.Value : "-")}");
                Console.WriteLine($"branch:     {(branchParameter.IsSet ? branchParameter.Value : "-")}");

                return 0;
            });
        }

        private static void InitCommand(ICommandParser app)
        {
            var command = app.Command("init")
                .HelpText("Create an empty Git repository or reinitialize an existing one");

            var quietSwitch = command.Switch("q")
                .Alias("quiet")
                .HelpText("Only print error and warning messages; all other output will be suppressed.");

            var bareSwitch = command.Switch("bare")
                .HelpText("Create a bare repository");

            var directoryParameter = command.Parameter<string>(0, "directory")
                .HelpText("The name of a directory");

            command.Handler(_ =>
            {
                Console.WriteLine($"command:   init");
                Console.WriteLine($"quiet:     {(quietSwitch.IsSet ? "Y" : "N")}");
                Console.WriteLine($"bare:      {(bareSwitch.IsSet ? "Y" : "N")}");
                Console.WriteLine($"directory: {(directoryParameter.IsSet ? directoryParameter.Value : "-")}");

                return 0;
            });
        }

        private static void AddCommand(ICommandParser app)
        {
            var command = app.Command("add")
                   .HelpText("Add file contents to the index");

            var verboseSwitch = command.Switch("v")
                .Alias("verbose")
                .HelpText("Only print error and warning messages; all other output will be suppressed.");

            var pathspecParameter = command.Parameter<string>(0, "pathspec")
                .Required()
                .HelpText("Files to add content from");

            command.Handler(_ =>
            {
                Console.WriteLine($"command:  add");
                Console.WriteLine($"verbose:  {(verboseSwitch.IsSet ? "Y" : "N")}");
                Console.WriteLine($"pathspec: {pathspecParameter.Value}");

                return 0;
            });
        }

        private static void ResetCommand(ICommandParser app)
        {
            var command = app.Command("reset")
                  .HelpText("Reset current HEAD to the specified state");

            var softSwitch = command.Switch("soft")
                .HelpText("Does not touch the index file or the working tree at all");
            var hardSwitch = command.Switch("hard")
                .HelpText("Resets the index and working tree");

            var commitParameter = command.Parameter<string>(0, "commit")
                .Required()
                .HelpText("Commit to reset to");

            command.Handler(_ =>
            {
                if (!(softSwitch.IsSet ^ hardSwitch.IsSet))
                {
                    throw new CommandLineValidationException(new[] { "Specify exactly one of switches: --soft, --hard" });
                }

                Console.WriteLine($"command: reset");
                Console.WriteLine($"mode:    {(softSwitch.IsSet ? "soft" : "hard")}");
                Console.WriteLine($"commit:  {commitParameter.Value}");

                return 0;
            });
        }

        private static void PullCommand(ICommandParser app)
        {
            var command = app.Command("pull")
               .HelpText("Fetch from and integrate with another repository or a local branch");

            var verboseSwitch = command.Switch("v")
                .Alias("verbose")
                .HelpText("Only print error and warning messages; all other output will be suppressed.");

            var repositoryParameter = command.Parameter<string>(0, "repository")
               .HelpText("The repository to pull from")
               .DefaultValue("origin");

            command.Handler(_ =>
            {
                Console.WriteLine($"command:    pull");
                Console.WriteLine($"verbose:    {(verboseSwitch.IsSet ? "soft" : "hard")}");
                Console.WriteLine($"repository: {(repositoryParameter.IsSet ? repositoryParameter.Value : "-")}");

                return 0;
            });
        }

        private static void PushCommand(ICommandParser app)
        {
            var command = app.Command("push")
               .HelpText("Update remote refs along with associated objects");

            var repositoryParameter = command.Parameter<string>(0, "repository")
               .HelpText("The remote repository that is destination of a push operation")
               .DefaultValue("origin");
            var refspecParameter = command.Parameter<string>(1, "refspec")
               .HelpText("Specify what destination ref to update with what source object");

            command.Handler(_ =>
            {
                Console.WriteLine($"command:    push");
                Console.WriteLine($"repository: {(repositoryParameter.IsSet ? repositoryParameter.Value : "-")}");
                Console.WriteLine($"refspec:    {(refspecParameter.IsSet ? refspecParameter.Value : "-")}");

                return 0;
            });
        }

        private static void CommitCommand(ICommandParser app)
        {
            var command = app.Command("commit")
               .HelpText("Record changes to the repository");

            var messageParameter = command.Parameter<string>("m")
               .Alias("message")
               .HelpText("Use the given <msg> as the commit message")
               .Required();

            command.Handler(_ =>
            {
                Console.WriteLine($"command: commit");
                Console.WriteLine($"message: {messageParameter.Value}");

                return 0;
            });
        }
    }
}