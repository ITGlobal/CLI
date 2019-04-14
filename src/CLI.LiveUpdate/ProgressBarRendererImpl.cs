using System;

namespace ITGlobal.CommandLine
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
        
        public override void Render(ITerminalOutput output, string text, int progress)
        {
            if (EnableLabel && !string.IsNullOrEmpty(text))
            {
                var i = 0;
                var labelWidth = Math.Min(text.Length, LabelWidth);
                using (output.WithColors(LabelFgColor, LabelBgColor))
                {
                    for (; i < labelWidth; i++)
                    {
                        output.Write(text[i]);
                    }
                    for (; i < LabelWidth; i++)
                    {
                        output.Write(' ');
                    }

                    output.Write(' ');
                }
            }

            if (FrameStart != null)
            {
                using (output.WithColors(FrameFgColor, FrameBgColor))
                {
                    output.Write(FrameStart.Value);
                }
            }

            var progressBarWidth = output.WindowWidth - 1;
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
            using (output.WithColors(FillFgColor, FillBgColor))
            {
                for (; j < fillWidth; j++)
                {
                    if (j == fillWidth - 1)
                    {
                        using (output.WithColors(FillEndFgColor, FillEndBgColor))
                        {
                            output.Write(FillEnd);
                        }
                    }
                    else
                    {
                        output.Write(Fill);
                    }
                }
            }

            using (output.WithColors(EmptyFgColor, EmptyBgColor))
            {
                for (; j < progressBarWidth; j++)
                {
                    output.Write(Empty);
                }
            }

            if (FrameEnd != null)
            {
                using (output.WithColors(FrameFgColor, FrameBgColor))
                {
                    output.Write(FrameEnd.Value);
                }
            }

            if (EnableProgress)
            {
                using (output.WithColors(ProgressFgColor, ProgressBgColor))
                {
                    output.Write(' ');
                    output.Write($"{progress,3:D}%");
                }
            }
        }
    }
}