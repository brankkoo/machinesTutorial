using MachinesTutorial.Model.Context;
using MachinesTutorial.Services;
using MachinesTutorial.Services.Base;
using MachinesTutorial.Stores;
using MachinesTutorial.ViewModel;
using MachinesTutorial.ViewModel.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MachinesTutorial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; private set; }
        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();
        }

        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            //DbContext
            services.AddSingleton<IMachineContext, MachineContext>();
            //services
            services.AddScoped<IMachineService, MachineService>();
            //viewmodels

            services.AddSingleton<NavigationStore>();
            services.AddTransient<MainViewModel>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var splashScreen = new SplashScreen();
            this.MainWindow = splashScreen;
            splashScreen.Show();

            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(3000);
                this.Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow();
                    this.MainWindow = mainWindow;
                    mainWindow.Show();
                    splashScreen.Close();
                });


            });
        }
    }
}
