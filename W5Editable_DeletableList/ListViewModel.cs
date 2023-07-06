using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Editable_DeletableList
{
    public class ListViewModel: BaseViewModel
    {
        public ObservableCollection<object> MainList { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public ListViewModel(List<object> list)
        {
            MainList = new ObservableCollection<object>(list);
            InitialiseDisplayList(MainList);
        }
        private string searchValue;

        public string SearchValue
        {
            get { return searchValue; }
            set
            {
                searchValue = value;
                FilterDisplayList(searchValue);
            }
        }
        protected void DeleteFromList(object item)
        {
            Item var = item as Item;
            MainList.Remove(var.item);
            InitialiseDisplayList(MainList);
            OnPropertyChanged(nameof(MainList));
            OnPropertyChanged(nameof(ItemList));
        }

        private void FilterDisplayList(string searchValue)
        {
            ItemList = new ObservableCollection<Item>();
            if (string.IsNullOrEmpty(searchValue) || string.IsNullOrWhiteSpace(searchValue))
            {
                InitialiseDisplayList(MainList);
            }
            else
            {
                foreach (var item in MainList)
                {
                    if (Validate(searchValue, item))
                    {
                        ItemList.Add(DisplayItem(item));
                    }
                }
            }
            OnPropertyChanged(nameof(ItemList));
        }

        protected virtual bool Validate(string searchValue, object item)
        {
            return item.ToString().ToLower().Contains(searchValue?.ToLower() ?? "");
        }

        public string _selectedItem { get; set; }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (SearchValue != value)
                {
                    SearchValue = value;
                }
                OnPropertyChanged(nameof(SearchValue));
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private void InitialiseDisplayList(ObservableCollection<object> mainList)
        {
            ItemList = new ObservableCollection<Item>();
            foreach (var item in mainList)
            {
                ItemList.Add(DisplayItem(item));
            }
        }
        protected virtual Item DisplayItem(object item)
        {
            Item deletable = new Item(DeleteFromList, UpdateFromList)
            {
                item = item,
                DisplayValue = item.ToString()
            };
            return deletable;
        }
        protected void UpdateFromList(object value)
        {
            Item item = value as Item;

            for (int i = 0; i < MainList.Count; i++)
            {
                if (MainList[i].Equals(item.item))
                {
                    item.item = GetItem(item);
                    MainList[i] = item.item;
                }
            }

            InitialiseDisplayList(MainList);
            OnPropertyChanged(nameof(MainList));
            OnPropertyChanged(nameof(ItemList));
        }

        protected virtual object GetItem(Item item)
        {
            return item.DisplayValue;
        }
    }
}