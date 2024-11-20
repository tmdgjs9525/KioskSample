using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Core.ViewModels
{
    public partial class PopupViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase? _popupVM;


    }
}
