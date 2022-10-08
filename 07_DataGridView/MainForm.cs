using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGridViewExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Person> people = PersonRepository.GetPeopleList();
            personDataGridView.DataSource = people;

            // Frage: wie kann man eine Spalte ausblenden?
            // Antwort: siehe unten
            const int idColumnIndex = 0;
            personDataGridView.Columns[idColumnIndex].Visible = false;
        }
    }
}
