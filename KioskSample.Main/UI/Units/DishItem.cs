using System.Windows;
using System.Windows.Controls;

namespace KioskSample.Main.UI.Units
{

    public class DishItem : Button
    {
        static DishItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DishItem), new FrameworkPropertyMetadata(typeof(DishItem)));
        }
    }
}
