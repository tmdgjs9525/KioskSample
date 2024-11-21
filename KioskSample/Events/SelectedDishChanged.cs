using CommunityToolkit.Mvvm.Messaging.Messages;
using KioskSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Events
{
    public class SelectedDishChanged : ValueChangedMessage<DishMenu>
    {
        public SelectedDishChanged(DishMenu selectedMenu) : base(selectedMenu) { }
    }
}
