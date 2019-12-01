using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoFixture;
using BenchmarkDotNet.Attributes;
using Frank.Brewery.DataTransferObjects;
using Xunit;
using Xunit.Abstractions;

namespace Frank.Brewery.Tests.Benchmarks
{
    public class ExtensionsBench
    {
        private Fixture _fixture = new Fixture();
        private readonly ITestOutputHelper _testOutputHelper;

        public ExtensionsBench(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            Json();
        }


        [Benchmark]
        public string Json()
        {
            return JsonSerializer.Serialize(_fixture.Create<HopDto>());
        }

        [Fact]
        public async Task Test()
        {
            Assert.True(true);
        }

    }
}
