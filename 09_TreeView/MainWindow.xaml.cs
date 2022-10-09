using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _09_TreeView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            var treeViewMainItem = new TreeViewItem { Header = "Brands" };
            TreeViewCarBrands.Items.Add(treeViewMainItem);
            treeViewMainItem.FontSize = 18;

            var carBrandList = new List<string>
            {
                "Audi",
                "BMW",
                "Ferrari",
                "Mercedes",
                "Nissan",
                "Peugeot",
                "Porsche"
            };

            foreach (string brand in carBrandList)
            {
                TreeViewItem treeViewItem = new TreeViewItem { Header = brand };
                treeViewMainItem.Items.Add(treeViewItem);
            }
        }
    }
}