using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RoutedEventSample1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MouseRight(object sender, MouseButtonEventArgs e)
        {
            MyListBox.Items.Add("Bubble: " + sender);
        }

        private void PreviewMouseRight(object sender, MouseButtonEventArgs e)
        {
            MyListBox.Items.Add("Tunnel (Preview_xxx): " + sender);

            //enn man die Event-Kette unterbrechen will, get das mit e.Handled = true
            if (sender is Grid)
            {
                MyListBox.Items.Add("Wir sind beim Preview vom Grid angelangt und unterbrechen die Event-Kette.");
                e.Handled = true;
            }
        }

        private void ListeLöschen_Click(object sender, RoutedEventArgs e)
        {
            MyListBox.Items.Clear();
        }
    }
}
