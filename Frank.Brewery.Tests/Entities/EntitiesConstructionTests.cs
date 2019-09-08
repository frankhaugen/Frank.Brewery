using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frank.Brewery.Entities;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Frank.Brewery.Tests.Entities
{
    public class EntitiesConstructionTests
    {
        private readonly ITestOutputHelper _output;

        public EntitiesConstructionTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task CreateRecipe()
        {
            var recipe = new Recipe()
            {
                Name = "Test Brew",
                Creator = "Tester",
                BatchSize = 25,
                MashTime = 90,
                BoilTime = 90,
                Yeast = new Yeast()
                {
                    Name = "US-05",
                    Price = 49
                }
            };

            var json = JsonConvert.SerializeObject(recipe, Formatting.Indented);

            _output.WriteLine(json);

            Assert.True(true);
        }

    }
}
