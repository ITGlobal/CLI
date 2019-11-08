using ITGlobal.CommandLine.Parsing;

namespace ITGlobal.CommandLine.Example
{
    public static class NestedHelpOutputDemo
    {
        public static void Run()
        {
            var app = CliParser.NewTreeParser("app");
            app.Option("global-opt");

            var rootCommand = app.Command("root");
            rootCommand.Option("root-opt");

            var nestedCommand = rootCommand.Command("nested");
            nestedCommand.Option("nested-opt");

            var subCommand = nestedCommand.Command("sub");
            subCommand.Option("sub-opt");
            
            app.Parse("root", "nested", "sub", "--help").Run();
        }
    }
}