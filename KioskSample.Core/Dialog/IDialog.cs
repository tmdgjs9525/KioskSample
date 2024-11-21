using KioskSample.Core.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Core.Services
{
    public interface IDialog
    {
        object DataContext { get; set; }

        void Show();

        bool? ShowDialog();

        void Close();
    }

    public interface IDialogParameters
    {
        Dictionary<string, object> Parameters { get; set; }
    }
}
