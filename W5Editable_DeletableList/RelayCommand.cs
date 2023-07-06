using System;
using System.Windows.Input;

namespace W5Editable_DeletableList
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<object> vmAction { get; }
        public object Value { get; set; }
        public RelayCommand(Action<object> deleteFromList, object value)
        {
            vmAction = deleteFromList;
            Value = value;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vmAction?.Invoke(Value);
        }
    }
}