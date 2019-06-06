---
layout: default
---
# Data-driven tables

> [CLI](../..) / [Tables](../tables) / Data-driven

`ITGlobal CLI` offers a way to generate a pretty-formatted tables from a list of objects.

First, prepare source data:

```csharp
var list = new List<TableRow>();
// TODO fill list with table source data
```

Then create a strongly-typed table builder:

```csharp
// Create and configure table renderer
var renderer = TableRenderer.Grid(GridTableStyle.Pretty());
// Then create a table builder attached to source data and renderer
var table = TerminalTable.Create(list, renderer);

// or alternatively create a table builder with default renderer
var table = TerminalTable.Create(list);
```

Define table columns:

```csharp
table.Column("ID", _ => _.Id);
table.Column("Image", _ => _.Image);
table.Column("Created", _ => _.Created);
table.Column("Status", _ => _.Status, style: _ => _.IsRunning ? ColoredStringStyle.Red : null);
```

And finally render table to console:

```csharp
table.Draw();
```

![](data-driven.png)