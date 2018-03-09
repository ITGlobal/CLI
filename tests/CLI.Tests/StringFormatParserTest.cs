using ITGlobal.CommandLine.Internals;
using Xunit;

namespace ITGlobal.CommandLine
{
    public class StringFormatParserTest
    {
        [Fact]
        public void Parse_plain_text()
        {
            const string format = "Plain text input";
            var tokens = StringFormatParser.Tokenize(format, new object[0]);

            Assert.Single(tokens);
            AssertPlainText(tokens[0], format);
        }

        [Fact]
        public void Parse_escaped_braces_text()
        {
            const string format = "Plain {{text}} input {{end}}";
            const string excepted = "Plain {text} input {end}";
            var tokens = StringFormatParser.Tokenize(format, new object[0]);

            Assert.Single(tokens);
            AssertPlainText(tokens[0], excepted);
        }

        [Fact]
        public void Parse_fields()
        {
            const string format = "Plain {0}{1} {0} input";
            var arg1 = new object();
            var arg2 = new object();
            var tokens = StringFormatParser.Tokenize(format, new[] { arg1, arg2 });
            Assert.Equal(6, tokens.Length);

            AssertPlainText(tokens[0], "Plain ");
            AssertFieldText(tokens[1], arg1, 0, "");
            AssertFieldText(tokens[2], arg2, 0, "");
            AssertPlainText(tokens[3], " ");
            AssertFieldText(tokens[4], arg1, 0, "");
            AssertPlainText(tokens[5], " input");
        }

        [Theory]
        [InlineData("{0,12}", 12)]
        [InlineData("{0,    - 12}", -12)]
        public void Parse_padding(string input, int padding)
        {
            var arg = new object();
            var tokens = StringFormatParser.Tokenize(input, new[] { arg });
            Assert.Single(tokens);
            
            AssertFieldText(tokens[0], arg, padding, "");
        }

        [Theory]
        [InlineData("{0}", "")]
        [InlineData("{0:X04}", "X04")]
        public void Parse_format(string input, string format)
        {
            var arg = new object();
            var tokens = StringFormatParser.Tokenize(input, new[] { arg });
            Assert.Single(tokens);
            
            AssertFieldText(tokens[0], arg, 0, format);
        }

        [Theory]
        [InlineData("{0}", 0, "")]
        [InlineData("{0:X04}", 0, "X04")]
        [InlineData("{0,-4:X04}", -4, "X04")]
        [InlineData("{0:X04, -4}", 0, "X04, -4")]
        [InlineData("{0,-4}", -4, "")]
        public void Parse_format_and_padding(string input, int padding, string format)
        {
            var _ = string.Format("{0,-1:X1}", 1);
            var arg = new object();
            var tokens = StringFormatParser.Tokenize(input, new[] { arg });
            Assert.Single(tokens);
            
            AssertFieldText(tokens[0], arg, padding, format);
        }

        private static void AssertPlainText(StringFormatParser.Token token, string value)
        {
            Assert.Equal(StringFormatParser.TokenType.Plain, token.Type);
            Assert.Equal(value, token.Value);
        }

        private static void AssertFieldText(StringFormatParser.Token token, object value, int padding, string format)
        {
            Assert.Equal(StringFormatParser.TokenType.Field, token.Type);
            Assert.Equal(value, token.Value);
            Assert.Equal(padding, token.Padding);
            Assert.Equal(format, token.Format);
        }
    }
}
