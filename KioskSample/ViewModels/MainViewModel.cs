using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using KioskSample.Core;
using KioskSample.Core.Models;
using KioskSample.Events;
using KioskSample.Models;
using KioskSample.Services;

namespace KioskSample.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        #region fields
        private readonly IDishMenuRepository _dishMenuRepository;
        #endregion

        #region property
        [ObservableProperty]
        private List<DishMenu> _items = new();
        #endregion

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
