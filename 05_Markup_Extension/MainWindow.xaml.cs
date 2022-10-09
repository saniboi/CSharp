using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _05_Markup_Extension
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Dieser Block verändert das UI nur, wenn man die Zeile
            // <Border Style="{StaticResource WindowsBackground}">
            // in
            // <Border Style="{DynamicResource WindowsBackground}">
            // ändert
            Style style = new Style { TargetType = typeof(Border) };
            style.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.Red));
            style.Setters.Add(new Setter(TextBlock.FontSizeProperty, 10D));
            this.Resources["WindowsBackground"] = style;
        }
    }
}
