using System;
using System.Threading;

namespace ITGlobal.CommandLine.Example
{
    public static class SpinnerDemo
    {
        public enum Type
        {
            RotatingBar,
            RotatingAngle,
            LeftToRightArrow,
            RightToLeftArrow,
            BothDirectionArrow,
            BouncingBall,
        }

        public static void Run(Type type)
        {
            ISpinnerRenderer renderer;
            switch (type)
            {
                case Type.RotatingBar:
                    renderer = SpinnerRenderer.RotatingBar();
                    break;
                case Type.RotatingAngle:
                    renderer = SpinnerRenderer.RotatingAngle();
                    break;
                case Type.LeftToRightArrow:
                    renderer = SpinnerRenderer.Arrow(direction: SpinnerArrowDirection.LeftToRight);
                    break;
                case Type.RightToLeftArrow:
                    renderer = SpinnerRenderer.Arrow(direction: SpinnerArrowDirection.RightToLeft);
                    break;
                case Type.BothDirectionArrow:
                    renderer = SpinnerRenderer.Arrow(direction: SpinnerArrowDirection.Both);
                    break;
                case Type.BouncingBall:
                    renderer = SpinnerRenderer.BouncingBall();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            Console.WriteLine("--- BEFORE DEMO ---");

            using (var liveOutput = LiveOutputManager.Create(spinnerRenderer: renderer))
            {
                var w = liveOutput.CreateSpinner();

                w.Write("Sending request...".Yellow());

                for (var i = 0; i < 4; i++)
                {
                    Console.WriteLine($"[{DateTime.UtcNow:s}] DEBUG #{i + 1} log event (see log file for details)");
                    Thread.Sleep(1000);
                }

                w.Write("Receiving response...".Yellow());
                for (var i = 0; i < 4; i++)
                {
                    Console.WriteLine($"[{DateTime.UtcNow:s}] DEBUG #{i + 1} log event (see log file for details)");
                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine("--- AFTER DEMO ---");
        }
    }
}