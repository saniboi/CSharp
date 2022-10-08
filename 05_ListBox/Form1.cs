using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace _05_ListBox
{
    public partial class Form1 : Form
    {
        List<string> cars;
        BindingList<string> carsBindingList;

        public Form1()
        {
            InitializeComponent();
            InitializeCarsList();
        }

        private void InitializeCarsList()
        {
            cars = new List<string>();
            cars.AddRange(new[] { "Audi A3", "BMW 320i", "Fiat Brava", "Ferarri F40", "Peugeot 307", "VW Golf GTI" });
            carsBindingList = new BindingList<string>(cars);
            carsListBox.DataSource = carsBindingList;
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void CarsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (carsListBox.SelectedItem == null) return;
            selectedItemLabel.Text = carsListBox.SelectedItem.ToString();
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            carsBindingList.Add(userInputTextBox.Text);
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            if (carsListBox.SelectedIndex >= 0 && carsListBox.SelectedIndex < cars.Count)
            {
                carsBindingList.RemoveAt(carsListBox.SelectedIndex);
            }
        }
    }
}
