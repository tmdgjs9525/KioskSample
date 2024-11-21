using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Core.Dialog
{
    public interface IDialogAware
    {
        void OnDialogOpened(DialogParameters parameters);
        event Action<DialogResult> RequestClose;
    }
}
