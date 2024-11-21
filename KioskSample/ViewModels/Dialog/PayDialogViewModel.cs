using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KioskSample.Core.Dialog;
using KioskSample.Core.Models;
using KioskSample.Core.ParemeterKeys;
using KioskSample.Core.Services;
using KioskSample.Core.ViewModels;
using KioskSample.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace KioskSample.ViewModels.Dialog
{
    public partial class PayDialogViewModel : ViewModelBase, IDialogAware
    {
        private readonly IDialogService _dialogService;
        private readonly IServiceProvider _serviceProvider;

        public event Action<DialogResult>? RequestClose;

        [ObservableProperty]
        private ObservableCollection<DishMenu>? _dishMenus;
        [ObservableProperty]
        private Money _totalPrice = new Money(0, "KRW");

        public PayDialogViewModel(IDialogService dialogService, IServiceProvider serviceProvider)
        {
            _dialogService = dialogService;
            _serviceProvider = serviceProvider;
        }


        [RelayCommand]
        private void Next()
        {
            _dialogService.ChangeDialog<TestDialogViewModel>();
        }

        public void OnDialogOpened(DialogParameters parameters)
        {
            if (parameters.ContainsKey(ParameterKeys.SelectedDishes))
                DishMenus = parameters.GetValue<ObservableCollection<DishMenu>>(ParameterKeys.SelectedDishes);

            foreach (var item in DishMenus!)
            {
                TotalPrice += item.Price;
            }
        }
    }
}
