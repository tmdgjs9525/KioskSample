using KioskSample.Core.Dialog;
using KioskSample.Core.ViewModels;
using KioskSample.Core.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Core.Services
{
    public interface IDialogService
    {
        IDialog Dialog { get; }

        IDialog ShowDialog(ViewModelBase vm, DialogParameters? parameters = null);
        IDialog ChangeDialog(ViewModelBase vm, DialogParameters? parameters = null);

        void CloseDialog();
    }

    public class DialogService : IDialogService
    {
        private IDialog _popWindow;

        private readonly IServiceProvider _serviceProvider;

        public DialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _popWindow = _serviceProvider.GetRequiredService<PopupView>() as IDialog;
        }

        public IDialog Dialog => _popWindow;

        public IDialog ShowDialog(ViewModelBase vm, DialogParameters? parameters = null)
        {
            SetVM(vm, parameters);

            _popWindow.ShowDialog();

            return _popWindow;
        }

     

        public IDialog ChangeDialog(ViewModelBase vm, DialogParameters? parameters = null)
        {
            SetVM(vm, parameters);

            return _popWindow;
        }

        public void CloseDialog()
        {
            _popWindow.CloseDialog();
        }

        private void SetVM(ViewModelBase vm, DialogParameters? parameters)
        {
            if (_popWindow.DataContext is PopupViewModel viewModel)
            {
                viewModel.PopupVM = vm;
                if (viewModel.PopupVM is IDialogAware dialog)
                {
                    dialog.OnDialogOpened(parameters ?? new());
                    dialog.RequestClose += result =>
                    {
                        CloseDialog();
                    };
                }
            }
        }
    }
}
