using System;
using System.Configuration;
using System.Data;
using System.Windows;
using HeliosCheat.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HeliosCheat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public static ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceProvider = _serviceProvider;
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register ProcessesViewModel as a singleton
            services.AddSingleton<ProcessesViewModel>();
        }
    }

}
