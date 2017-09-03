using System;
using System.IO;
using System.Text;
using static ITGlobal.CommandLine.CLI;

// ReSharper disable once CheckNamespace
namespace ITGlobal.CommandLine
{
    internal sealed class ProgressBar : IProgressBar, ISafeTextWriterOwner
    {
        private readonly TextWriter _stdOut;
        private readonly TextWriter _stdErr;
        private readonly Encoding _outputEncoding;

        private readonly ProgressBarStyle _style;

        private int _progress;
        private string _text;

        private bool _shouldCleanLine = true;

        public ProgressBar(ProgressBarStyle style)
        {
            _stdOut = Console.Out;
            _stdErr = Console.Error;
            _outputEncoding = Console.OutputEncoding;

            _style = style;

            Console.SetOut(new SafeTextWriter(_stdOut, this));
            Console.SetError(new SafeTextWriter(_stdErr, this));

            Console.OutputEncoding = Encoding.UTF8;

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
            Console.OutputEncoding = _outputEncoding;
        }

        private void Draw()
        {
            var text = _text ?? "";

            var isCursorVisible = Console.CursorVisible;
            Console.CursorVisible = false;
            Console.CursorLeft = 0;

            if (_style.EnableLabel)
            {
                var i = 0;
                var labelWidth = Math.Min(text.Length, _style.LabelWidth);
                using (WithColors(_style.LabelFgColor, _style.LabelBgColor))
                {
                    for (; i < labelWidth; i++)
                    {
                        _stdOut.Write(text[i]);
                    }
                    for (; i < _style.LabelWidth; i++)
                    {
                        _stdOut.Write(' ');
                    }

                    _stdOut.Write(' ');
                }
            }

            if (_style.FrameStart != null)
            {
                using (WithColors(_style.FrameFgColor, _style.FrameBgColor))
                {
                    _stdOut.Write(_style.FrameStart.Value);
                }
            }

            var progressBarWidth = Console.WindowWidth - 1;
            if (_style.FrameStart != null)
            {
                progressBarWidth--;
            }
            if (_style.FrameEnd != null)
            {
                progressBarWidth--;
            }
            if (_style.EnableLabel)
            {
                progressBarWidth -= _style.LabelWidth;
                progressBarWidth -= 1;
            }

            if (_style.EnableProgress)
            {
                progressBarWidth -= 5;
            }

            var fillWidth = (int)Math.Ceiling(progressBarWidth * _progress / 100f);
            var j = 0;
            using (WithColors(_style.FillFgColor, _style.FillBgColor))
            {
                for (; j < fillWidth; j++)
                {
                    if (j == fillWidth - 1)
                    {
                        using (WithColors(_style.FillEndFgColor, _style.FillEndBgColor))
                        {
                            _stdOut.Write(_style.FillEnd);
                        }
                    }
                    else
                    {
                        _stdOut.Write(_style.Fill);
                    }
                }
            }

            using (WithColors(_style.EmptyFgColor, _style.EmptyBgColor))
            {
                for (; j < progressBarWidth; j++)
                {
                    _stdOut.Write(_style.Empty);
                }
            }

            if (_style.FrameEnd != null)
            {
                using (WithColors(_style.FrameFgColor, _style.FrameBgColor))
                {
                    _stdOut.Write(_style.FrameEnd.Value);
                }
            }

            if (_style.EnableProgress)
            {
                using (WithColors(_style.ProgressFgColor, _style.ProgressBgColor))
                {
                    _stdOut.Write(' ');
                    _stdOut.Write("{0,3:D}%", _progress);
                }
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