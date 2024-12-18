﻿using KioskSample.Core.Services;
using KioskSample.Core.Views;
using KioskSample.Services;
using KioskSample.ViewModels;
using KioskSample.ViewModels.Dialog;
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

            services.AddSingleton<IDialogService, DialogService>();

            //더미데이터 반환용 클래스
            services.AddSingleton<IDishMenuRepository, DishMenuRepositoryStub>();
            //services.AddSingleton<IDishMenuRepository, DIshMenuRepository>();

            services.AddTransient<PopupView>();

            services.AddTransient<TestDialogViewModel>();

            services.AddTransient<PayDialogViewModel>();

            services.AddTransient<MainWindowViewModel>();

            services.AddTransient<MainViewModel>();

            //services.AddSingleton<ViewModelProvider>();

            return services.BuildServiceProvider();
        }
    }

}
