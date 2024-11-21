using CommunityToolkit.Mvvm.Input;
using KioskSample.Core.Dialog;
using KioskSample.Core.Services;
using KioskSample.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.ViewModels.Dialog
{
    public partial class TestDialogViewModel : ViewModelBase, IDialogAware
    {
        private readonly IDialogService _dialogService;

        public event Action<DialogResult>? RequestClose;


        public TestDialogViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }


        public void OnDialogOpened(DialogParameters? parameters)
        {
            
        }

        [RelayCommand]
        private void Exit()
        {
            RequestClose?.Invoke(new DialogResult(true));
        }
    }

}
