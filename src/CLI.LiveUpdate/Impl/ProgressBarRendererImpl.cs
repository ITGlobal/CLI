using System;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class ProgressBarRendererImpl : ProgressBarRenderer
    {
        public int LabelWidth { get; set; }

        public ConsoleColor? LabelFgColor { get; set; } = ConsoleColor.Yellow;
        public ConsoleColor? LabelBgColor { get; set; }

        public ConsoleColor? FrameFgColor { get; set; }
        public ConsoleColor? FrameBgColor { get; set; }

        public ConsoleColor? FillFgColor { get; set; } = ConsoleColor.Cyan;
        public ConsoleColor? FillBgColor { get; set; }

        public ConsoleColor? FillEndFgColor { get; set; } = ConsoleColor.Cyan;
        public ConsoleColor? FillEndBgColor { get; set; }

        public ConsoleColor? EmptyFgColor { get; set; }
        public ConsoleColor? EmptyBgColor { get; set; }

        public ConsoleColor? ProgressFgColor { get; set; } = ConsoleColor.Yellow;
        public ConsoleColor? ProgressBgColor { get; set; }

        public char? FrameStart { get; set; }
        public char Fill { get; set; }
        public char FillEnd { get; set; }
        public char Empty { get; set; }
        public char? FrameEnd { get; set; }

        public bool EnableLabel { get; set; }
        public bool EnableProgress { get; set; }
        
        public override void Render(ITerminalWriter output, string text, int progress)
        {
            if (EnableLabel && !string.IsNullOrEmpty(text))
            {
                var labelWidth = Math.Min(text.Length, LabelWidth);
                var label = text.Length <= labelWidth ? text : text.Substring(0, labelWidth);
                label = label.PadRight(labelWidth);

                output.Write(label.Colored(LabelFgColor, LabelBgColor));
                output.Write(' ');
            }

            if (FrameStart != null)
            {
                output.Write($"{FrameStart.Value}".Colored(FrameFgColor, FrameBgColor));
            }

            var progressBarWidth = Console.WindowWidth - 1;
            if (FrameStart != null)
            {
                progressBarWidth--;
            }
            if (FrameEnd != null)
            {
                progressBarWidth--;
            }
            if (EnableLabel)
            {
                progressBarWidth -= LabelWidth;
                progressBarWidth -= 1;
            }

            if (EnableProgress)
            {
                progressBarWidth -= 5;
            }

            var fillWidth = (int)Math.Ceiling(progressBarWidth * progress / 100f);
            var j = 0;
           
            {
                var sb = new StringBuilder();
                for (; j < fillWidth-1; j++)
                {
                    sb.Append(Fill);
                }
                output.Write(sb.ToString().Colored(FillFgColor, FillBgColor));
                output.Write($"{FillEnd}".Colored(FillEndFgColor, FillEndBgColor));
                j++;
            }

            {
                var sb = new StringBuilder();
                for (; j < progressBarWidth; j++)
                {
                    sb.Append(Empty);
                }
                output.Write(sb.ToString().Colored(EmptyFgColor, EmptyBgColor));
            }

            if (FrameEnd != null)
            {
                output.Write($"{FrameEnd.Value}".Colored(FrameFgColor, FrameBgColor));
            }

            if (EnableProgress)
            {
                output.Write(' ');
                output.Write($"{progress,3:D}%".Colored(ProgressFgColor, ProgressBgColor));
            }
        }
    }
}