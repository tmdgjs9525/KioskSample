using CommunityToolkit.Mvvm.Input;
using KioskSample.Core.Services;
using KioskSample.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.ViewModels.Dialog
{
    public partial class TestDialogViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        public TestDialogViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        [RelayCommand]
        private void Exit()
        {
            _dialogService.Dialog.Close();
        }
    }

}
