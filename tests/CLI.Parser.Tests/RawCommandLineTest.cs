using System.Linq;
using System.Security.Cryptography;
using ITGlobal.CommandLine.Parsing.Impl;
using Xunit;

namespace ITGlobal.CommandLine.Parsing
{
    public class RawCommandLineTest
    {
        // -c -x foo ---yes bar next value -z -z
        private CommandLineToken[] Tokens => new[]
        {
            CommandLineToken.CreateShortName('c'),
            CommandLineToken.CreateShortName('x'),
            CommandLineToken.CreateValue("foo"),
            CommandLineToken.CreateLongName("yes"),
            CommandLineToken.CreateValue("bar"),
            CommandLineToken.CreateValue("next"),
            CommandLineToken.CreateValue("value"),
            CommandLineToken.CreateShortName('z'),
            CommandLineToken.CreateShortName('z'),
        };

        // --cc --x foo ---yes bar next value --z --z
        private CommandLineToken[] TokensAlt => new[]
        {
            CommandLineToken.CreateLongName("c"),
            CommandLineToken.CreateLongName("x"),
            CommandLineToken.CreateValue("foo"),
            CommandLineToken.CreateLongName("yes"),
            CommandLineToken.CreateValue("bar"),
            CommandLineToken.CreateValue("next"),
            CommandLineToken.CreateValue("value"),
            CommandLineToken.CreateLongName("z"),
            CommandLineToken.CreateLongName("z"),
        };

        #region switch (short)

        [Fact]
        public void Consume_existing_short_switch()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.True(cli.ConsumeSwitch('c'));
            Assert.False(cli.ConsumeSwitch('c'));

            Assert.Equal(new[] { "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_non_existing_short_switch()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.False(cli.ConsumeSwitch('C'));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_existing_multi_short_switch()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.True(cli.ConsumeSwitch('z'));
            Assert.True(cli.ConsumeSwitch('z'));
            Assert.False(cli.ConsumeSwitch('z'));

            Assert.Equal(new[] { "-c", "-x", "--yes" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_long_switch_as_short_switch()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.False(cli.ConsumeSwitch('c'));

            Assert.Equal(new[] { "--c", "--x", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        #endregion

        #region switch (long)

        [Fact]
        public void Consume_existing_long_switch()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.True(cli.ConsumeSwitch("c"));
            Assert.False(cli.ConsumeSwitch("c"));

            Assert.Equal(new[] { "--x", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_non_existing_long_switch()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.False(cli.ConsumeSwitch("C"));

            Assert.Equal(new[] { "--c", "--x", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_existing_multi_long_switch()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.True(cli.ConsumeSwitch("z"));
            Assert.True(cli.ConsumeSwitch("z"));
            Assert.False(cli.ConsumeSwitch("z"));

            Assert.Equal(new[] { "--c", "--x", "--yes" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_short_switch_as_long_switch()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.False(cli.ConsumeSwitch("c"));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        #endregion

        #region option (short)

        [Fact]
        public void Consume_existing_short_option()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.Equal("foo", cli.ConsumeOption('x'));
            Assert.Null(cli.ConsumeOption('x'));

            Assert.Equal(new[] { "-c", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_non_existing_short_option()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.Null(cli.ConsumeOption('X'));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_existing_short_option_without_value()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.Null(cli.ConsumeOption('c'));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_existing_multi_short_option()
        {
            // -c -x foo --yes bar next value -z -z -f foo -f bar

            var tokens = Tokens.Concat(new[]
            {
                CommandLineToken.CreateShortName('f'),
                CommandLineToken.CreateValue("foo"),
                CommandLineToken.CreateShortName('f'),
                CommandLineToken.CreateValue("bar")
            }).ToArray();
            var cli = new RawCommandLine(tokens);
            Assert.Equal("foo", cli.ConsumeOption('f'));
            Assert.Equal("bar", cli.ConsumeOption('f'));
            Assert.Null(cli.ConsumeOption('f'));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_long_option_as_short_option()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.Null(cli.ConsumeOption('c'));

            Assert.Equal(new[] { "--c", "--x", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        #endregion

        #region option (long)

        [Fact]
        public void Consume_existing_long_option()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.Equal("foo", cli.ConsumeOption("x"));
            Assert.Null(cli.ConsumeOption("x"));

            Assert.Equal(new[] { "--c", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_non_existing_long_option()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.Null(cli.ConsumeOption("X"));

            Assert.Equal(new[] { "--c", "--x", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_existing_long_option_without_value()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.Null(cli.ConsumeOption("c"));

            Assert.Equal(new[] { "--c", "--x", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_existing_multi_long_option()
        {
            // --c --x foo ---yes bar next value --z --z --yes foo

            var tokens = TokensAlt.Concat(new[]
            {
                CommandLineToken.CreateLongName("yes"),
                CommandLineToken.CreateValue("foo")
            }).ToArray();
            var cli = new RawCommandLine(tokens);
            Assert.Equal("bar", cli.ConsumeOption("yes"));
            Assert.Equal("foo", cli.ConsumeOption("yes"));
            Assert.Null(cli.ConsumeOption("yes"));

            Assert.Equal(new[] { "--c", "--x", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_short_option_as_long_option()
        {
            var cli = new RawCommandLine(TokensAlt);
            Assert.Null(cli.ConsumeOption('c'));

            Assert.Equal(new[] { "--c", "--x", "--yes", "--z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        #endregion

        #region arguments

        [Fact]
        public void Consume_existing_positional_argument()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.Equal("foo", cli.ConsumeArgument(0));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_existing_positional_argument_few_times()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.Equal("foo", cli.ConsumeArgument(0));
            Assert.Equal("bar", cli.ConsumeArgument(0));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_non_existing_positional_argument()
        {
            var cli = new RawCommandLine(Tokens);
            Assert.Null(cli.ConsumeArgument(4));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        [Fact]
        public void Consume_last_positional_argument()
        { 
            // --c --x foo ---yes bar next value --z --z foo
            var tokens = Tokens.Concat(new[]
            {
                CommandLineToken.CreateValue("foo")
            }).ToArray();
            var cli = new RawCommandLine(tokens);
            Assert.Equal("foo", cli.ConsumeArgument(4));

            Assert.Equal(new[] { "-c", "-x", "--yes", "-z" }, cli.GetUnconsumedOptions());
            Assert.Equal(new[] { "foo", "bar", "next", "value" }, cli.GetUnconsumedArguments());
        }

        #endregion
    }
}