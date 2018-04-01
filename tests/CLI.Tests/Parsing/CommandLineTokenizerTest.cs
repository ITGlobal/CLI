using ITGlobal.CommandLine.Parsing.Impl;
using Xunit;

namespace ITGlobal.CommandLine.Parsing
{
    public class CommandLineTokenizerTest
    {
        #region POSIX

        [Fact]
        public void Parse_empty_args_posix_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.PosixNotation);
            Assert.Empty(tokens);
        }

        [Fact]
        public void Parse_plain_args_posix_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.PosixNotation, "-c", "--x", "foobar", "test me");
            Assert.Equal(4, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[1], CommandLineTokenType.LongName, "x");
            AssertToken(tokens[2], CommandLineTokenType.Value, "foobar");
            AssertToken(tokens[3], CommandLineTokenType.Value, "test me");
        }

        [Fact]
        public void Parse_args_with_separator_posix_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.PosixNotation, "-c", "--x", "foobar", "--", "test me", "--x");
            Assert.Equal(5, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[1], CommandLineTokenType.LongName, "x");
            AssertToken(tokens[2], CommandLineTokenType.Value, "foobar");
            AssertToken(tokens[3], CommandLineTokenType.Value, "test me");
            AssertToken(tokens[4], CommandLineTokenType.Value, "--x");
        }

        [Fact]
        public void Parse_merged_short_options_posix_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.PosixNotation, "-cx", "foobar");
            Assert.Equal(3, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[1], CommandLineTokenType.ShortName, "x");
            AssertToken(tokens[2], CommandLineTokenType.Value, "foobar");
        }
        
        #endregion

        #region Windows

        [Fact]
        public void Parse_empty_args_windows_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.WindowsNotation);
            Assert.Empty(tokens);
        }

        [Fact]
        public void Parse_plain_args_windows_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.WindowsNotation, "/c", "/xxx", "foobar", "--test me");
            Assert.Equal(4, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[1], CommandLineTokenType.LongName, "xxx");
            AssertToken(tokens[2], CommandLineTokenType.Value, "foobar");
            AssertToken(tokens[3], CommandLineTokenType.Value, "--test me");
        }

        [Fact]
        public void Parse_args_with_separator_windows_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.WindowsNotation, "/c", "/xxx", "foobar", "--", "test me", "/x");
            Assert.Equal(6, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[1], CommandLineTokenType.LongName, "xxx");
            AssertToken(tokens[2], CommandLineTokenType.Value, "foobar");
            AssertToken(tokens[3], CommandLineTokenType.Value, "--");
            AssertToken(tokens[4], CommandLineTokenType.Value, "test me");
            AssertToken(tokens[5], CommandLineTokenType.ShortName, "x");
        }

        [Fact]
        public void Parse_merged_short_options_windows_notation()
        {
            var tokens = CommandLineTokenizer.Tokenize(CliParserFlags.WindowsNotation, "/cx", "foobar");
            Assert.Equal(2, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.LongName, "cx");
            AssertToken(tokens[1], CommandLineTokenType.Value, "foobar");
        }

        #endregion

        #region Separated values

        [Theory]
        [InlineData(Notation.Windows)]
        [InlineData(Notation.Posix)]
        public void Parse_arguments_with_colon_separated_values(Notation notation)
        {
            var flags = notation == Notation.Posix ? CliParserFlags.PosixNotation : CliParserFlags.WindowsNotation;
            var args = notation == Notation.Posix
                ? new[] {"-c:yyy", "--xxx:foo", "bar", "test me"}
                : new[] {"/c:yyy", "/xxx:foo", "bar", "test me"};

            var tokens = CommandLineTokenizer.Tokenize(flags | CliParserFlags.ColonSeparatedValues, args);
            Assert.Equal(6, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[1], CommandLineTokenType.Value, "yyy");
            AssertToken(tokens[2], CommandLineTokenType.LongName, "xxx");
            AssertToken(tokens[3], CommandLineTokenType.Value, "foo");
            AssertToken(tokens[4], CommandLineTokenType.Value, "bar");
            AssertToken(tokens[5], CommandLineTokenType.Value, "test me");
        }

        [Theory]
        [InlineData(Notation.Windows)]
        [InlineData(Notation.Posix)]
        public void Parse_arguments_with_equality_sign_separated_values(Notation notation)
        {
            var flags = notation == Notation.Posix ? CliParserFlags.PosixNotation : CliParserFlags.WindowsNotation;
            var args = notation == Notation.Posix
                ? new[] {"-c=yyy", "--xxx=foo", "bar", "test me"}
                : new[] {"/c=yyy", "/xxx=foo", "bar", "test me"};

            var tokens = CommandLineTokenizer.Tokenize(flags | CliParserFlags.EqualitySignSeparatedValues, args);
            Assert.Equal(6, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[1], CommandLineTokenType.Value, "yyy");
            AssertToken(tokens[2], CommandLineTokenType.LongName, "xxx");
            AssertToken(tokens[3], CommandLineTokenType.Value, "foo");
            AssertToken(tokens[4], CommandLineTokenType.Value, "bar");
            AssertToken(tokens[5], CommandLineTokenType.Value, "test me");
        }

        [Fact]
        public void Parse_mixed_style_arguments()
        {
            var flags = CliParserFlags.PosixNotation |
                        CliParserFlags.WindowsNotation |
                        CliParserFlags.ColonSeparatedValues |
                        CliParserFlags.EqualitySignSeparatedValues;
            var args =  new[]
            {
                "-a", "1", "-b:2", "-c=3", "/d", "4", "/e:5", "/f:6",
                "--aaa", "1", "--bbb:2", "--ccc=3", "/ddd", "4", "/eee:5", "/fff:6"
            };

            var tokens = CommandLineTokenizer.Tokenize(flags, args);
            Assert.Equal(24, tokens.Length);

            AssertToken(tokens[0], CommandLineTokenType.ShortName, "a");
            AssertToken(tokens[1], CommandLineTokenType.Value, "1");
            AssertToken(tokens[2], CommandLineTokenType.ShortName, "b");
            AssertToken(tokens[3], CommandLineTokenType.Value, "2");
            AssertToken(tokens[4], CommandLineTokenType.ShortName, "c");
            AssertToken(tokens[5], CommandLineTokenType.Value, "3");

            AssertToken(tokens[6], CommandLineTokenType.ShortName, "d");
            AssertToken(tokens[7], CommandLineTokenType.Value, "4");
            AssertToken(tokens[8], CommandLineTokenType.ShortName, "e");
            AssertToken(tokens[9], CommandLineTokenType.Value, "5");
            AssertToken(tokens[10], CommandLineTokenType.ShortName, "f");
            AssertToken(tokens[11], CommandLineTokenType.Value, "6");


            AssertToken(tokens[12], CommandLineTokenType.LongName, "aaa");
            AssertToken(tokens[13], CommandLineTokenType.Value, "1");
            AssertToken(tokens[14], CommandLineTokenType.LongName, "bbb");
            AssertToken(tokens[15], CommandLineTokenType.Value, "2");
            AssertToken(tokens[16], CommandLineTokenType.LongName, "ccc");
            AssertToken(tokens[17], CommandLineTokenType.Value, "3");

            AssertToken(tokens[18], CommandLineTokenType.LongName, "ddd");
            AssertToken(tokens[19], CommandLineTokenType.Value, "4");
            AssertToken(tokens[20], CommandLineTokenType.LongName, "eee");
            AssertToken(tokens[21], CommandLineTokenType.Value, "5");
            AssertToken(tokens[22], CommandLineTokenType.LongName, "fff");
            AssertToken(tokens[23], CommandLineTokenType.Value, "6");
        }

        [Fact]
        public void Equality_sign_takes_priority()
        {
            var flags = CliParserFlags.PosixNotation |
                        CliParserFlags.ColonSeparatedValues |
                        CliParserFlags.EqualitySignSeparatedValues;
            var args =  new[] { "--key=foo:bar" };

            var tokens = CommandLineTokenizer.Tokenize(flags, args);
            Assert.Equal(2, tokens.Length);
            
            AssertToken(tokens[0], CommandLineTokenType.LongName, "key");
            AssertToken(tokens[1], CommandLineTokenType.Value, "foo:bar");
        }

        #endregion

        public enum Notation
        {
            Windows,
            Posix
        }

        private void AssertToken(CommandLineToken token, CommandLineTokenType type, string value = null)
        {
            Assert.Equal(type, token.Type);
            if (value != null)
            {
                Assert.Equal(value, token.Value);
            }
        }
    }
}