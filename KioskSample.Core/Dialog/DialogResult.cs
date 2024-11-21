using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Core.Dialog
{
    public class DialogResult
    {
        public bool Success { get; set; }
        public DialogParameters Parameters { get; set; }

        public DialogResult(bool success, DialogParameters? parameters = null)
        {
            Success = success;
            Parameters = parameters ?? new DialogParameters();
        }
    }
}
