using CommunityToolkit.Mvvm.Input;
using KioskSample.Core.Services;
using KioskSample.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace KioskSample.ViewModels.Dialog
{
    public partial class PayDialogViewModel : ViewModelBase
    {
        #region fields
        private readonly IDialogService _dialogService;
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region property

        #endregion

        public PayDialogViewModel(IDialogService dialogService, IServiceProvider serviceProvider)
        {
            _dialogService = dialogService;
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        private void Next()
        {
            _dialogService.SetVM(_serviceProvider.GetRequiredService<TestDialogViewModel>());
        }
    }
}
