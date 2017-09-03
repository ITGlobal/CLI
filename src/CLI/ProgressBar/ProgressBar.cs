using System;
using System.IO;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class ProgressBar : IProgressBar, ISafeTextWriterOwner
    {
        private readonly TextWriter _stdOut;
        private readonly TextWriter _stdErr;

        private int _progress;
        private string _text;

        private bool _shouldCleanLine = true;

        public ProgressBar()
        {
            _stdOut = Console.Out;
            _stdErr = Console.Error;

            Console.SetOut(new SafeTextWriter(_stdOut, this));
            Console.SetError(new SafeTextWriter(_stdErr, this));

            Draw();
        }

        public void SetState(int? progress = null, string text = null)
        {
            if (progress != null)
            {
                _progress = progress.Value;

                if (_progress < 0)
                {
                    _progress = 0;
                }

                if (_progress > 100)
                {
                    _progress = 100;
                }
            }

            if (text != null)
            {
                _text = text;
            }

            Draw();
        }

        public void Dispose()
        {
            ClearLine();
            Console.SetOut(_stdOut);
            Console.SetError(_stdErr);
        }

        private void Draw()
        {
            var text = _text ?? "";

            var isCursorVisible = Console.CursorVisible;
            Console.CursorVisible = false;
            Console.CursorLeft = 0;

            var i = 0;
            var labelWidth = Math.Min(text.Length, PROGRESS_BAR_LABEL_WIDTH);
            using (WithForeground(ConsoleColor.Yellow))
            {
                for (; i < labelWidth; i++)
                {
                    _stdOut.Write(text[i]);
                }
                for (; i < PROGRESS_BAR_LABEL_WIDTH; i++)
                {
                    _stdOut.Write(' ');
                }
            }

            _stdOut.Write(' ');
            _stdOut.Write('[');

            var progressBarWidth = Console.WindowWidth - PROGRESS_BAR_LABEL_WIDTH - 3 - 6;

            var fillWidth = (int)Math.Ceiling(progressBarWidth * _progress / 100f);
            var j = 0;
            using (WithForeground(ConsoleColor.Cyan))
            {
                for (; j < fillWidth; j++)
                {
                    _stdOut.Write('#');
                }
            }
            for (; j < progressBarWidth; j++)
            {
                _stdOut.Write(' ');
            }

            _stdOut.Write(']');
            _stdOut.Write(' ');
            using (WithForeground(ConsoleColor.Yellow))
            {
                _stdOut.Write("{0,3:D}%", _progress);
            }

            Console.CursorVisible = isCursorVisible;
            _shouldCleanLine = true;
        }

        private void ClearLine()
        {
            Console.CursorLeft = 0;
            for (var i = 0; i < Console.WindowWidth - 1; i++)
            {
                _stdOut.Write(' ');
            }
            Console.CursorLeft = 0;
        }

        public void BeginPrint()
        {
            if (_shouldCleanLine)
            {
                ClearLine();
                _shouldCleanLine = false;
            }
        }

        public void EndPrint() { }

        public void Redraw() => Draw();
    }
}