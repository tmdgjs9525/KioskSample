using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KioskSample.Core.Services;
using KioskSample.Core.ViewModels;
using KioskSample.Events;
using KioskSample.Services;
using KioskSample.ViewModels.Dialog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region fields
        private readonly IDishMenuRepository _dishMenuRepository;
        private readonly IDialogService _dialogService;
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region property
        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        [ObservableProperty]
        private List<string> _categories = new();
        #endregion
        public MainWindowViewModel(IDishMenuRepository dishMenuRepository, IDialogService dialogService, IServiceProvider serviceProvider)
        {
            _dishMenuRepository = dishMenuRepository;
            _dialogService = dialogService;
            _serviceProvider = serviceProvider;

            Categories = _dishMenuRepository.GetAllCategories();
        }

        [RelayCommand]
        private void Category(string cateogry)
        {
            WeakReferenceMessenger.Default.Send(new CategoryChagned(cateogry));
        }

        [RelayCommand]
        private void Pay()
        {
            _dialogService.SetVM(_serviceProvider.GetRequiredService<PayDialogViewModel>());

            _dialogService.Dialog.ShowDialog();
        }
    }
}
