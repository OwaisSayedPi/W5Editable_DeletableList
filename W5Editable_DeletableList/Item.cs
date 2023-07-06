using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W5Editable_DeletableList
{
    public class Item
    {
        public object item { get; set; }
        public string DisplayValue { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public Item(Action<object> deleteFromList, Action<object> updateFromList)
        {
            DeleteCommand = new RelayCommand(deleteFromList, this);
            UpdateCommand = new RelayCommand(updateFromList, this);
        }
    }
}
