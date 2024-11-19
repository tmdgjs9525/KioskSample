using KioskSample.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace KioskSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider services;
        public App()
        {
            services = ConfigureServices();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //리소스 딕셔너리 로드 시점 때문에 OnStartup에서 MainWindow 생성

            MainWindowViewModel mainWindowViewModel = services.GetRequiredService<MainWindowViewModel>();

            mainWindowViewModel.CurrentViewModel = services.GetRequiredService<MainViewModel>();


            MainWindow mainWindow = new MainWindow();

            mainWindow.DataContext = mainWindowViewModel;

            mainWindow.Show();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainWindowViewModel>();

            services.AddTransient<MainViewModel>();

            //services.AddSingleton<ViewModelProvider>();

            return services.BuildServiceProvider();
        }
    }

}
