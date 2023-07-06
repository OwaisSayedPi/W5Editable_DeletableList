using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace W5Editable_DeletableList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ListViewModel ProductList { get; set; }
        public ListViewModel StringList { get; set; }
        public MainWindowViewModel()
        {
            ProductList = new ProductSearchableView( new List<object>() {
                new Product() { ProductID = 1, ProductName = "Milkshake"},
                new Product() { ProductID = 2, ProductName = "Apple Juice"},
                new Product() { ProductID = 3, ProductName = "Mocktail"},
                new Product() { ProductID = 4, ProductName = "Cocktail"},
                new Product() { ProductID = 5, ProductName = "On the Rocks"},
            });

            StringList = new ListViewModel(new List<object>() { "Owais", "Amey", "Ajay", "Sagar" });
        }        
    }
}
