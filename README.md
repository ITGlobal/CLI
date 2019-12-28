# CLI - Command Line Interface library

[![Build status](https://ci.appveyor.com/api/projects/status/l3v4nu7dcra3o8nd/branch/master?svg=true)](https://ci.appveyor.com/project/itgloballlc/cli/branch/master)
[![NuGet](https://img.shields.io/nuget/v/ITGlobal.CLI.svg)](https://www.nuget.org/packages/ITGlobal.CLI/)

`ITGlobal.CLI` is a powerful library to build used-friendly command-line applications.

## Features

* [Core features](docs/core/index.md)
  * [Colored console output](docs/core/index.md#colors)
  * [Ctrl+C/SIGINT interceptor](docs/core/index.md#ctrl-c)
  * [Unified error handling](docs/core/index.md#errors)
  * [No-Colors mode](docs/core/index.md#no-colors)
* [Command line parser](docs/parser/index.md)
  * [Switches](docs/parser/switches.md)
  * [Options](docs/parser/options.md)
  * [Positional arguments](docs/parser/arguments.md)
  * [Commands (including nested commands)](docs/parser/commands.md)
  * [Value parsers](docs/parser/values.md)
  * [Built-in help](docs/parser/help.md)
  * [Parser configuration options](docs/parser/config.md)
* [ASCII tables](docs/table/index.md)
  * [Data-driven tables](docs/table/data-driven.md)
  * [Free-format (fluent) tables](docs/table/fluent.md)
* [Terminal live output](docs/live/index.md)
  * [Live text](docs/live/index.md#live-text)
  * [Spinner](docs/live/index.md#spinner)
  * [Progress bar](docs/live/index.md#progress-bar)

## Cross-platform

`ITGlobal CLI` supports:

* .NET 4.0
* .NET Core (`netstandard2.0`)

It runs on Windows, Linux or MacOS.

## [License](LICENSE)

MIT
