using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using KioskSample.Core.Models;
using KioskSample.Core.ViewModels;
using KioskSample.Events;
using KioskSample.Models;
using KioskSample.Services;

namespace KioskSample.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IDishMenuRepository _dishMenuRepository;

        [ObservableProperty]
        private List<DishMenu> _items = new();


        public MainViewModel(IDishMenuRepository dishMenuRepository)
        {
            _dishMenuRepository = dishMenuRepository;

            Items = _dishMenuRepository.GetAll().ToList();

            RegisterEvent();
        }

        private void RegisterEvent()
        {
            WeakReferenceMessenger.Default.Register<CategoryChagned>(this, async(r, m) =>
            {
                Items = await _dishMenuRepository.GetByCateogryAsync(m.Value);
            });
        }
    }
}
