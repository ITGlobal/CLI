using System;
using System.Threading;

namespace ITGlobal.CommandLine.Impl
{
    internal sealed class ProgressBarImpl : IProgressBar, ITerminalLockOwner
    {
        private readonly object _consoleLock = new object();
        private readonly ITerminalLock _terminal;

        private readonly ProgressBarRenderer _renderer;

        private int _progress;
        private string _text;

        public ProgressBarImpl(ProgressBarRenderer renderer, string text)
        {
            _terminal = Terminal.Lock(this);
            _text = text;
            _renderer = renderer;

            Draw();
        }

        /// <summary>
        ///     Updates process bar state
        /// </summary>
        /// <param name="progress">
        ///     Process value (in percent). Valid range is from 0 to 100.
        /// </param>
        /// <param name="text">
        ///     Text description. Will be trimmed if longer than <see cref="Consts.PROGRESS_BAR_LABEL_WIDTH"/>.
        /// </param>
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
            _terminal.ClearLine();
            _terminal.Dispose();
        }

        private void Draw()
        {
            var text = _text ?? "";

            _terminal.ClearLine();
            _terminal.Stderr.Write();

            _renderer.Render(_terminal.Stderr, text, _progress);
        }

        void ITerminalLockOwner.Begin()
        {
            Monitor.Enter(_consoleLock);
            _terminal.ClearLine();
        }

        void ITerminalLockOwner.WriteOutput(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var str = new ColoredString(new string(c, 1), foregroundColor, backgroundColor);
            _terminal.Stdout.Write(str);
        }

        void ITerminalLockOwner.WriteError(char c, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor)
        {
            var str = new ColoredString(new string(c, 1), foregroundColor, backgroundColor);
            _terminal.Stderr.Write(str);
        }

        void ITerminalLockOwner.End()
        {
            Draw();
            Monitor.Exit(_consoleLock);
        }
    }
}