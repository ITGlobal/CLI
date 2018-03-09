# ITGlobal CLI

[![Build status](https://ci.appveyor.com/api/projects/status/l3v4nu7dcra3o8nd/branch/master?svg=true)](https://ci.appveyor.com/project/itgloballlc/cli/branch/master)
[![NuGet](https://img.shields.io/nuget/v/ITGlobal.CLI.svg?maxAge=2592000)](https://www.nuget.org/packages/ITGlobal.CLI/)

This library is a set of various utilities to build command line application in C#.

## Contents

* [Cross-platform](#cross-platform)
* [Easy color management](#easy-color-management)
* [Graceful Ctrl+C handlers](#graceful-ctrlc-handlers)
* [Unified error handling](#unified-error-handling)
* [Command line parser](#command-line-parser)
* [Progress Bars and Spinners](#progress-bars-and-spinners)
* [Formatted tables](#formatted-tables)

## Features

### Cross-platform

`ITGlobal CLI` supports:

* .NET 4.0
* .NET 4.5
* .NET Core (`netstandard1.6`)

It has no external dependencies and may run on Windows, Linux or MacOS.

### Easy color management

```csharp
Terminal.Stdout.WriteLine(
    "This text will be written in RED font on default background"
        .WithForeground(ConsoleColor.Red)
);

Terminal.Stdout.WriteLine(
    "This text will be written in WHITE font on RED background"
        .WithForeground(ConsoleColor.White)
        .WithBackground(ConsoleColor.Red)
);

Terminal.Stdout.WriteLine(
    "And this text will be written in WHITE font on default background"
        .WithForeground(ConsoleColor.White)
);

using(Terminal.Stdout.WithForeground(ConsoleColor.Red))
{
    Terminal.Stdout.WriteLine("This text will be written in RED font on default background");

    using(Terminal.Stdout.WithForeground(ConsoleColor.White))
    {
        using(Terminal.Stdout.WithBackground(ConsoleColor.Red))
        {
            Terminal.Stdout.WriteLine("This text will be written in WHITE font on RED background");
        }

        Terminal.Stdout.WriteLine("And this text will be written in WHITE font on default background");
    }
}
```

### Graceful Ctrl+C handlers

```csharp
using(var ctrlC = Terminal.Current.AttachCtrlCInterceptor())
{
    var token = ctrlC.CancellationToken;
    token.Register(() => Console.WriteLine("This is a callback on a CancellationToken"));

    Console.WriteLine("Press Ctrl+C to break the loop...");
    token.WaitHandle.WaitOne();
    Console.WriteLine("Cancelled!");
}
```

### Unified error handling

```csharp
TerminalErrorHandler.Handle(() =>
{
    throw new Exception("This exception will be pretty-printed to console");
});
```

Even for async functions!

```csharp
await TerminalErrorHandler.HandleAsync(async () =>
{
    await Task.Delay(100);
    throw new Exception("This exception will be pretty-printed to console");
});
```

### Command line parser

Unlike most command line parsers for .NET, `ITGlobal CLI Parser` uses fluent interface to define command line parameters and commands.
An example below shows a fast implementation of `git pull` and `git push` commands:

```csharp
var git = CLI.Parser().Title("my-git").Version("1.0.0").HelpText("git wannabe");

// Global '-v' switch
var verbose = git.Switch("v").HelpText("Verbose output");


// 'push' command
var pushCommand = git.Command("push").HelpText("Push changes to remote repo");

// Positional 'remote' parameter specific to 'push' command (defaults to 'origin')
var pushRemoteParameter = pushCommand.Parameter<string>(0, "remote").DefaultValue("origin");

// Positional 'refspec' parameter specific to 'push' command (defaults to null)
var pushRefParameter = pushCommand.Parameter<string>(1, "refspec");

pushCommand.Callback(_ =>
{
    Console.WriteLine($"git push{(verbose.IsSet ? " -v" : "")} {pushRemoteParameter.Value} {pushRefParameter.Value}");
    return 0; // Exit code
});


// 'pull' command
var pullCommand = git.Command("pull").HelpText("Pul changes from remote repo");

// Positional 'remote' parameter specific to 'pull' command (defaults to 'origin')
var pullRemoteParameter = pullCommand.Parameter<string>(0, "remote").DefaultValue("origin");

// Positional 'refspec' parameter specific to 'pull' command (defaults to null)
var pullRefParameter = pullCommand.Parameter<string>(1, "refspec");

// Named '--no-commit' switch specific to 'pull' command
var pullNoCommitSwitch = pullCommand.Switch("no-commit");
pullCommand.Callback(_ =>
{
    Console.WriteLine($"git pull{(verbose.IsSet ? " -v" : "")}{(pullNoCommitSwitch.IsSet ? " --no-commit" : "")} {pullRemoteParameter.Value} {pullRefParameter.Value}");
    return 0; // Exit code
});


// An auto-generated 'help' command
git.HelpCommand();


// Parse command line and execute command
git.Parse(args).Run();
```

This sample will show the following results:

```bash
$ my-git pull --no-commit origin master -v

my-git (1.0.0)
git pull -v --no-commit origin master

$ my-git push origin -v

my-git (1.0.0)
git push -v origin master

$ my-git help

my-git (1.0.0)
git wannabe

Usage:
my-git [command] [-v]

Parameters
==========
  -v      Verbose output
  command

Commands
========
  push  Push changes to remote repo
  pull  Pul changes from remote repo
  help  Show help
```

Parser supports:

* switches (valueless parameters),
* named parameters,
* positional paramters,
* custom parameter value parsers,
* parameter aliases,
* both global and command-scoped parameters,
* required parameter validation,
* default parameter values.

#### Localizable text resources

```csharp
TerminalErrorHandler.ErrorText = "Error!";
TerminalErrorHandler.InnerExceptionText = "--- Inner Exception ---";

TerminalTable.FooterRowsText = "Rows: {0}..{1}";
TerminalTable.FooterTotalText = "Total {0} rows";
TerminalTable.FooterPageNumberText = "Page {0} of {1}";

CLI.UseLocalizedText(new MyLocalizedText());
```

English and russian localizations are included out of the box.

### Progress Bars and Spinners

You can draw progress bars and spinners using the following methods:

```csharp
using (var spinner = TerminalSpinner.Create("preparing"))
{
    // Update a spinner label
    spinner.SetTitle("starting long operation");

    // Run a BLOCKING operation
    // Spinner animation will not freeze during this call
    LongBlockingOperation1();

    // Print various text into console and spinner will handle this properly
    Console.WriteLine("A line of text");
}

using (var progressBar = TerminalProgressBar.Create())
{
    // Update progress bar label only
    progressBar.SetState(text: "Label1");

    // Update progress bar progress only
    progressBar.SetState(75);

    // Update both progress bar progress and label
    progressBar.SetState(75, "Label2");

    // Print various text into console and progress bar will handle this properly
    Console.WriteLine("A line of text");
}
```

### Formatted tables

Print a strongly-typed table into console:

```csharp
var data = GetMyDataArray();

var table = TerminalTable.Create(data);

// Define table columns

// A plain column
table.Column("Header 1", _ => _.Property1);
// A RED column
table.Column("Header 2", _ => _.Property2, _ => ConsoleColor.Red);
// A multi-colored column
table.Column("Header 2", _ => _.Property2, row => GetColorForRow(row)));
// A trimmed column
table.Column("Header 3", _ => _.Property1, maxWidth: 24);

// Draw table
table.Draw();

```

`CLI.Table` suppports:

* Configurable table headers
* Per-cell colorization
* A pagination support (useful to view large tables in a console).
  Set `renderer` parameter of `TerminalTable.Create()` method to `TableRenderer.Paged()` to enable it.

## How to build

You'll need PowerShell and .NET Core SDK. Once you've got all the tools, run

```shell
./build.ps1
```

This will build the library and put the resulting NuGet packages into the `/artifacts` directory.

## License

[MIT](http://opensource.org/licenses/MIT)
