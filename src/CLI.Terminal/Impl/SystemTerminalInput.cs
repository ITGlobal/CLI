using System;
using System.IO;
using System.Text;

namespace ITGlobal.CommandLine.Impl
{
    /// <summary>
    ///     Terminal standard input wrapper
    /// </summary>
    internal sealed class SystemTerminalInput : ITerminalInput
    {
        private readonly TextReader _reader;

        public SystemTerminalInput(TextReader reader, bool isRedirected)
        {
            _reader = reader;
            IsRedirected = isRedirected;
        }

        /// <summary>
        ///     Returns true if standard input is redirected
        /// </summary>
        public bool IsRedirected { get; }

        /// <summary>
        ///     Standard input encoding
        /// </summary>
        public Encoding Encoding
        {
            get => Console.InputEncoding;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Console.InputEncoding = value;
            }
        }

        /// <summary>
        ///     Created a reader for standard input stream
        /// </summary>
        public TextReader CreateReader() => new StdinReader(_reader);

        /// <summary>
        ///     Attaches a temporary CtrlC/SIGTERM handler
        /// </summary>
        public IDisposable AttachCancelKeyHandler(CancelKeyHandler handler) => new CancelKeyHandlerToken(handler);

        /// <summary>
        ///     Reads a key from a standard input stream
        /// </summary>
        public ConsoleKeyInfo ReadKey(bool intercept = true) => Console.ReadKey(intercept);

        private sealed class StdinReader : TextReader
        {
            private readonly TextReader _reader;

            public StdinReader(TextReader reader)
            {
                _reader = reader;
            }

            public override int Peek() => _reader.Peek();

            public override int Read() => _reader.Read();

            public override string ReadLine() => _reader.ReadLine();

            public override int ReadBlock(char[] buffer, int index, int count) => _reader.ReadBlock(buffer, index, count);

            public override int Read(char[] buffer, int index, int count) => _reader.Read(buffer, index, count);

            public override string ReadToEnd() => _reader.ReadToEnd();
        }

        private sealed class CancelKeyHandlerToken : IDisposable
        {
            private readonly ConsoleCancelEventHandler _handler;

            public CancelKeyHandlerToken(CancelKeyHandler handler)
            {
                _handler = (_, e) =>
                {
                    var cancel = handler();
                    if (cancel)
                    {
                        e.Cancel = true;
                    }
                };

                Console.CancelKeyPress += _handler;
            }

            public void Dispose()
            {
                Console.CancelKeyPress -= _handler;
            }
        }
    }
}