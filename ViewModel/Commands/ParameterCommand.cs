using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace URLSaving.ViewModel.Commands
{
    public class ParameterCommand : ICommand
    {
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

        private readonly Func<string, bool> func;
        private readonly Action<string> action;

        public ParameterCommand(Action<string> a) : this(a, null) { }
        public ParameterCommand(Action<string> a, Func<object,bool> f)
        {
            action = a ?? throw new NullReferenceException();
            func = f;
        }
        public bool CanExecute(object parameter)
        {
            if(func == null)
            {
                return true;
            }
            return func(parameter as string);
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter as string);
        }
    }
}
