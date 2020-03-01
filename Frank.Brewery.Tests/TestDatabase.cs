using Frank.Brewery.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Frank.Brewery.Tests
{
    public static class TestDatabase
    {
        private static DataContext _dataContext;

        public static DataContext DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext = SetupDatabase();
                }

                return _dataContext;
            }
        }

        private static DataContext SetupDatabase()
        {
            DbContextOptions<DataContext> options;
            var builder = new DbContextOptionsBuilder<DataContext>(); ;
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            options = builder.Options;
            var dataContext = new DataContext(options);
            dataContext.Database.EnsureCreated();
            return dataContext;
        }
    }
}
