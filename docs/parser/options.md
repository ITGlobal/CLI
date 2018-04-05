# Command line parser - options

**Option** is a named command line parameter that have a value.

Options may have:

* only one-char short name,
* only more-than-one-char long name,
* both short and long names.

## Defining options

Use a `Option<T>()` method of parser or command to add an option:

```csharp
// Create an option with short name only
var option = parser.Option<string>('s');

// Create an option with long name only
var option = parser.Option<string>("switch");

// Create an option with both short and long names
var option = parser.Option<string>('s', "switch");
```

## Configuration

### Help text

Use either `helpText` parameter of `Option<T>()` method or a `HelpText()` method of `CliOption<T>` to specify description for an autogenerated help:

```csharp
var option = parser.Option<string>('s', helpText: "Help text");
// or
option.HelpText("Help text");
```

### Hidden option

Use either `hidden` parameter of `Option<T>()` method or a `Hidden()` method of `CliOption<T>` to hide an option from an autogenerated help:

```csharp
var option = parser.Option<string>('s', hidden: true);
// or
option.Hidden();
```

### Display order

Use `DisplayOrder()` method of `CliOption<T>` to override option display order in an autogenerated help:

```csharp
// This example with generate help with the following ordering:
//
// OPTIONS
//   z Option Z
//   a Option A
//
// If you drop the DisplayOrder() call - you'll get this:
//
// OPTIONS
//   a Option A
//   z Option Z
var optionA = parser.Option('a');
var optionZ = parser.Option('z').DisplayOrder(-1000);
```

## Value parsing

Use `UseParser()` method of `CliOption<T>` to override option value parsing:

```csharp
var option = parser.Option<OptValue>("opt");
option.UseParser(new OptValueParser());
```

[Read more about value parsing here](value-parser.md)

> **NOTE:** you must specify a custom parser unless you use any of built-in types as an option's value.

## Value validation

Not every value of an option might be valid. Command line parser supports value validation via callback functions:

```csharp
var option = parser.Option<OptValue>("opt");
option.Validate(ValidationFunction);

// This function will be called to validate a result of parsing
// It will be called even if option is not set
// Function should return null if value is valid
// and an error message otherwise
string ValidationFunction(OptValue value, bool isSet)
{
    if (!isSet)
    {
        return "value is not set";
    }

    if(!value.IsGood)
    {
        return "value is bad";
    }

    return null;
}
```

You can add more than one validation function - they will be called in a chain:

```csharp
var option = parser.Option<OptValue>("opt");
option.Validate(Validate_IsSet);
option.Validate(Validate_IsGood);

string Validate_IsSet(OptValue value, bool isSet)
{
    if (!isSet)
    {
        return "value is not set";
    }

    return null;
}

string Validate_IsGood(OptValue value, bool isSet)
{
    // No need to check "isSet" parameter here
    // If value is not set - Validate_IsGood() will not be called,
    // since Validate_IsSet() would return an error
    if(!value.IsGood)
    {
        return "value is bad";
    }

    return null;
}
```

There is a helper method for required parameter validation - `Required()`. It checks if value is set and fails if an option is missing.
Also it affects autogenerated help, marking an option as required one:

```csharp
var option = parser.Option<OptValue>("opt");
option.Required();
option.Validate(Validate_IsGood);

string Validate_IsGood(OptValue value, bool isSet)
{
    // No need to check "isSet" parameter here since Required() will handle it
    if(!value.IsGood)
    {
        return "value is bad";
    }

    return null;
}
```

## Default values

There's a way to provide default values for an option. You may use:

* a plain value
* a value from an environment variable
* a value provided by a custom function

### Constant default value

Use the `DefaultValue()` method to set an option's default value:

```csharp
var option = parser.Option<string>("hostname");
option.DefaultValue("localhost");
// This option will have a value "localhost" if it's not set
```

### Default value from an environment variable

Use the `FromEnvironmentVariable()` method to bind option's default value to an environment variable:

```csharp
var option = parser.Option<string>("hostname");
option.FromEnvironmentVariable("HOSTNAME");
// This option will have a value getenv("HOSTNAME") if it's not set
```

### Default value provided by a custom function

You may define a custom value provider function to set option's default value.
For example, you may try to read default value from a config file:

```csharp
var option = parser.Option<string>("hostname");
option.DefaultValue(TryReadHostnameFromConfigFile);
// This option will have a value from a config file if it's not set
// If config file doesn't exists option will have no value

bool TryReadHostnameFromConfigFile(out string value)
{
    if(configFile.Exists)
    {
        value = configFile.GetString("hostname");
        return true;
    }

    return false;
}
```

### Using more than one default value

You may set more that one default value from various sources. Parser will try to take each of values in the same order as they were set.

```csharp
var option = parser.Option<string>("hostname");
option.FromEnvironmentVariable("HOSTNAME");
option.DefaultValue(TryReadHostnameFromConfigFile);
option.DefaultValue("localhost");

bool TryReadHostnameFromConfigFile(out string value)
{
    // ...
}
```

This example above will do the following:

1. First parser will try to read `hostname` option from command line arguments
2. If `hostname` option is not specified, parser will try to parse environment variable `HOSTNAME`.
3. If `HOSTNAME` variable is either not set or contains an invalid value, parser will use `hostname` as an option's value.

### Default value and validation

Default values are applied before any validation takes place. So you should be careful when specifying a default value:

```csharp
var option = parser.Option<string>("option");
option.DefaultValue("not-empty");

// This validator could be omitted without any damage,
// it would never fire
option.Required(); 

// ...

var option = parser.Option<string>("option");
// This default value could be omitted
// since it would never pass validation
option.DefaultValue("1");
option.Validate(Validate_IsGood);

string ValidationFunction(string value, bool isSet)
{
    if(value == null || value.Length < 2)
    {
        return "value is too short or empty";
    }

    return null;
}
```

## Repeatable options

There are cases when you might need to have more than one value for an option. There are two ways to archieve this:

* An option with array value:

  ```shell
  program --option value-1,value-2,value-3
  program --option "value-1, value-2, value-3"
  ```

* A repeatable option:

  ```shell
  program --option value-1 --option value-2 --option value-3
  ```

Array-values options require only a customized value parser unless you use built-in type array
as a value type (e.g. `int[]`) - parser will handle such options without any external efforts:

```csharp
// Arrays of built-in types don't require custom parser
var option1 = parser.Option<string[]>("option-1");

// Arrays of custom types however do require a custom parser
// ! Note that you will need a IValueParser<MyCustomType[]> implementation
// ! and not a IValueParser<MyCustomType>
var option2 = parser.Option<MyCustomType[]>("option-2")
                    .UseParser(new ArrayOfMyCustomTypeParser());
```

Parser offers a better way to handle multi-values options called a **repeatable option**.
Use via `RepeatableOption()` method to create a repeatable option:

```csharp
var option = parser.RepeatableOption<string>("option");
```

`CliRepeatableOption<T>` has the very same API as ordinary `CliOption<T>` with only one exception:
it has no `Value` property but there is a `Values` property instead.