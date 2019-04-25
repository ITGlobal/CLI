using System;
using System.Threading;

namespace ITGlobal.CommandLine.Example
{
    public static class LiveOutputDemo
    {
        public static void Run()
        {
            Console.WriteLine("BEFORE");

            using (ILiveOutput w = new LiveOutput())
            {
                w.Write("Running...".Colored());
                Thread.Sleep(250);

                for (var i = 0; i < 10; i++)
                {
                    w.Write($"Running ({i})...".Colored());

                    Console.Error.WriteLine("DURING (WL)");
                    Thread.Sleep(250);

                    Console.Error.Write("DURING...");
                    Thread.Sleep(250);
                    Console.Error.WriteLine("..OK");
                    Thread.Sleep(250);
                }

                w.WriteLine("Completed".Colored());
            }

            Console.WriteLine("AFTER");
        }
    }
}