---
layout: default
---
# Terminal colored output

> [home](..) > colored output

`ITGlobal.CLI` provides (and uses internally) a unified wrapper for standart input, output and error streams - a `ColoredString` struct.

![](colors.png)

Under the hood `ITGlobal.CLI` uses ANSI escape codes for colorization.
Also it contains a driver to properly handle ANSI color codes while running on Windows.
However, only color codes are supported, full ANSI support is not available.

## Colored output

1. First, you need to initialize an ANSI driver:

   ```csharp
   Terminal.Initialize();
   ```


2. Then you need to create an instance of `ColoredString`:

   ```csharp
   // Custom foreground color, default background color
   var str1 = "My colored string (RED on DEFAULT)".Fg(ConsoleColor.Red);

   // Default foreground color, custom background color
   var str2 = "My colored string (DEFAULT on CYAN)".Bg(ConsoleColor.Cyan);

   // Custom foreground color, custom background color
   var str3 = "My colored string (RED on CYAN)".Colored(ConsoleColor.Red, ConsoleColor.Cyan);

   // Default foreground color, default background color
   var str4 = "My colored string (DEFAULT on DEFAULT)".Fg();
   ```

3. And finally you need to write a `ColoredString` to console (using any method available):

   ```csharp
   Console.WriteLine($"Colored strings: {str1}; {str2}; {str3}; {str4};");
   ```

Also there is a `ColoredStringStyle` class which is a factory that created a `ColoredString`
with predefined colors from an ordinary string.