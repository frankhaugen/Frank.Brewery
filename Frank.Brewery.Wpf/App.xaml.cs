using Frank.Brewery.DataContexts;
using Frank.Brewery.Repositories;
using Frank.Brewery.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using AutoMapper;
using Frank.Brewery.AutoMapperProfiles;
using Frank.Brewery.Wpf.AutoMapperProfiles;

namespace Frank.Brewery.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(MainWindow));
            services.AddTransient<IYeastService, YeastService>();
            services.AddTransient<IYeastRepository, YeastRepository>();
            services.AddTransient<IEnumService, EnumService>();

            services.AddAutoMapper(typeof(EnumToDtoProfile), typeof(EnumDtoToDropdown));

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("Server=.\\SQLEXPRESS;Database=FrankBrewery;Integrated Security=true;");
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Singleton);
        }
    }
}
