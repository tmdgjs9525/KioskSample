using System.Windows;
using System.Windows.Controls;

namespace KioskSample.Main.UI.Units
{

    public class DishItems : ItemsControl
    {
        static DishItems()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DishItems), new FrameworkPropertyMetadata(typeof(DishItems)));
        }
    }
}
