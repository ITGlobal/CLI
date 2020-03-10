using System;
using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using Xunit;

namespace ITGlobal.CommandLine.Parsing
{
    public sealed class SimpleCliParserTest
    {
        #region helpers

        private ISimpleCliParser CreateParser()
        {
            const CliParserFlags testOptions = CliParserFlags.PosixNotation;
            var parser = CliParser.NewSimpleParser(flags: testOptions, disableHelpSwitch: true);
            return parser;
        }

        #endregion

        #region common tests

        [Fact]
        public void Default_executable_name()
        {
            var parser = (SimpleCliParser)CreateParser();
            Assert.Equal("testhost", parser.ExecutableName);
        }

        [Fact]
        public void At_least_one_notation_should_be_specified()
        {
            Assert.ThrowsAny<Exception>(() => CliParser.NewSimpleParser(flags: 0));
        }

        #endregion

        #region Switch tests

        [Fact]
        public void Switch_not_set()
        {
            var parser = CreateParser();
            var sw = parser.Switch('s', "switch");
            Assert.Equal(0, parser.Parse().Run());
            Assert.False(sw);
        }

        [Fact]
        public void Switch_set_by_short_name()
        {
            var parser = CreateParser();
            var sw = parser.Switch('s', "switch");
            Assert.Equal(0, parser.Parse("-s").Run());
            Assert.True(sw);
        }

        [Fact]
        public void Switch_set_by_long_name()
        {
            var parser = CreateParser();
            var sw = parser.Switch('s', "switch");
            Assert.Equal(0, parser.Parse("--switch").Run());
            Assert.True(sw);
        }

        [Fact]
        public void Switch_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var sw = parser.Switch('s', "switch");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--s").Run());
            Assert.False(sw);
        }

        #endregion

        #region Repeatable switch tests

        [Fact]
        public void Repeatable_switch_not_set()
        {
            var parser = CreateParser();
            var sw = parser.RepeatableSwitch('s', "switch");
            Assert.Equal(0, parser.Parse().Run());
            Assert.False(sw);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Repeatable_switch_set_by_short_name(int count)
        {
            var parser = CreateParser();
            var sw = parser.RepeatableSwitch('s', "switch");
            var args = Enumerable.Range(0, count).Select(_ => "-s").ToArray();
            Assert.Equal(0, parser.Parse(args).Run());
            Assert.Equal(count, sw.RepeatCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Repeatable_switch_set_by_long_name(int count)
        {
            var parser = CreateParser();
            var sw = parser.RepeatableSwitch('s', "switch");
            var args = Enumerable.Range(0, count).Select(_ => "--switch").ToArray();
            Assert.Equal(0, parser.Parse(args).Run());
            Assert.Equal(count, sw.RepeatCount);
        }

        [Fact]
        public void Repeatable_switch_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var sw = parser.RepeatableSwitch('s', "switch");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--s").Run());
            Assert.False(sw);
        }

        #endregion

        #region Option tests

        [Fact]
        public void Option_not_set()
        {
            var parser = CreateParser();
            var option = parser.Option('o', "option");
            Assert.Equal(0, parser.Parse().Run());
            Assert.False(option);
        }

        [Fact]
        public void Option_set_by_short_name_without_value()
        {
            var parser = CreateParser();
            var option = parser.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("-o").Run());
            Assert.False(option);
        }

        [Fact]
        public void Option_set_by_short_name()
        {
            var parser = CreateParser();
            var option = parser.Option('o', "option");
            Assert.Equal(0, parser.Parse("-o", "value").Run());
            Assert.True(option);
            Assert.Equal("value", option);
        }

        [Fact]
        public void Option_set_by_long_name_without_value()
        {
            var parser = CreateParser();
            var option = parser.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--option").Run());
            Assert.False(option);
        }

        [Fact]
        public void Option_set_by_long_name()
        {
            var parser = CreateParser();
            var option = parser.Option('o', "option");
            Assert.Equal(0, parser.Parse("--option", "value").Run());
            Assert.True(option);
            Assert.Equal("value", option);
        }

        [Fact]
        public void Option_set_by_one_char_long_name_without_value()
        {
            var parser = CreateParser();
            var option = parser.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--o").Run());
            Assert.False(option);
        }

        [Fact]
        public void Option_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var option = parser.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--o", "value").Run());
            Assert.False(option);
        }

        #endregion

        #region repeatable option tests

        [Fact]
        public void Repeatable_option_not_set()
        {
            var parser = CreateParser();
            var option = parser.RepeatableOption('o', "option");
            Assert.Equal(0, parser.Parse().Run());
            Assert.False(option);
        }

        [Fact]
        public void Repeatable_option_set_by_short_name_without_value()
        {
            var parser = CreateParser();
            var option = parser.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("-o").Run());
            Assert.False(option);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Repeatable_option_set_by_short_name(int count)
        {
            var parser = CreateParser();
            var option = parser.RepeatableOption('o', "option");
            var args = Enumerable.Range(0, count)
                .Select(x => new[] {"-o", $"value_{x}"})
                .SelectMany(_ => _)
                .ToArray();

            Assert.Equal(0, parser.Parse(args).Run());
            Assert.True(option);
            Assert.Equal(count, option.Values.Length);
            for (var i = 0; i < count; i++)
            {
                Assert.Equal($"value_{i}", option.Values[i]);
            }
        }

        [Fact]
        public void Repeatable_option_set_by_long_name_without_value()
        {
            var parser = CreateParser();
            var option = parser.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--option").Run());
            Assert.False(option);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Repeatable_option_set_by_long_name(int count)
        {
            var parser = CreateParser();
            var option = parser.RepeatableOption('o', "option");
            var args = Enumerable.Range(0, count)
                .Select(x => new[] { "--option", $"value_{x}" })
                .SelectMany(_ => _)
                .ToArray();

            Assert.Equal(0, parser.Parse(args).Run());
            Assert.True(option);
            Assert.Equal(count, option.Values.Length);
            for (var i = 0; i < count; i++)
            {
                Assert.Equal($"value_{i}", option.Values[i]);
            }
        }

        [Fact]
        public void Repeatable_option_set_by_one_char_long_name_without_value()
        {
            var parser = CreateParser();
            var option = parser.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--o").Run());
            Assert.False(option);
        }

        [Fact]
        public void Repeatable_option_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var option = parser.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("--o", "value").Run());
            Assert.False(option);
        }

        #endregion

        #region Argument tests

        [Fact]
        public void Argument_not_set()
        {
            var parser = CreateParser();
            var arg = parser.Argument("arg");
            Assert.Equal(0, parser.Parse().Run());
            Assert.False(arg.IsSet);
        }

        [Fact]
        public void Argument_is_set()
        {
            var parser = CreateParser();
            var arg = parser.Argument("arg");
            Assert.Equal(0, parser.Parse("value").Run());
            Assert.True(arg.IsSet);
            Assert.Equal("value", arg.Value);
        }

        [Fact]
        public void Required_argument_not_set()
        {
            var parser = CreateParser();
            parser.Argument("arg").Required();
            Assert.Equal(ExitCodes.InvalidInput, parser.Parse().Run());
        }

        [Fact]
        public void Two_arguments()
        {
            var parser = CreateParser();
            var arg1 = parser.Argument("arg1");
            var arg2 = parser.RepeatableArgument("arg2");
            Assert.Equal(0, parser.Parse("foo", "bar").Run());
            Assert.True(arg1.IsSet);
            Assert.Equal("foo", arg1.Value);;

            Assert.True(arg2.IsSet);
            Assert.Equal("bar", arg2.Values[0]);;
        }

        #endregion

        #region Repeatable rgument tests

        [Fact]
        public void Repeatable_argument_not_set()
        {
            var parser = CreateParser();
            var arg = parser.RepeatableArgument("arg");
            Assert.Equal(0, parser.Parse().Run());
            Assert.False(arg.IsSet);
        }

        [Fact]
        public void Repeatable_argument_is_set_once()
        {
            var parser = CreateParser();
            var arg = parser.RepeatableArgument("arg");
            Assert.Equal(0, parser.Parse("value").Run());
            Assert.True(arg.IsSet);
            Assert.Single(arg.Values);
            Assert.Equal("value", arg.Values[0]);
        }

        [Fact]
        public void Repeatable_argument_is_set_few_times()
        {
            var parser = CreateParser();
            var arg = parser.RepeatableArgument("arg");
            Assert.Equal(0, parser.Parse("value1", "value2").Run());
            Assert.True(arg.IsSet);
            Assert.Equal(2, arg.Values.Length);
            Assert.Equal("value1", arg.Values[0]);
            Assert.Equal("value2", arg.Values[1]);
        }

        [Fact]
        public void Required_repeatable_argument_not_set()
        {
            var parser = CreateParser();
            parser.RepeatableArgument("arg").Required();
            Assert.Equal(ExitCodes.InvalidInput, parser.Parse().Run());
        }

        #endregion
    }
}