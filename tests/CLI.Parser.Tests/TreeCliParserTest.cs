using System;
using System.Linq;
using ITGlobal.CommandLine.Parsing.Impl;
using Xunit;

namespace ITGlobal.CommandLine.Parsing
{
    public sealed class TreeCliParserTest
    {
        #region helpers

        private ITreeCliParser CreateParser()
        {
            const CliParserFlags testOptions = CliParserFlags.PosixNotation;
            var parser = CliParser.NewTreeParser(
                flags: testOptions,
                disableHelpSwitch: true,
                disableHelpCommand: true,
                disableImplicitHelp: true
            );
            return parser;
        }

        #endregion

        #region common tests

        [Fact]
        public void Default_executable_name()
        {
            var parser = (TreeCliParser)CreateParser();
            Assert.Equal("testhost", parser.ExecutableName);
        }

        [Fact]
        public void At_least_one_notation_should_be_specified()
        {
            Assert.ThrowsAny<Exception>(() => CliParser.NewTreeParser(flags: 0));
        }

        #endregion

        #region switch tests

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

        #region repeatable switch tests

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

        #region option tests

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
                .Select(x => new[] { "-o", $"value_{x}" })
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

        #region argument tests

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

        #endregion

        #region repeatable argument tests

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

        #region command and subcommand tests

        [Fact]
        public void Command_level_1()
        {
            var parser = CreateParser();

            var rootTriggered = false;
            parser.OnExecute(_ => { rootTriggered = true; });

            var cmd1Triggered = false;
            var cmd1 = parser.Command("cmd1");
            cmd1.OnExecute(_ => { cmd1Triggered = true; });

            var cmd2Triggered = false;
            var cmd2 = parser.Command("cmd2");
            cmd2.OnExecute(_ => { cmd2Triggered = true; });

            Assert.Equal(0, parser.Parse("cmd1").Run());
            Assert.False(rootTriggered);
            Assert.True(cmd1Triggered);
            Assert.False(cmd2Triggered);
        }

        [Fact]
        public void Command_level_2()
        {
            var parser = CreateParser();

            var rootTriggered = false;
            parser.OnExecute(_ => { rootTriggered = true; });

            var cmd1Triggered = false;
            var cmd1 = parser.Command("cmd1");
            cmd1.OnExecute(_ => { cmd1Triggered = true; });

            var cmd2Triggered = false;
            var cmd2 = parser.Command("cmd2");
            cmd2.OnExecute(_ => { cmd2Triggered = true; });

            var cmd1Sub1Triggered = false;
            cmd1.Command("cmd1").OnExecute(_ => { cmd1Sub1Triggered = true; });

            var cmd1Sub2Triggered = false;
            cmd1.Command("cmd2").OnExecute(_ => { cmd1Sub2Triggered = true; });

            Assert.Equal(0, parser.Parse("cmd1", "cmd1").Run());
            Assert.False(rootTriggered);
            Assert.False(cmd1Triggered);
            Assert.False(cmd2Triggered);
            Assert.True(cmd1Sub1Triggered);
            Assert.False(cmd1Sub2Triggered);
        }

        #endregion

        #region command switch tests

        [Fact]
        public void Command_switch_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.Switch('s', "switch");
            Assert.Equal(0, parser.Parse("cmd").Run());
            Assert.False(sw);
        }

        [Fact]
        public void Command_switch_set_by_short_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.Switch('s', "switch");
            Assert.Equal(0, parser.Parse("cmd", "-s").Run());
            Assert.True(sw);
        }

        [Fact]
        public void Command_switch_set_by_long_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.Switch('s', "switch");
            Assert.Equal(0, parser.Parse("cmd", "--switch").Run());
            Assert.True(sw);
        }

        [Fact]
        public void Command_switch_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.Switch('s', "switch");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--s").Run());
            Assert.False(sw);
        }

        #endregion

        #region command repeatable switch tests

        [Fact]
        public void Command_repeatable_switch_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.RepeatableSwitch('s', "switch");
            Assert.Equal(0, parser.Parse("cmd").Run());
            Assert.False(sw);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Command_repeatable_switch_set_by_short_name(int count)
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.RepeatableSwitch('s', "switch");
            var args = new[] { "cmd" }.Concat(Enumerable.Range(0, count).Select(_ => "-s")).ToArray();
            Assert.Equal(0, parser.Parse(args).Run());
            Assert.Equal(count, sw.RepeatCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Command_rRepeatable_switch_set_by_long_name(int count)
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.RepeatableSwitch('s', "switch");
            var args = new[] { "cmd" }.Concat(Enumerable.Range(0, count).Select(_ => "--switch")).ToArray();
            Assert.Equal(0, parser.Parse(args).Run());
            Assert.Equal(count, sw.RepeatCount);
        }

        [Fact]
        public void Command_repeatable_switch_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var sw = cmd.RepeatableSwitch('s', "switch");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--s").Run());
            Assert.False(sw);
        }

        #endregion

        #region command option tests

        [Fact]
        public void Command_option_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.Option('o', "option");
            Assert.Equal(0, parser.Parse("cmd").Run());
            Assert.False(option);
        }

        [Fact]
        public void Command_option_set_by_short_name_without_value()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "-o").Run());
            Assert.False(option);
        }

        [Fact]
        public void Command_option_set_by_short_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.Option('o', "option");
            Assert.Equal(0, parser.Parse("cmd", "-o", "value").Run());
            Assert.True(option);
            Assert.Equal("value", option);
        }

        [Fact]
        public void Command_option_set_by_long_name_without_value()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--option").Run());
            Assert.False(option);
        }

        [Fact]
        public void Command_option_set_by_long_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.Option('o', "option");
            Assert.Equal(0, parser.Parse("cmd", "--option", "value").Run());
            Assert.True(option);
            Assert.Equal("value", option);
        }

        [Fact]
        public void Command_option_set_by_one_char_long_name_without_value()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--o").Run());
            Assert.False(option);
        }

        [Fact]
        public void Command_option_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.Option('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--o", "value").Run());
            Assert.False(option);
        }

        #endregion

        #region command repeatable option tests

        [Fact]
        public void Command_repeatable_option_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.RepeatableOption('o', "option");
            Assert.Equal(0, parser.Parse("cmd").Run());
            Assert.False(option);
        }

        [Fact]
        public void Command_repeatable_option_set_by_short_name_without_value()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "-o").Run());
            Assert.False(option);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Command_repeatable_option_set_by_short_name(int count)
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.RepeatableOption('o', "option");
            var args =
                new[] { "cmd" }.Concat(
                        Enumerable.Range(0, count)
                            .Select(x => new[] { "-o", $"value_{x}" })
                            .SelectMany(_ => _)
                    )
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
        public void Command_repeatable_option_set_by_long_name_without_value()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--option").Run());
            Assert.False(option);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Command_repeatable_option_set_by_long_name(int count)
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.RepeatableOption('o', "option");
            var args =
                new[] { "cmd" }.Concat(
                        Enumerable.Range(0, count)
                            .Select(x => new[] { "--option", $"value_{x}" })
                            .SelectMany(_ => _)
                    )
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
        public void Command_repeatable_option_set_by_one_char_long_name_without_value()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--o").Run());
            Assert.False(option);
        }

        [Fact]
        public void Command_repeatable_option_set_by_one_char_long_name()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var option = cmd.RepeatableOption('o', "option");
            Assert.Equal(ExitCodes.UnknownOptions, parser.Parse("cmd", "--o", "value").Run());
            Assert.False(option);
        }

        #endregion

        #region command argument tests

        [Fact]
        public void Command_argument_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var arg = cmd.Argument("arg");
            Assert.Equal(0, parser.Parse().Run());
            Assert.False(arg.IsSet);
        }

        [Fact]
        public void Command_argument_is_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var arg = cmd.Argument("arg");
            Assert.Equal(0, parser.Parse("cmd", "value").Run());
            Assert.True(arg.IsSet);
            Assert.Equal("value", arg.Value);
        }

        [Fact]
        public void Command_required_argument_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            cmd.Argument("arg").Required();
            Assert.Equal(ExitCodes.InvalidInput, parser.Parse("cmd").Run());
        }

        #endregion

        #region repeatable argument tests

        [Fact]
        public void Command_repeatable_argument_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var arg = cmd.RepeatableArgument("arg");
            Assert.Equal(0, parser.Parse("cmd").Run());
            Assert.False(arg.IsSet);
        }

        [Fact]
        public void Command_repeatable_argument_is_set_once()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var arg = cmd.RepeatableArgument("arg");
            Assert.Equal(0, parser.Parse("cmd", "value").Run());
            Assert.True(arg.IsSet);
            Assert.Single(arg.Values);
            Assert.Equal("value", arg.Values[0]);
        }

        [Fact]
        public void Command_repeatable_argument_is_set_few_times()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            var arg = cmd.RepeatableArgument("arg");
            Assert.Equal(0, parser.Parse("cmd", "value1", "value2").Run());
            Assert.True(arg.IsSet);
            Assert.Equal(2, arg.Values.Length);
            Assert.Equal("value1", arg.Values[0]);
            Assert.Equal("value2", arg.Values[1]);
        }

        [Fact]
        public void Command_required_repeatable_argument_not_set()
        {
            var parser = CreateParser();
            var cmd = parser.Command("cmd");
            cmd.RepeatableArgument("arg").Required();
            Assert.Equal(ExitCodes.InvalidInput, parser.Parse("cmd").Run());
        }

        #endregion
    }
}
