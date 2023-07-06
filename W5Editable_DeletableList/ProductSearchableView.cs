using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace W5Editable_DeletableList
{
    public class ProductSearchableView : ListViewModel
    {
        public ProductSearchableView(List<object> items) : base(items)
        {
        }
        protected override Item DisplayItem(object item)
        {
            Product product = (Product)item;
            Item deletable = new Item(DeleteFromList,UpdateFromList)
            {
                item = item,
                DisplayValue = product.ProductName,
            };
            return deletable;
        }
        protected override bool Validate(string searchValue, object item)
        {
            Product p = (Product)item;
            return p?.ProductName.ToLower().Contains(searchValue?.ToLower() ?? "") ?? false;
        }
        protected override object GetItem(Item item)
        {
            Product p = (Product)item.item;
            p.ProductName = item.DisplayValue;
            return p;
        }
    }
}