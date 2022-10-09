using System.Windows;
using System.Windows.Input;
using _17_Commands_selbstgebaute.Commands;

namespace _17_Commands_selbstgebaute
{
    public partial class MainWindow : Window
    {
        public ICommand MyHelloCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            MyHelloCommand = new HelloCommand();
        }
    }
}