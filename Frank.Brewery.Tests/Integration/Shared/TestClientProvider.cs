using Frank.Brewery.Api;
using Frank.Brewery.DataContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Frank.Brewery.Tests.Integration.Shared
{
    public class TestClientProvider<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config => config.AddEnvironmentVariables("ASPNETCORE"));
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<DataContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<DataContext>(options =>
                {
                    if (Environment.OSVersion.Platform.Equals(PlatformID.Unix))
                    {
                        options.UseInMemoryDatabase("TestDatabase");
                    }
                    else
                    {
                        options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
                    }
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<DataContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureDeleted();
                            appContext.Database.EnsureCreated();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            });
        }
    }
}
