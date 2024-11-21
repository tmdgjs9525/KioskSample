using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace KioskSample.Main.UI.Units
{

    public class DishItem : ToggleButton
    {
        static DishItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DishItem), new FrameworkPropertyMetadata(typeof(DishItem)));
        }
    }
}
