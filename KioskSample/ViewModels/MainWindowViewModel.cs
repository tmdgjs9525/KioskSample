using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KioskSample.Core.Dialog;
using KioskSample.Core.ParemeterKeys;
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

            RegisterEvent();
        }

        private void RegisterEvent()
        {
            WeakReferenceMessenger.Default.Register<SelectedDishChanged>(this, (r, m) =>
            {
                if(m.Value.IsChecked == true)
                {
                    SelectedDish.Add(m.Value);
                }
                else
                {
                    SelectedDish.Remove(m.Value);
                }
            });
        }

        [RelayCommand]
        private void Category(string cateogry)
        {
            WeakReferenceMessenger.Default.Send(new CategoryChagned(cateogry));
        }

        [RelayCommand]
        private void Pay()
        {
            if (SelectedDish.Count() == 0)
            {
                //TODO : 선택필요 다이얼로그
                return;
            }

            DialogParameters dialogParameters = new DialogParameters();

            dialogParameters.Add(ParameterKeys.SelectedDishes, SelectedDish);

            _dialogService.ShowDialog<PayDialogViewModel>(dialogParameters);
        }
    }
}
