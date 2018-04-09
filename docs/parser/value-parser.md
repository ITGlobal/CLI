# Value parser

> [home](../README.md) > [command line parser](README.md) > value parser

Since raw command line is a string, a parsing is needed to populate options and arguments with non-string values.

Command line parser supports parsing of any custom types via `IValueParser<T>`.

You may set a value parser for `CliOption<T>`/`CliRepeatableOption<T>`/`CliArgument<T>`/`CliRepeatableArgument<T>` with `UseParser()` methods.

## Built-in types

You don't need to set custom value parser if your option have one of the following value types:

* `string` (obviously)
* `bool`
* `char`
* `byte`
* `sbyte`
* `short`
* `ushort`
* `int`
* `uint`
* `long`
* `ulong`
* `float`
* `double`
* `decimal`
* `DateTime`
* any of enum types
* array of any of types above (comma-separated)