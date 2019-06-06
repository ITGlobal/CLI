using ITGlobal.CommandLine.Parsing.Impl;
using Xunit;

namespace ITGlobal.CommandLine.Parsing
{
    public class LevenshteinDistanceTest
    {
        [Theory]
        [InlineData("test", "test", 0)]
        [InlineData("test", "tEST", 0)]
        [InlineData("", "A", 1)]
        [InlineData("A", "", 1)]
        [InlineData("ABC", "def", 3)]
        [InlineData("kitten", "sitting", 3)]
        public void Calculate_distance(string left, string right, int expected)
        {
            var actual = LevenshteinDistance.Calculate(left, right);
            Assert.Equal(expected, actual);
        }
    }
}