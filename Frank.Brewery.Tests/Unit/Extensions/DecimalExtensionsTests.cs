using FluentAssertions;
using Frank.Brewery.Extensions;
using Xunit;

namespace Frank.Brewery.Tests.Unit.Extensions
{
    public class DecimalExtensionsTests
    {
        [Theory]
        [InlineData(2.0, 0, 0.0)]
        [InlineData(2.0, 1, 2.0)]
        [InlineData(2.0, 2, 4.0)]
        [InlineData(2.0, 3, 8.0)]
        public void ToPowerOf_StateUnderTest_ExpectedBehavior(decimal value, int powerOf, decimal expected)
        {
            value.ToPowerOf(powerOf).Should().Be(expected);
        }
    }
}
