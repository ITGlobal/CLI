namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal sealed class CliContext : IHookCliContext
    {
        private readonly string[] _arguments;
        private bool _isLogoSuppressed;
        private readonly CliCommand _command;
        private int? _exitCode;

        public CliContext(bool isLogoSuppressed, CliCommand command, string[] arguments)
        {
            _isLogoSuppressed = isLogoSuppressed;
            _command = command;
            _arguments = arguments;
        }

        public bool IsLogoSuppressed => _isLogoSuppressed;
        public int? ExitCode => _exitCode;

        string[] ICliContext.UnconsumedArguments => _arguments;
        CliCommand ICliContext.Command => _command;

        void ICliContext.Break(int exitCode)
        {
            _exitCode = exitCode;
        }

        void IHookCliContext.SuppressLogo(bool suppress)
        {
            _isLogoSuppressed = suppress;
        }
    }
}