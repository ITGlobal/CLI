# Command line parser

> [home](../README.md) > command line parser

`ITGlobal.CLI` offers a simple but powerful command line arguments parser.

## Features

* Supports swiches, options and positional arguments.
* Supports commands (e.g. `myapp command`) and nested commands (e.g. `myapp command subcommand`)
* Provides fluent interface for configuration
* Supports customizable value parsing and validation
* Contains an automatic help generator

## Sample

```csharp
var parser = CliParser.NewTreeParser();

// Switches
var debugSwitch = parser.Switch('D', "debug", helpText: "Enable debug mode");
var versionSwitch = parser.Switch('v', "version", helpText: "Print version information and quit");

// Options
var hostsOption = parser.RepeatableOption<string>('H', "host", helpText: "Host name")
    .FromEnvironmentVariable("HOST")
    .DefaultValue("localhost");
var logLevelOption = parser.Option<LogLevel>('l', "log-level", helpText: "Set the logging level");

// Commands
var infoCommand = parser.Command("info", helpText: "Display system-wide information");
infoCommand.OnExecute(_ =>
{
    Terminal.Stdout.WriteLine("It'me, 'info' command!");
});

var getCommand = parser.Command("get", helpText: "Gets a value");

// Nested command
var getStringCommand = getCommand.Command("string", helpText: "Gets a string value");
getStringCommand.OnExecute(_ =>
{
    Terminal.Stdout.WriteLine("It'me, 'get string' command!");
});

var exitCode = parser.Parse("-D", "get", "string").Run();
```

## Usage

1. First create an instance of parser:

   ```csharp
   var parser = CliParser.NewTreeParser();
   // or
   var parser = CliParser.NewSimpleParser();
   ```

   **SimpleParser** is basically the same parser except it doesn't support commands.

2. Configure switches, arguments, options and commands:

   ```csharp
   parser.Switch(...);
   parser.Option(...);
   parser.Argument(...);
   parser.Command(...);
   ```

3. Consume command line and execute the result:

   ```csharp
   var exitCode = parser.Parse(arguments).Run();
   ```

### Parser execution flow

1. At first parser validates its configuration
2. Then it parses command line input
   * at this point, [value parsers](value-parser.md) are invoked if neccessary
3. Then parser checks parsed values using validation rules
   * at this point, value validators are invoked if neccessary
4. Then `BeforeExecute` hooks are executed. Hooks may break the execution flow preventing further execution.
5. At last parser executes matching `OnExecute` handlers.

## Detailed descriptions

### [Switches](switches.md)

### [Options](options.md)

### [Arguments](arguments.md)

### [Commands](commands.md)

### [Flags](flags.md)
