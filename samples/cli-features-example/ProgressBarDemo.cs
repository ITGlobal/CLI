using System;
using System.Threading;

namespace ITGlobal.CommandLine.Example
{
    public static class ProgressBarDemo
    {
        public enum Type
        {
            Arrow,
            HashSign,
            Legacy,
            Shades,
        }

        public static void Run(Type type, bool wipe)
        {
            IProgressBarRenderer progressBarRenderer;

            switch (type)
            {
                case Type.Arrow:
                    progressBarRenderer = ProgressBarRenderer.Arrow();
                    break;
                case Type.HashSign:
                    progressBarRenderer = ProgressBarRenderer.HashSign();
                    break;
                case Type.Legacy:
                    progressBarRenderer = ProgressBarRenderer.Legacy();
                    break;
                case Type.Shades:
                    progressBarRenderer = ProgressBarRenderer.Shades();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            if (wipe)
            {
                Console.WriteLine("Will wipe out progress bar when completed");
            }
            Console.WriteLine("--- BEFORE DEMO ---");

            using (var liveOutput = LiveOutputManager.Create(progressBarRenderer: progressBarRenderer))
            {
                liveOutput.WipeAfter(wipe);
                var bar = liveOutput.CreateProgressBar("Downloading...");

                for (var i = 0; i < 100; i += 5)
                {
                    bar.Write(i);

                    Thread.Sleep(100);

                    if (i % 10 == 0)
                    {
                        Console.WriteLine($"[{DateTime.UtcNow:s}] DEBUG #{i + 1} log event (see log file for details)");
                    }
                }
            }

            Console.WriteLine("--- AFTER DEMO ---");
        }
    }
}