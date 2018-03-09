using ITGlobal.CommandLine.Internals;

namespace ITGlobal.CommandLine.ProgressBars
{
    internal sealed class ProgressBarImpl : IProgressBar, ITerminalLockOwner
    {
        private readonly ITerminal _terminal;
        private readonly ITerminalLock _terminalLock;

        private readonly ProgressBarRenderer _renderer;

        private int _progress;
        private string _text;

        private bool _shouldCleanLine = true;

        public ProgressBarImpl(ITerminal terminal, ProgressBarRenderer renderer, string text)
        {
            _terminal = terminal;
            _terminalLock = terminal.Lock(this);
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
            ClearLine();
            _terminalLock.Dispose();
        }

        private void Draw()
        {
            var text = _text ?? "";

            var isCursorVisible = _terminalLock.Stdout.IsCursorVisible;
            _terminalLock.Stdout.IsCursorVisible = false;
            _terminalLock.Stdout.MoveCursor(0);

            _renderer.Render(_terminalLock.Stdout, text, _progress);
           
            _terminalLock.Stdout.IsCursorVisible = isCursorVisible;
            _shouldCleanLine = true;
        }

        private void ClearLine()
        {
            _terminalLock.Stdout.MoveCursor(0);
            for (var i = 0; i < _terminalLock.Stdout.WindowWidth - 1; i++)
            {
                _terminalLock.Stdout.Write(' ');
            }
            _terminalLock.Stdout.MoveCursor(0);
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