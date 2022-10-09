using System.Windows;
using _20_BookInventory_MVVM_Example_6.ViewModel;

namespace _20_BookInventory_MVVM_Example_6.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new BookInventoryViewModel();

        }
    }
}