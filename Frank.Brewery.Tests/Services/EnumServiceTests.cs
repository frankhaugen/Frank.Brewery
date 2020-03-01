using AutoMapper;
using FluentAssertions;
using Frank.Brewery.AutoMapperProfiles;
using Frank.Brewery.Services;
using Xunit;

namespace Frank.Brewery.Tests.Services
{

    public class EnumServiceTests
    {
        private EnumService _testClass;
        private IMapper _mapper;

        public EnumServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile<YeastEntityToDtoProfile>();
                conf.AddProfile<EnumToDtoProfile>();
            }));
            _testClass = new EnumService(_mapper);
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new EnumService(_mapper);
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallBrewTypes()
        {
            var result = _testClass.BrewTypes();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void CanCallBeerCategories()
        {
            var result = _testClass.BeerCategories();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void CanCallAmounts()
        {
            var result = _testClass.Amounts();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void CanCallFermentableTypes()
        {
            var result = _testClass.FermentableTypes();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void CanCallStepNames()
        {
            var result = _testClass.StepNames();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}