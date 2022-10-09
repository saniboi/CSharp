using System;
using System.Windows.Input;

namespace _18_Commands_selbstgebaute_mit_RelayCommand
{
    internal class RelayCommand : ICommand
    {
        public Action<object> ExecuteDelegate { get; set; }
        public Predicate<object> CanExecuteDelegate { get; set; }

        #region ICommand members

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteDelegate(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            // https://joshsmithonwpf.wordpress.com/2008/06/17/allowing-commandmanager-to-query-your-icommand-objects/
            // http://stackoverflow.com/questions/6634777/what-is-the-actual-task-of-canexecutechanged-and-commandmanager-requerysuggested

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}