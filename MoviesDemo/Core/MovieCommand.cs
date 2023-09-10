using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesDemo.Core
{
    public class MovieCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action _executeAction;
        private readonly Action<object> _executeActionString;

        //private readonly Func<object, bool> _canExecuteAction;

        public MovieCommand(Action action)
        {
            _executeAction = action;
            //_canExecuteAction = canExecuteAction;

        }

        public MovieCommand(Action<object> action)
        {
            _executeActionString = action;
            //_canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter) { return true; }
        public void Execute() { _executeAction.Invoke(); }
        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                if (_executeActionString != null)
                {
                    if (string.IsNullOrEmpty(parameter.ToString()))
                    {
                        return;
                    }
                    _executeActionString.Invoke(parameter);

                }

            }
            else
            {
                if (_executeAction != null)
                {
                    _executeAction.Invoke();
                }

            }

        }
    }
}
