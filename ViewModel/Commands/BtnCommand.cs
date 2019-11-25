using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace URLSaving.ViewModel.Commands
{
    public class BtnCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<object, bool> actionCheck;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public BtnCommand(Action method) : this(method, null) { }
        public BtnCommand(Action method, Func<object, bool> func)
        {
            action = method;
            actionCheck = func;
        }
        public bool CanExecute(object parameter)
        {
            if(actionCheck == null)
            {
                return true;
            }
            return actionCheck(parameter);
        }

        public void Execute(object parameter)
        {
            action.Invoke();
        }
    }
}
