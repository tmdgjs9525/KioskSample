using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KioskSample.Core;
using KioskSample.Events;
using KioskSample.Services;
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
        #endregion

        #region property
        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        [ObservableProperty]
        private List<string> _categories = new();
        #endregion
        public MainWindowViewModel(IDishMenuRepository dishMenuRepository)
        {
            _dishMenuRepository = dishMenuRepository;

            Categories = _dishMenuRepository.GetAllCategories();
        }

        [RelayCommand]
        private void Category(string cateogry)
        {
            WeakReferenceMessenger.Default.Send(new CategoryChagned(cateogry));
        }
    }
}
