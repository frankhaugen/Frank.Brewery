using BeerMath;
using FluentAssertions;
using Frank.Brewery.Services;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Frank.Brewery.Tests.Services
{
    public class GravityServiceTests
    {
        private GravityService CreateService()
        {
            return new GravityService();
        }

        [Theory]
        [InlineData(1.040, 100.0, 1.083)]
        [InlineData(1.040, 90.0, 1.075)]
        [InlineData(1.040, 80.0, 1.068)]
        [InlineData(1.040, 70.0, 1.062)]
        [InlineData(1.040, 60.0, 1.056)]
        [InlineData(1.040, 50.0, 1.051)]
        [InlineData(1.040, 40.0, 1.046)]
        [InlineData(1.040, 30.0, 1.043)]
        [InlineData(1.040, 20.0, 1.040)]
        public async Task GetCorrectedGravityAsync_ShouldReturnApproximate(decimal sg, decimal temp, decimal expected)
        {
            // Arrange
            var service = this.CreateService();
            var specificGravity = SpecificGravity.FromGravity(sg);
            var temperature = temp;

            // Act
            var result = await service.GetCorrectedGravityAsync(
                specificGravity,
                temperature);

            // Assert
            result.Value.Should().BeApproximately(expected, 0.0005m);
        }
    }
}
