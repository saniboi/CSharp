using System.Windows;

namespace _07_x_Namensraum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Die Variable "MeinKnopf" ist hier nur verfügbar, weil sie im
            // XAML mit x:Name="MeinKnopf" gesetzt wurde
            MeinKnopf.Content = "Via code-behind geändert";
        }
    }
}
