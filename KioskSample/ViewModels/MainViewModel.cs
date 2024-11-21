﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        private ObservableCollection<DishMenu> _dishMenus ;


        public MainViewModel(IDishMenuRepository dishMenuRepository)
        {
            _dishMenuRepository = dishMenuRepository;

            DishMenus = new ObservableCollection<DishMenu>(_dishMenuRepository.GetAll()); 

            RegisterEvent();
        }

        private void RegisterEvent()
        {
            WeakReferenceMessenger.Default.Register<CategoryChagned>(this, async(r, m) =>
            {
                DishMenus = new ObservableCollection<DishMenu>(await _dishMenuRepository.GetByCateogryAsync(m.Value));
            });
        }
    }
}
