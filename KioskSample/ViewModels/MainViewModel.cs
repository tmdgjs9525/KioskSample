﻿using CommunityToolkit.Mvvm.ComponentModel;
using KioskSample.Core;
using KioskSample.Core.Models;
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
        }
    }
}
