using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_CRUD.Enlaces
{
    class RelayCommand : ICommand
    {
        private Action _action;
        public readonly Func<bool> _canExecute;

        public RelayCommand(Action action, Func<bool> canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public RelayCommand(Action action)
        {
            this._action = action;
            this._canExecute = () => true;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            this._action.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

}
