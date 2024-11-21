using KioskSample.Core.Services;
using KioskSample.Core.ViewModels;
using KioskSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KioskSample.Core.Dialog;

namespace KioskSample.Core.Views
{
    /// <summary>
    /// Interaction logic for PopupVIew.xaml
    /// </summary>
    public partial class PopupView : Window, IDialog
    {
        public PopupView()
        {
            InitializeComponent();

            DataContext = new PopupViewModel();
            
        }

        public event Action<DialogResult>? RequestClose;

        public void OnDialogOpened(DialogParameters? parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
