# Terminal wrapper

CLI provides (and uses internally) a unified wrapper for standart input, output and error streams - `Terminal` class.

![](colors.png)

## Colored output

There are few ways to print text to terminal with customized colors:

### Change default colors

```csharp
using(Terminal.Stdout.WithForeground(ConsoleColor.Green))
{
    Terminal.Stdout.WriteLine("GREEN on DEFAULT");

    using(Terminal.Stdout.WithBackground(ConsoleColor.Red))
    {
        Terminal.Stdout.WriteLine("GREEN on RED");
    }

    using(Terminal.Stdout.WithForeground(ConsoleColor.Red))
    {
        Terminal.Stdout.WriteLine("RED on DEFAULT");
    }
}
```

### Use TerminalString directly

```csharp
Terminal.Stdout.WriteLine(
  new TerminalString("GREEN on DEFAULT", ConsoleColor.Green, null)
);
Terminal.Stdout.WriteLine(
  new TerminalString("GREEN on RED", ConsoleColor.Green, ConsoleColor.Red)
);
Terminal.Stdout.WriteLine(
  new TerminalString("RED on DEFAULT", ConsoleColor.Red, null)
);
```

### Use extension methods on string type

```csharp
Terminal.Stdout.WriteLine(
  "GREEN on DEFAULT".WithForeground(ConsoleColor.Green)
);
Terminal.Stdout.WriteLine(
  "GREEN on RED"
    .WithForeground(ConsoleColor.Green)
    .WithBackground(ConsoleColor.Red)
);
Terminal.Stdout.WriteLine(
  "RED on DEFAULT".WithForeground(ConsoleColor.Red)
);
```

### Use few methods at the same time

```csharp
using(Terminal.Stdout.WithForeground(ConsoleColor.Green))
{
    Terminal.Stdout.WriteLine("GREEN on DEFAULT");

    Terminal.Stdout.WriteLine(
      "GREEN on RED".WithBackground(ConsoleColor.Red)
    );
    Terminal.Stdout.WriteLine(
      "RED on DEFAULT".WithForeground(ConsoleColor.Red)
    );
}
```
