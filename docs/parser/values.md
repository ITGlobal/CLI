---
layout: default
---
# Value parser

[Go back](../parser#home)

---

* [Built-in types](#built-in)
* [Enum types](#enum)

Since raw command line is a string, a parsing is needed to populate options and arguments with non-string values.

Command line parser supports parsing of any custom types via `IValueParser<T>`.

You may set a value parser for `CliOption<T>`/`CliRepeatableOption<T>`/`CliArgument<T>`/`CliRepeatableArgument<T>`
with `UseParser()` methods:

```csharp
var option2 = parser.Option<MyCustomType>("option")
                    .UseParser(new MyCustomTypeValueParser());
```

## Built-in types {#built-in}

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
* any of enum types (see [more below](#enum))
* array of any of types above (comma-separated)

## Enum types {#enum}

Built-in enum value parser supports few ways to configure parsing.

* If an enum member is annotated with an `IgnoreDataMemberAttribute` or
  a `CliParserIgnoreAttribute`,
  this enum member won't be parsed.

* If an enum member is annotated with a `CliParserMemberAttribute`,
  an attribute's parameter is used as enum member's text format.
  a `CliParserMemberAttribute` might be specified multiple times,
  providing aliases for a enum member.

  No other rules will be applied if at least one `CliParserMemberAttribute` is defined.

* If an enum member is annotated with a `DataMemberAttribute`
  and its `Name` property is set, then its value is used as enum member's text format.

  No other rules will be applied if a `DataMemberAttribute` with non-empty `Name` is defined.

* Otherwise, a enum member's name is used as enum member's text format.

See an example below:

```csharp
public enum MyEnum
{
    // This enum member won't be parsed
    [IgnoreDataMember]
    IgnoreMe,

    // This enum member won't be parsed either
    [CliParserIgnore]
    IgnoreMeToo,

    // This enum member will be parsed as "Value1`
    Value1,

    // This enum member will be parsed as "V2`
    [DataMember(Name = "V2")]
    Value2,

    // This enum member will be parsed as "Value3`
    [DataMember]
    Value3,

    // This enum member will be parsed as "V4`
    [CliParserMember("V4")]
    Value4,

    // This enum member will be parsed as "V4`
    // Note that CliParserMemberAttribute takes priority
    [CliParserMember("V5")]
    [DataMember(Name = "Not_V5")]
    Value5,
}
```

Enum value parser is case-insensitive, so it will handle `Value1`, `value1` and `VALUE1` as the same value.
