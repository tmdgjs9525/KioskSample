using System.Windows;
using System.Windows.Controls;

namespace KioskSample.Support.UI.Units
{

    public class CustomToolTip : ToolTip
    {
        static CustomToolTip()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomToolTip), new FrameworkPropertyMetadata(typeof(CustomToolTip)));
        }
    }
}
