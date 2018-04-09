# ITGlobal CLI

[![Build status](https://ci.appveyor.com/api/projects/status/l3v4nu7dcra3o8nd/branch/master?svg=true)](https://ci.appveyor.com/project/itgloballlc/cli/branch/master)
[![NuGet](https://img.shields.io/nuget/v/ITGlobal.CLI.svg)](https://www.nuget.org/packages/ITGlobal.CLI/)

This library is a set of various utilities to build command line application in C#.

## Features

### Cross-platform

`ITGlobal CLI` supports:

* .NET 4.0
* .NET 4.5
* .NET Core (`netstandard1.6`)

It has no external dependencies and may run on Windows, Linux or MacOS.

### [Command line parser](https://itglobal.github.io/CLI/parser)

Unlike most command line parsers for .NET, `ITGlobal CLI Parser` uses fluent interface to define command line parameters and commands.
An example below shows a fast implementation of `git pull` and `git push` commands:

```csharp
var git = CliParser.NewTreeParser()
    .ExecutableName("my-git")
    .HelpText("git wannabe");

// Global '-v' switch
var verboseSwitch = git.Switch('v')
    .HelpText("Verbose output");

// 'push' command
var pushCommand = git.Command("push")
    .HelpText("Push changes to remote repo");

// Positional 'remote' argument specific to 'push' command (defaults to 'origin')
var pushRemoteParameter = pushCommand.Argument<string>(0, "remote")
    .DefaultValue("origin");

// Positional 'refspec' argument specific to 'push' command (defaults to null)
var pushRefParameter = pushCommand.Argument<string>(1, "refspec");

// Push-force switch for 'push' command
var pushForceSwitch = git.Switch('f', "force")
    .HelpText("Push force");

pushCommand.OnExecute(_ =>
{
    var verbose = verboseSwitch.IsSet ? "-v" : "";
    var force = pushForceSwitch.IsSet ? "--force" : "";
    var remote = pushRemoteParameter.Value;
    var @ref = pushRefParameter.Value;
    Console.WriteLine($"git push {verbose} {force} {remote} {@ref}");
});


// 'pull' command
var pullCommand = git.Command("pull")
    .HelpText("Pul changes from remote repo");

// Positional 'remote' argument specific to 'pull' command (defaults to 'origin')
var pullRemoteParameter = pullCommand.Argument<string>(0, "remote")
    .DefaultValue("origin");

// Positional 'refspec' argument specific to 'pull' command (defaults to null)
var pullRefParameter = pullCommand.Argument<string>(1, "refspec");

// Named '--no-commit' switch specific to 'pull' command
var pullNoCommitSwitch = pullCommand.Switch("no-commit");
pullCommand.OnExecute(_ =>
{
    var verbose = verboseSwitch.IsSet ? "-v" : "";
    var remote = pullRemoteParameter.Value;
    var @ref = pullRefParameter.Value;
    Console.WriteLine($"git pull {verbose} {remote} {@ref}");
});

// Parse command line and execute command
git.Parse(args).Run();
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

### [Easy color management](https://itglobal.github.io/CLI/terminal)

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

### [Progress Bars](https://itglobal.github.io/CLI/progress-bar)

You can draw progress bars using the following methods:

```csharp
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

### [Spinners](https://itglobal.github.io/CLI/spinner)

You can draw spinners using the following methods:

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
```

### [Formatted tables](https://itglobal.github.io/CLI/table)

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

`ITGlobal.CLI` tables suppport:

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
