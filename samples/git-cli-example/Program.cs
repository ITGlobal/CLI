using System;
using System.Reflection;
using ITGlobal.CommandLine.Parsing;

namespace ITGlobal.CommandLine.Example
{
    class Program
    {
        public static int Main(string[] args)
        {
            var app = CliParser.NewTreeParser(executableName: "git-cli-example", helpText: "git wannabe");

            // Global '--version' switch
            var versionSwitch = app.Switch("version").HelpText("Print app version and exit");
            app.BeforeExecute(ctx =>
            {
                if (versionSwitch.IsSet)
                {
                    var version = typeof(Program).GetTypeInfo().Assembly
                        .GetCustomAttribute<AssemblyFileVersionAttribute>()
                        .Version;
                    Terminal.Stdout.WriteLine($"my-git version {version}");
                    ctx.Break();
                }
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

            // Parse command line and execute command
            return TerminalErrorHandler.Handle(() => app.Parse(args).Run());
        }

        private static void CloneCommand(ITreeCliParser app)
        {
            var command = app.Command("clone");
            command.HelpText("Clone a repository into a new directory");

            var repositoryParameter = command.Argument<string>("repository")
                .HelpText("The (possibly remote) repository to clone from")
                .Required();

            var directoryParameter = command.Argument<string>("directory")
                .HelpText("The name of a new directory to clone into");

            var branchParameter = command.Option<string>('b', "branch")
                .HelpText("The name of a branch to checkout");

            command.OnExecute(_ =>
            {
                Console.WriteLine($"command:    clone");
                Console.WriteLine($"repository: {repositoryParameter.Value}");
                Console.WriteLine($"directory:  {(directoryParameter.IsSet ? directoryParameter.Value : "-")}");
                Console.WriteLine($"branch:     {(branchParameter.IsSet ? branchParameter.Value : "-")}");
            });
        }

        private static void InitCommand(ITreeCliParser app)
        {
            var command = app.Command("init")
                .HelpText("Create an empty Git repository or reinitialize an existing one");

            var quietSwitch = command.Switch('q', "quiet")
                .HelpText("Only print error and warning messages; all other output will be suppressed.");

            var bareSwitch = command.Switch("bare")
                .HelpText("Create a bare repository");

            var directoryParameter = command.Argument<string>("directory")
                .HelpText("The name of a directory");

            command.OnExecute(_ =>
            {
                Console.WriteLine($"command:   init");
                Console.WriteLine($"quiet:     {(quietSwitch.IsSet ? "Y" : "N")}");
                Console.WriteLine($"bare:      {(bareSwitch.IsSet ? "Y" : "N")}");
                Console.WriteLine($"directory: {(directoryParameter.IsSet ? directoryParameter.Value : "-")}");
            });
        }

        private static void AddCommand(ITreeCliParser app)
        {
            var command = app.Command("add")
                   .HelpText("Add file contents to the index");

            var verboseSwitch = command.Switch('v', "verbose")
                .HelpText("Only print error and warning messages; all other output will be suppressed.");

            var pathspecParameter = command.Argument<string>("pathspec")
                .Required()
                .HelpText("Files to add content from");

            command.OnExecute(_ =>
            {
                Console.WriteLine($"command:  add");
                Console.WriteLine($"verbose:  {(verboseSwitch.IsSet ? "Y" : "N")}");
                Console.WriteLine($"pathspec: {pathspecParameter.Value}");
            });
        }

        private static void ResetCommand(ITreeCliParser app)
        {
            var command = app.Command("reset")
                  .HelpText("Reset current HEAD to the specified state");

            var softSwitch = command.Switch("soft")
                .HelpText("Does not touch the index file or the working tree at all");
            var hardSwitch = command.Switch("hard")
                .HelpText("Resets the index and working tree");

            var commitParameter = command.Argument<string>("commit")
                .Required()
                .HelpText("Commit to reset to");

            command.OnExecute(_ =>
            {
                if (!(softSwitch.IsSet ^ hardSwitch.IsSet))
                {
                    throw new Exception("Specify exactly one of switches: --soft, --hard");
                }

                Console.WriteLine($"command: reset");
                Console.WriteLine($"mode:    {(softSwitch.IsSet ? "soft" : "hard")}");
                Console.WriteLine($"commit:  {commitParameter.Value}");
            });
        }

        private static void PullCommand(ITreeCliParser app)
        {
            var command = app.Command("pull")
               .HelpText("Fetch from and integrate with another repository or a local branch");

            var verboseSwitch = command.Switch('v', "verbose")
                .HelpText("Only print error and warning messages; all other output will be suppressed.");

            var repositoryParameter = command.Argument<string>("repository")
               .HelpText("The repository to pull from")
               .DefaultValue("origin");

            command.OnExecute(_ =>
            {
                Console.WriteLine($"command:    pull");
                Console.WriteLine($"verbose:    {(verboseSwitch.IsSet ? "soft" : "hard")}");
                Console.WriteLine($"repository: {(repositoryParameter.IsSet ? repositoryParameter.Value : "-")}");
            });
        }

        private static void PushCommand(ITreeCliParser app)
        {
            var command = app.Command("push")
               .HelpText("Update remote refs along with associated objects");

            var repositoryParameter = command.Argument<string>("repository")
               .HelpText("The remote repository that is destination of a push operation")
               .DefaultValue("origin");
            var refspecParameter = command.Argument<string>("refspec")
               .HelpText("Specify what destination ref to update with what source object");

            command.OnExecute(_ =>
            {
                Console.WriteLine($"command:    push");
                Console.WriteLine($"repository: {(repositoryParameter.IsSet ? repositoryParameter.Value : "-")}");
                Console.WriteLine($"refspec:    {(refspecParameter.IsSet ? refspecParameter.Value : "-")}");
            });
        }

        private static void CommitCommand(ITreeCliParser app)
        {
            var command = app.Command("commit")
               .HelpText("Record changes to the repository");

            var messageParameter = command.Option<string>('m', "message")
               .HelpText("Use the given <msg> as the commit message")
               .Required();

            command.OnExecute(_ =>
            {
                Console.WriteLine($"command: commit");
                Console.WriteLine($"message: {messageParameter.Value}");
            });
        }
    }
}
