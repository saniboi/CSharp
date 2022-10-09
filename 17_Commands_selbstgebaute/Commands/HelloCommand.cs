using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace _17_Commands_selbstgebaute.Commands
{
    public class HelloCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Debug.WriteLine(@"HelloCommand.CanExecute was called.");
            return true; // Auf false stellen und schauen, dass der Kopf deaktiviert ist
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Hello WPF!");
        }
    }
}