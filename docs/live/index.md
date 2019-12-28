---
layout: default
---
# Terminal live output

[Go back](..#home)

---

`ITGlobal CLI` contains a "live output" feature, which allows you to create:

* spinners,
* lines of text,
* progress bars

and to update them in-place.

See example below:

```csharp
// Progress bar
using (var liveOutput = LiveOutputManager.Create())
{
    var progressBar = liveOutput.CreateProgressBar("1/3...");
    Thread.Sleep(1000);
    progressBar.Write(33, "2/3...");
    Thread.Sleep(1000);
    progressBar.Write(66, "3/3...");
    Thread.Sleep(1000);
    progressBar.Complete("3/3 done");
}

// Line of text
using (var liveOutput = LiveOutputManager.Create())
{
    var text = liveOutput.CreateText("1/3...");
    Thread.Sleep(1000);
    text.Write("2/3...");
    Thread.Sleep(1000);
    text.Complete("3/3 done");
}

// Spinner
using (var liveOutput = LiveOutputManager.Create())
{
    var spinner = liveOutput.CreateSpinner("Downloading...");
    // Update a spinner label
    spinner.Write("Starting long operation");

    // Run a BLOCKING operation
    // Spinner animation will not freeze during this call
    LongBlockingOperation1();

    // Print various text into console and spinner will handle this properly
    Console.WriteLine("A line of text");
}
```

`LiveOutputManager` proprely handles console output, e.g. you can write log messages to console
and this won't mess with your progress bars and spinners.

> [**Read more**](live-output)
