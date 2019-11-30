using Frank.Brewery.DataContexts;
using Frank.Brewery.Entities;
using Frank.Brewery.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Frank.Brewery.Tests.Repositories
{
    public class YeastRepositoryTests
    {
        private DataContext _dataContext;
        private YeastRepository sutYeastRepository;
        private Fixture _fixture = new Fixture();

        public YeastRepositoryTests()
        {
            SetupDatabase();
            sutYeastRepository = new YeastRepository(_dataContext);
        }

        private void SetupDatabase()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>(); ;
            builder.UseInMemoryDatabase("brewerydatabase");
            options = builder.Options;
            _dataContext = new DataContext(options);
            _dataContext.Database.EnsureDeleted();
            _dataContext.Database.EnsureCreated();
        }

        private async Task ResetDatabase(IEnumerable<object> records)
        {
            await _dataContext.Database.EnsureDeletedAsync();
            await _dataContext.Database.EnsureCreatedAsync();
            await _dataContext.AddRangeAsync(records);
            await _dataContext.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var records = _fixture.Build<Yeast>().Without(d => d.Id).OmitAutoProperties().CreateMany(5);
            await ResetDatabase(records);

            // Act
            var result = await sutYeastRepository.GetAll();

            // Assert
            result.Should().HaveCount(5);
        }

        [Fact]
        public async Task Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var records = _fixture.Build<Yeast>().Without(d => d.Id).OmitAutoProperties().CreateMany(5);
            await ResetDatabase(records);

            // Act
            var entry = await sutYeastRepository.Add(_fixture.Build<Yeast>().Without(d => d.Id).OmitAutoProperties().Create());
            var result = await sutYeastRepository.Get(entry.Id);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }
    }
}
