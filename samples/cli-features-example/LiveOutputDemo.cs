using System;
using System.Threading;

namespace ITGlobal.CommandLine.Example
{
    public static class LiveOutputDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- BEFORE DEMO ---");

            using (var liveOutput = LiveOutputManager.Create())
            {
                var w = liveOutput.CreateText("Downloading...".Yellow());
                w.Write("Running...".Yellow());
                Thread.Sleep(250);

                for (var i = 0; i < 10; i++)
                {
                    w.Write($"Running ({i})...".Yellow());

                    Console.WriteLine($"[{DateTime.UtcNow:s}] DEBUG #{i + 1} log event (see log file for details)");
                    Thread.Sleep(250);
                }

                w.Complete("Completed".Green());
            }

            Console.WriteLine("--- AFTER DEMO ---");
        }
    }
}