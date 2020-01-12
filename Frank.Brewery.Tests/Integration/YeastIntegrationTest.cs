using AutoFixture;
using FluentAssertions;
using Frank.Brewery.Api;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Tests.Integration.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Frank.Brewery.Tests.Integration
{
    public class YeastIntegrationTest : IClassFixture<TestClientProvider<Startup>>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;
        private Fixture _fixture = new Fixture();

        public YeastIntegrationTest(TestClientProvider<Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            factory.ClientOptions.AllowAutoRedirect = false;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task RunTest()
        {
            var yeasts = _fixture.CreateMany<YeastDto>(5).ToList();

            foreach (var yeastDto in yeasts)
            {
                var addedYeast = await _client.PostAsJsonAsync("/yeasts", yeastDto);
                addedYeast.Should().NotBeNull();
                _testOutputHelper.WriteLine(JsonSerializer.Serialize(addedYeast));
            }

            var response = await _client.GetStringAsync("/yeasts");

            _testOutputHelper.WriteLine(response);

            var result = JsonSerializer.Deserialize<IEnumerable<YeastDto>>(response);
            
            result.Count().Should().Be(yeasts.Count());
        }
    }
}
