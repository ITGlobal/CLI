---
layout: default
---
# Commands

[Go back](../parser)

---

Command line parser support commands, including nested commands.

A command is created with `Command()` method of a parser:

```csharp
var parser = CliParser.NewTreeParser();
var command1 = parser.Command("command1");
var command2 = parser.Command("command2");
```

In example above, a command line `my-app command1` will match `command1`,
`my-app command2` will match `command2` and `my-app` won't match any of them.

A command allows you to create:

* [switches](switches),
* [positional arguments](arguments),
* [options](options),
* and even nested commands.

Each of those will exist only in scope of their parent command, thus preventing any same-name conficts:

```csharp
var parser = CliParser.NewTreeParser();
parser.Switch("foo");

var command1 = parser.Command("command1");
command1.Switch("bar");

var command2 = parser.Command("command2");
// This definition is valid - there is no "bar" switch or option
// on command2 or on root parser
command2.Switch("bar");

// This definition is valid - there is no "command1" command
// on command2
var nestedCommand1 = command2.Command("command1");

// This definition is not valid - "bar" switch
// already exists on parent command
nestedCommand1.Switch("bar");

// This definition is not valid - "foo" switch
// already exists on root parser
nestedCommand1.Switch("foo");
```

An API of a `CliCommand` is similar to an API of `ITreeCliParser`:

* `Switch()` method allows creation of [switches](switches)
* `RepeatableSwitch()` method allows creation of [repeatable switches](switches#repeatable-switch)
* `Option()` method allows creation of [options](options)
* `RepeatableOption()` method allows creation of [repeatable options](options#repeatable-option)
* `Argument()` method allows creation of [arguments](arguments)
* `RepeatableArgument()` method allows creation of [repeatable arguments](arguments#repeatable-argument)
* `Command()` method allows creation of nested commands
* `BeforeExecute()` method adds an execution hook
* `BeforeExecuteAsync()` method adds an async execution hook
* `OnExecute()` method adds an execution handler
* `OnExecuteAsync()` method adds an async execution handler
