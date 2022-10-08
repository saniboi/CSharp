using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Wetterstationssimulator
{
    public partial class Form1 : Form
    {
        private readonly BindingSource bindingSourceWetterstation = new BindingSource();
        private readonly List<DataValues> valuesList = new List<DataValues>();
        public bool StartTimer;

        private readonly Random genericNumber = new Random();
        private int randomTemp;
        private int randomWindSpeed;
        private int randomRainfall;
        private int randomRainfallProbability;
        private int randomHumidity;

        public Form1()
        {
            InitializeComponent();
            GetValuesList();
            BindingDataValues();
            this.Controls.Add(dataGridView1);
            this.Load += Form1_Load;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Attach DataGridView events to the corresponding event handlers.
            this.dataGridView1.CellValidating += dataGridView1_CellValidating;
            this.dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        private void BindingDataValues()
        {
            bindingSourceWetterstation.DataSource = valuesList;
            comboBoxDateTimeEdit.DataSource = bindingSourceWetterstation;
            dataGridView1.DataSource = bindingSourceWetterstation;

            textBoxDatum.DataBindings.Add("Text", bindingSourceWetterstation, "DateTime", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTemp.DataBindings.Add("Text", bindingSourceWetterstation, "Temperature", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxWindge.DataBindings.Add("Text", bindingSourceWetterstation, "WindSpeed", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxNiederschlagsmenge.DataBindings.Add("Text", bindingSourceWetterstation, "Rainfall", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxNiederschlagswahrscheinlichkeit.DataBindings.Add("Text", bindingSourceWetterstation, "ProbabilityOfPrecipitation", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxLuftfeuchtigkeit.DataBindings.Add("Text", bindingSourceWetterstation, "Humidity", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void GetValuesList()
        {
            valuesList.Add(new DataValues()
            {
                DateTime = new DateTime(2022, 1, 11),
                Temperature = 12,
                WindSpeed = 13,
                Rainfall = 3,
                ProbabilityOfPrecipitation = 15,
                Humidity = 45
            });
            
            valuesList.Add(new DataValues()
            {
                DateTime = new DateTime(2022, 1, 13),
                Temperature = 14,
                WindSpeed = 15,
                Rainfall = 4,
                ProbabilityOfPrecipitation = 25,
                Humidity = 60
            });
                
            valuesList.Add(new DataValues()
            {
                DateTime = new DateTime(2022, 1, 14),
                Temperature = 9,
                WindSpeed = 25,
                Rainfall = 8,
                ProbabilityOfPrecipitation = 80,
                Humidity = 75
            });
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Program wirklich beenden?", "Hinweis!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Möchtest du wirklich löschen?", "Hinweis!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                int selectedRow = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selectedRow);
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            StartTimer = true;

            randomTemp = genericNumber.Next(-10, 40);
            randomWindSpeed = genericNumber.Next(0, 120);
            randomRainfall = genericNumber.Next(0, 100);
            randomRainfallProbability = genericNumber.Next(0, 100);
            randomHumidity = genericNumber.Next(0, 100);
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            StartTimer = false;
        }

        private void RandomList()
        {

            randomTemp += genericNumber.Next(-5, 5);
            randomWindSpeed += genericNumber.Next(-5, 5);
            randomRainfall += genericNumber.Next(-5, 5);
            randomRainfallProbability += genericNumber.Next(-5, 5);
            randomHumidity += genericNumber.Next(-5, 5);


            DateTime RandomDay()
            {
                DateTime start = new DateTime(2022, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(genericNumber.Next(range));
            }


            bindingSourceWetterstation.Add(new DataValues()
            {
                DateTime = RandomDay(),
                Temperature = randomTemp,
                WindSpeed = randomWindSpeed,
                Rainfall = randomRainfall,
                ProbabilityOfPrecipitation = randomRainfallProbability,
                Humidity = randomHumidity
            });
        }

        private void timerSetValues_Tick(object sender, EventArgs e)
        {
            if (StartTimer)
            {
                RandomList();
            }
        }

        // habe ich als alternativ zum Logbuch gemacht damit du die Daten direkt schon im Excel hast
        // hier der InternetLink war supper erklärt habe was neues gelern :) https://www.c-sharpcorner.com/UploadFile/hrojasara/export-datagridview-to-excel-in-C-Sharp/
        private void getCsvFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Excel öffnen  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // im Excel einen neuen Arbeitsbereich erstellen  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // neuen Arbeitsmappe erstellen  
            Microsoft.Office.Interop.Excel._Worksheet worksheet;
            // zeigt die Excel Applikation hinter dem Programm  
            app.Visible = true;
            // die Daten in die Excel mappe einpflegen  
            worksheet = workbook.ActiveSheet;
            // den Namen von dem Aktiven seite ändern  
            worksheet.Name = "Exported from Wettersimulator";
            // die Header einpflegen  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // alle Daten auslesen und einpflegen (beachte .Count-1 weil die datagridview immer eine leere reihe hat)  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("DateTime")) return;


            if (!string.IsNullOrEmpty(e.FormattedValue.ToString())) return;
            dataGridView1.Rows[e.RowIndex].ErrorText =
                "DateTime darf nicht leer sein!";
            e.Cancel = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs error)
        {
            MessageBox.Show("Allgemeiner Fehler! Falscher Eintrag " + error.Exception.Message);

            if (!((error.Exception) is ConstraintException)) return;
            DataGridView view = (DataGridView)sender;
            view.Rows[error.RowIndex].ErrorText = "Fehler";
            view.Rows[error.RowIndex].Cells[error.ColumnIndex].ErrorText = "Fehler!";

            error.ThrowException = false;
        }
    }
}

