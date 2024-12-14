using Cocojambo.Models.Entities;
using Cocojambo.Models;
using Cocojambo.ViewModels;
using Cocojambo.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Cocojambo
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }


        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрация DbContext
            services.AddDbContext<MvvmContext>(options =>
            {
                options.UseSqlServer(@"Server=zubenkoag;Database=MVVM;User=user1;Password=sa;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");
            });

            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<AddCarViewModel>();
            

            // Регистрация окон
            
            services.AddTransient<EditCarWindow>();
            services.AddTransient<AddCarWindow>();

            // Добавьте регистрацию CarEntity
            services.AddTransient<CarEntity>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }
    }

}
