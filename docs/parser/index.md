---
layout: default
---
# Command line parser

[Go back](..)

---

`ITGlobal.CLI` offers a simple but powerful command line arguments parser.

## Features

* [Switches](switches)
* [Options](options)
* [Positional arguments](arguments)
* [Commands (including nested commands)](commands)
* [Value parsers](values)
* [Built-in help](help)
* [Parser configuration options](config)

## Quickstart

1. First create an instance of parser:

   ```csharp
   var parser = CliParser.NewTreeParser();
   // or
   var parser = CliParser.NewSimpleParser();
   ```

   **SimpleParser** is basically the same parser except it doesn't support commands.
   You may use it to create a single-command applications.

2. Configure [switches](switches), [positional arguments](arguments), [options](options) and [commands](commands):

   ```csharp
   parser.Switch(...);
   parser.Option(...);
   parser.Argument(...);
   parser.Command(...);
   ```

3. Define global and per-command hooks and handlers:

   ```csharp
   parser.BeforeExecute(...);
   command.BeforeExecute(...);
   command.OnExecute(...);
   ```

4. Consume command line and execute the result:

   ```csharp
   var exitCode = parser.Parse(arguments).Run();
   ```

   Note that a parser won't throw any exceptions regardless of its input arguments.
   However, it will throw an exception if it's not property configured,
   e.g. it has a custom-types option without a value parser.

  Here's a detailed description of execution stages:

  1. At first parser validates its configuration (this is the only stage when parser might throw an exception).
  2. Then it parses command line input
     * at this point, [value parsers](values) are invoked if neccessary
  3. Then parser checks parsed values using validation rules  
     * at this point, value validators are invoked if neccessary
  4. Then `BeforeExecute` hooks are executed.
     Hooks may break the execution flow preventing further execution.

     Hooks are selected from matching command, its parent command,
     its parent's parent command and so on, including root-level hooks.
     Hooks are executed in reverse order, starting from root-level ones.

     If a command or a parser have more than one hook - they will be executed
     in the same order as they were defined.

     If any of hooks calls the `ICliContext.Break()` methods then no more hooks will be executed.
     Handlers won't be executed either, parser will break executiong and return an exit code
     specified in `ICliContext.Break()` method call.

  5. At last parser executes matching `OnExecute` handlers.
     If a command line matches a command - then its `OnExecute` handler will be invoked.
     Otherwise a parser's `OnExecute` handler will be invoked.

     If a command or a parser have more than one handler - they will be executed
     in the same order as they were defined.

     If any of handlers calls the `ICliContext.Break()` methods then no more handlers will be executed.
     Parser will break executiong and return an exit code specified in `ICliContext.Break()` method call.

## An example

```csharp
var parser = CliParser.NewTreeParser();

// Switches
// debugSwitch and versionSwitch are global switches, they're available for any command
var debugSwitch = parser.Switch('D', "debug", helpText: "Enable debug mode");
var versionSwitch = parser.Switch('v', "version", helpText: "Print version information and quit");

// Options
// hostsOption and logLevelOption are global options, they're available for any command
var hostsOption = parser.RepeatableOption<string>('H', "host", helpText: "Host name")
    .FromEnvironmentVariable("HOST")
    .DefaultValue("localhost");
var logLevelOption = parser.Option<LogLevel>('l', "log-level", helpText: "Set the logging level");

// Commands
var infoCommand = parser.Command("info", helpText: "Display system-wide information");
infoCommand.OnExecute(_ =>
{
    Console.WriteLine("It'me, 'info' command!");
});
var getCommand = parser.Command("get", helpText: "Gets a value");

// Nested command
// Note that it has a command-specific switch - a detailedSwitch
// It will be parsed only when a "get string" command is invoked
var getStringCommand = getCommand.Command("string", helpText: "Gets a string value");
var detailedSwitch = getStringCommand.Switch('d', "detailed")
    .HelpText("Provide a detailed value");
getStringCommand.OnExecute(_ =>
{
    Console.WriteLine("It'me, 'get string' command!");
    if (detailedSwitch)
    {
        Console.WriteLine("Some extra details were requested");
    }
});

// A BeforeExecute global hook
// This callback will be invoked before any command handlers,
// including a built-in implicit help command
parser.BeforeExecute(ctx =>
{
    if (versionSwitch)
    {
        // When a versionSwitch is set, no command should be executed
        Console.WriteLine("Version 1.0.0");
        ctx.Break();
    }
});
var exitCode = parser.Parse("-D", "get", "string").Run();
```
