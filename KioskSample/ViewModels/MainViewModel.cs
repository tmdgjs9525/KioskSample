using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KioskSample.Core.Models;
using KioskSample.Core.ViewModels;
using KioskSample.Events;
using KioskSample.Models;
using KioskSample.Services;
using System.Collections.ObjectModel;

namespace KioskSample.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IDishMenuRepository _dishMenuRepository;

        [ObservableProperty]
        private ObservableCollection<DishMenu> _dishes ;


        public MainViewModel(IDishMenuRepository dishMenuRepository)
        {
            _dishMenuRepository = dishMenuRepository;

            Dishes = new ObservableCollection<DishMenu>(_dishMenuRepository.GetAll()); 

            RegisterEvent();
        }

        private void RegisterEvent()
        {
            WeakReferenceMessenger.Default.Register<CategoryChagned>(this, async(r, m) =>
            {
                Dishes = new ObservableCollection<DishMenu>(await _dishMenuRepository.GetByCateogryAsync(m.Value));
            });
        }

        [RelayCommand]
        private void SelectDish(DishMenu dishMenu)
        {
            WeakReferenceMessenger.Default.Send(new SelectedDishChanged(dishMenu));
        }
    }
}
