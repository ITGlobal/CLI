# Flags

> [home](../README.md) > [command line parser](README.md) > flags

Command line parser's behavior may be altered with `CliParserFlags`:

```csharp
// You may specify flags when creating an instance of parser
var parser = CliParser.NewSimpleParser(flags: CliParserFlags.Default);
// or set flags later
parser.Flags(CliParserFlags.Default);
```

## Supported flags

| Flag                          | Effect                                                        |
|-------------------------------|---------------------------------------------------------------|
| `IgnoreUnknownOptions`        | Parser will not fail on unknown options when flag is set      |
| `AllowFreeArguments`          | Parser will not fail on unconsumed arguments when flag is set |
| `PosixNotation`               | Enabled POSIX style parsing (see below)                       |
| `WindowsNotation`             | Enabled Windows/DOS style parsing (see below)                 |
| `ColonSeparatedValues`        | Enables color-separated options (see below)                   |
| `EqualitySignSeparatedValues` | Enables equality sign-separated options (see below)           |

> By default, only `PosixNotation` and `EqualitySignSeparatedValues` flags are set.

## Option styles

Command line options have a name and an value. There are few ways to separate them.

### Space-separated option

Most general option style is space-separation option. This means that option name and option value are separated with a whitespace:

```
--key value
```

> This style cannot be disabled.

### Colon-separated options

You may use a color (`:`) sign to separate option's name from it's value:

```
--key:value
```

### Equality sign-separated options

You may use an equality sign (`=`) sign to separate option's name from it's value:

```
--key=value
```

## POSIX notation

Parser supports POSIX notation with following features:

* Options and switches with long (more than one char) names:

  ```
  --key value --switch --long-switch-name value
  ```

  Note that names are prefixed with double dashes (`--`).

* Options and switches with one-char names:

  ```
  -k value -s -l value
  ```

  Note that names are prefixed with a single dash (`-`).

* Switches with one-char names combined together:

  ```
  -vxs -dt
  ```

  This is basically a short form of:

  ```
  -v -x -s -d -t
  ```

* Arguments separator `--` - everything after `--` token is forcibly consumed as arguments:

  ```
  -k value -v --key value -- foo bar -z --gamma value
  ```

  In this example only `-k`, `-v` and `--key` are options/switches, and `foo bar -z --gamma value` are free arguments.

## Windows/DOS notation

Parser supports Windows/DOS notation with following features:

* Options and switches with long (more than one char) names:

  ```
  /key value /switch /long-switch-name value
  ```

* Options and switches with one-char names:

  ```
  /k value /s /l value
  ```

> Note than both POSIX and Windows/DOX notations may be enabled simultaneously.