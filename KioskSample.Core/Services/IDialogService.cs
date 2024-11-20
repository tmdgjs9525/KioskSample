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

        void SetVM(ViewModelBase vm);
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

        public void SetVM(ViewModelBase vm)
        {
            if (_popWindow.DataContext is PopupViewModel viewModel)
            {
                viewModel.PopupVM = vm;
            }
        }
    }
}
