using System.Windows;
using System.Windows.Input;

namespace _18_Commands_selbstgebaute_mit_RelayCommand
{
    public partial class MainWindow : Window
    {
        public ICommand MyHelloCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            // Variante 1: mit Lamba-Ausdrücken direkt im Objektintialisierer
            MyHelloCommand = new RelayCommand
            {
                ExecuteDelegate = param => MessageBox.Show("Hello WPF!"),
                CanExecuteDelegate = param => true
            };

            // Variante 2: mit Referenzen auf Methoden
            //MyHelloCommand = new RelayCommand
            //{
            //    ExecuteDelegate = ExecuteHelloCommand,
            //    CanExecuteDelegate = CanExecuteHelloCommand
            //};
        }

        private void ExecuteHelloCommand(object obj)
        {
            MessageBox.Show("Hello WPF!");
        }

        private bool CanExecuteHelloCommand(object obj)
        {
            return true;
        }
    }
}