using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITGlobal.CommandLine.Example
{
    public static class ComplexProgressBarDemo
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
                    progressBarRenderer = ProgressBarRenderer.Arrow(location: ProgressBarLocation.Trailing);
                    break;
                case Type.HashSign:
                    progressBarRenderer = ProgressBarRenderer.HashSign(location: ProgressBarLocation.Trailing);
                    break;
                case Type.Legacy:
                    progressBarRenderer = ProgressBarRenderer.Legacy(location: ProgressBarLocation.Trailing);
                    break;
                case Type.Shades:
                    progressBarRenderer = ProgressBarRenderer.Shades(location: ProgressBarLocation.Trailing);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            if (wipe)
            {
                Console.WriteLine("Will wipe out progress bar when completed");
            }
            using (var liveOutput = LiveOutputManager.Create(progressBarRenderer: progressBarRenderer))
            {
                liveOutput.WipeAfter(wipe);
                var tasks = CreatePullOperations(liveOutput).ToArray();

                Task.WaitAll(tasks);
            }
        }

        private static IEnumerable<Task> CreatePullOperations(ILiveOutputManager liveOutput)
        {
            yield return CreatePullOperation("1_9ff7e2e5", 4376987, liveOutput);
            yield return CreatePullOperation("2_815c6aed", 0001984, liveOutput);
            yield return CreatePullOperation("3_8566b259", 2945616, liveOutput);
            yield return CreatePullOperation("4_01c9fe45", 1151233, liveOutput);
            yield return CreatePullOperation("5_7cedccbc", 5472391, liveOutput);
        }

        private static Task CreatePullOperation(string hash, int size, ILiveOutputManager liveOutput)
        {
            const int textWidth = 40;
            var bar = liveOutput.CreateProgressBar($"[{hash}] waiting".PadRight(textWidth));

            return Task.Run(() =>
            {
                for (var i = 0; i < size; i += 128 * 1024)
                {
                    var p = (int)(i * 100f / size);
                    bar.Write(p, $"[{hash}] downloading".PadRight(textWidth));
                    Thread.Sleep(100);
                }

                for (var i = 0; i < size; i += 128 * 1024)
                {
                    var p = (int)(i * 100f / size);
                    bar.Write(p, $"[{hash}] extracting".PadRight(textWidth));
                    Thread.Sleep(100);
                }

                bar.Complete($"[{hash}] download completed".PadRight(textWidth));
            });
        }
    }
}