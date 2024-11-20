using System.Windows;
using System.Windows.Controls;

namespace KioskSample.Main.UI.Units
{

    public class CategoryButton : RadioButton
    {
        static CategoryButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CategoryButton), new FrameworkPropertyMetadata(typeof(CategoryButton)));
        }
    }
}
