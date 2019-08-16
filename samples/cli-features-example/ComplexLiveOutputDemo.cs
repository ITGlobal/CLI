using System;
using System.Threading;

namespace ITGlobal.CommandLine.Example
{
    public static class ComplexLiveOutputDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- BEFORE DEMO ---");

            using (var liveOutput = LiveOutputManager.Create())
            {
                var w1 = liveOutput.CreateText("Downloading...".Yellow());
                var w2 = liveOutput.CreateText("Writing...".Yellow());

                Thread.Sleep(250);

                for (var i = 0; i < 125; i++)
                {
                    if (i < 100)
                    {
                        w1.Write($"Downloading... {i}%".Yellow());
                    }
                    else
                    {
                        w1.Write("Download completed".Yellow());
                    }

                    if (i >= 25)
                    {
                        w2.Write($"Writing... {i-25}%".Yellow());
                    }

                    Thread.Sleep(100);

                    if (i % 10 == 0)
                    {
                        Console.WriteLine($"[{DateTime.UtcNow:s}] DEBUG #{i+1} log event (see log file for details)");
                    }
                }
                
                w1.Write("Download completed, see output directory".Green());
                w2.WipeAfter();
                w1.WipeAfter(false);
            }

            Console.WriteLine("--- AFTER DEMO ---");
        }
    }
}