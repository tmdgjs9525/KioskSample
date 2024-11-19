using System.Windows;
using System.Windows.Controls.Primitives;

namespace KioskSample.Support.UI.Units
{
    public class CustomScrollBar : ScrollBar
    {
        static CustomScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomScrollBar), new FrameworkPropertyMetadata(typeof(CustomScrollBar)));
        }
    }
}
