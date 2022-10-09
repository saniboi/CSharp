using System.Windows;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo.", "MessageBox-Titel", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}