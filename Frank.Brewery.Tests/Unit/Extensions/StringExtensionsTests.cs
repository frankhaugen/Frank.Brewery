using FluentAssertions;
using Frank.Brewery.Extensions;
using Xunit;

namespace Frank.Brewery.Tests.Unit.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("-1", -1)]
        [InlineData("one", int.MinValue)]
        public void ToInt_StringShouldParseAsInt(string input, int expected)
        {
            input.ToInt().Should().Be(expected);
        }
    }
}
