---
layout: default
---
# CLI - Command Line Interface library {#home}

[![Build status](https://ci.appveyor.com/api/projects/status/l3v4nu7dcra3o8nd/branch/master?svg=true)](https://ci.appveyor.com/project/itgloballlc/cli/branch/master)
[![NuGet](https://img.shields.io/nuget/v/ITGlobal.CLI.svg)](https://www.nuget.org/packages/ITGlobal.CLI/)

`ITGlobal.CLI` is a powerful library to build used-friendly command-line applications.

## Features

* Cross-platform

  `ITGlobal CLI` supports:

  * .NET 4.5
  * .NET Core (`netstandard2.0`)

  It runs on Windows, Linux or MacOS.

* [Core features](core)
  * [Colored console output](core#colors)
  * [Ctrl+C/SIGINT interceptor](core#ctrl-c)
  * [Unified error handling](core#errors)
  * [No-Colors mode](core#no-colors)
* [Command line parser](parser)
  * [Switches](parser/switches)
  * [Options](parser/options)
  * [Positional arguments](parser/arguments)  
  * [Commands (including nested commands)](parser/commands)
  * [Value parsers](parser/values)
  * [Built-in help](parser/help)
  * [Parser configuration options](parser/config)
* [ASCII tables](table)
  * [Data-driven tables](table/data-driven)
  * [Free-format (fluent) tables](table/fluent)
* [Terminal live output](live)
  * [Live text](live#live-text)
  * [Spinner](live#spinner)
  * [Progress bar](live#progress-bar)

## Installing

All you need is to install a [`ITGlobal.CLI`](https://www.nuget.org/packages/ITGlobal.CLI/) NuGet package into your project:

**Using dotnet CLI**

```shell
dotnet add package ITGlobal.CLI
```

**Using Package Manager Console in Visual Studio**

```shell
Install-Package ITGlobal.CLI
```

**Manually in .csproj file**

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <!-- ... -->

  <ItemGroup>
    <PackageReference Include="ITGlobal.CLI" Version="3.0.29" />
  </ItemGroup>

  <!-- ... -->
</Project>
```
