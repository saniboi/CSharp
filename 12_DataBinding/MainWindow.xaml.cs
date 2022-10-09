using System.Windows;

namespace _12_DataBinding
{
    public partial class MainWindow : Window
    {
        public MyColor MyColor;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // DateContext initialisieren

            MyColor = new MyColor { ColorName = "Yellow" };
            Button1.DataContext = MyColor;
            //DataContext = MyColor; // Geht auch, wenn man MyColor höher in der Hierarchie aufhängt

            // Die DataContext-Eigenschaft kommt aus der FrameworkElement-Klasse und existiert auf allen Controls,
            // die wir verwenden.
            //
            // Siehe Button1 → Kontextmenü: Inspect → Hierarchies
        }
    }
}