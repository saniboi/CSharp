using System.Windows;

namespace _04_Knopf_mit_Eventhandler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Der Knopf wurde gedrückt.");
        }
    }
}