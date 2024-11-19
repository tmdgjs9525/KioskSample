using CommunityToolkit.Mvvm.ComponentModel;
using KioskSample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private List<string> _items = new();
        public MainViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                Items.Add(i.ToString());
            }
            

        }
    }
}
