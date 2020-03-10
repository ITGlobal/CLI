using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ITGlobal.CommandLine.Parsing
{
    public sealed class AutoCompletionTests
    {
        [Fact]
        public void Empty_command_line()
        {
            var parser = CreateParser();
            var results = parser.Autocomplete(new string[] { });

            CheckResults(
                results,
                new[]
                {
                    AutoCompletionItem.Command("command1"),
                    AutoCompletionItem.Command("command2"),
                    AutoCompletionItem.Command("command3"),
                });
        }

        private static void CheckResults(
            AutoCompletionItem[] actual,
            AutoCompletionItem[] expected)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i].Type, actual[i].Type);
                Assert.Equal(expected[i].Value, actual[i].Value);
            }
        }

        private static ITreeCliParser CreateParser()
        {
            var app = CliParser.NewTreeParser();
            
            // command1
            app.Command("command1");

            // command2
            var command2 = app.Command("command2");

            //     sub1
            command2.Command("sub1");
            
            //     sub2
            command2.Command("sub2");
            
            //     sub3
            command2.Command("sub3");

            // command3
            app.Command("command3");

            return app;
        }
    }
}
