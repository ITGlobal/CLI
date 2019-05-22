namespace ITGlobal.CommandLine.Parsing.Impl
{
    internal readonly struct CommandLineToken
    {
        private CommandLineToken(CommandLineTokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public CommandLineTokenType Type { get; }
        public string Value { get; }

        public static CommandLineToken CreateShortName(char c) 
            => new CommandLineToken(CommandLineTokenType.ShortName, new string(c, 1));
        public static CommandLineToken CreateLongName(string str) 
            => new CommandLineToken(CommandLineTokenType.LongName, str);
        public static CommandLineToken CreateValue(string str) 
            => new CommandLineToken(CommandLineTokenType.Value, str);
        
        public override string ToString() => $"{Type}('{Value}')";
    }
}