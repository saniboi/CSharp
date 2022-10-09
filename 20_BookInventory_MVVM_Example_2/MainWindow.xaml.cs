using System.Windows;

namespace _20_BookInventory_MVVM_Example_4
{
    public partial class MainWindow : Window
    {
        private BookViewModel bookViewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Den im XAML instanziierten DataContext referenzieren
            bookViewModel = (BookViewModel) this.DataContext;
        }

        private void SetTitle_Click(object sender, RoutedEventArgs e)
        {
            bookViewModel.Title = "MVVM - So geht's nicht!";
            // Der Titel ist auf dem BookViewModel neu gesetzt,
            // aber die View wird nicht automatisch aktualisiert
        }
    }
}