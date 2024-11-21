using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KioskSample.Core.Dialog;
using KioskSample.Core.Services;
using KioskSample.Core.ViewModels;
using KioskSample.Events;
using KioskSample.Models;
using KioskSample.Services;
using KioskSample.ViewModels.Dialog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IDishMenuRepository _dishMenuRepository;
        private readonly IDialogService _dialogService;
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        [ObservableProperty]
        private List<string> _categories = new();

        [ObservableProperty]
        private ObservableCollection<DishMenu> _selectedDish = new();

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
            SelectedDish.Add(new DishMenu()
            {
                Name = "test",
                Price = new Core.Models.Money(2000, "KRW"),
                Category = "전체",
                Id = 99
            });

            DialogParameters dialogParameters = new DialogParameters();

            dialogParameters.Add("SelectedMenu", SelectedDish);

            var vm = _serviceProvider.GetRequiredService<PayDialogViewModel>();

            _dialogService.ShowDialog(vm, dialogParameters);
        }
    }
}
