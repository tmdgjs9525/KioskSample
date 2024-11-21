using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KioskSample.Main.UI.Units
{

    public class DishItems : ItemsControl
    {


        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(DishItems), new PropertyMetadata(null));


        static DishItems()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DishItems), new FrameworkPropertyMetadata(typeof(DishItems)));
        }
    }
}
