using System.Windows.Forms;

namespace Wetterstationssimulator
{
    public partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

       
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DatumLabel = new System.Windows.Forms.Label();
            this.TemperaturLabel = new System.Windows.Forms.Label();
            this.WindgeschwindigkeitLabel = new System.Windows.Forms.Label();
            this.NiederschlagsmengeLabel = new System.Windows.Forms.Label();
            this.NiederschlagswahrscheinlichkeitLabel = new System.Windows.Forms.Label();
            this.LuftfeuchtigkeitLabel = new System.Windows.Forms.Label();
            this.textBoxTemp = new System.Windows.Forms.TextBox();
            this.textBoxWindge = new System.Windows.Forms.TextBox();
            this.textBoxNiederschlagsmenge = new System.Windows.Forms.TextBox();
            this.textBoxNiederschlagswahrscheinlichkeit = new System.Windows.Forms.TextBox();
            this.textBoxLuftfeuchtigkeit = new System.Windows.Forms.TextBox();
            this.delete_btn = new System.Windows.Forms.Button();
            this.simulationLabel = new System.Windows.Forms.Label();
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.textBoxDatum = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelEditieren = new System.Windows.Forms.Label();
            this.comboBoxDateTimeEdit = new System.Windows.Forms.ComboBox();
            this.dataValuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timerSetValues = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataValuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToExcelFileToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // fileToExcelFileToolStripMenuItem
            // 
            this.fileToExcelFileToolStripMenuItem.Name = "fileToExcelFileToolStripMenuItem";
            this.fileToExcelFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fileToExcelFileToolStripMenuItem.Text = "Export to Excel";
            this.fileToExcelFileToolStripMenuItem.Click += new System.EventHandler(this.getCsvFileToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(589, 329);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // DatumLabel
            // 
            this.DatumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatumLabel.AutoSize = true;
            this.DatumLabel.Location = new System.Drawing.Point(15, 41);
            this.DatumLabel.Name = "DatumLabel";
            this.DatumLabel.Size = new System.Drawing.Size(66, 13);
            this.DatumLabel.TabIndex = 2;
            this.DatumLabel.Text = "Datum [Tag]";
            this.DatumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TemperaturLabel
            // 
            this.TemperaturLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TemperaturLabel.AutoSize = true;
            this.TemperaturLabel.Location = new System.Drawing.Point(207, 41);
            this.TemperaturLabel.Name = "TemperaturLabel";
            this.TemperaturLabel.Size = new System.Drawing.Size(81, 13);
            this.TemperaturLabel.TabIndex = 3;
            this.TemperaturLabel.Text = "Temperatur [°C]";
            this.TemperaturLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WindgeschwindigkeitLabel
            // 
            this.WindgeschwindigkeitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindgeschwindigkeitLabel.AutoSize = true;
            this.WindgeschwindigkeitLabel.Location = new System.Drawing.Point(399, 41);
            this.WindgeschwindigkeitLabel.Name = "WindgeschwindigkeitLabel";
            this.WindgeschwindigkeitLabel.Size = new System.Drawing.Size(142, 13);
            this.WindgeschwindigkeitLabel.TabIndex = 4;
            this.WindgeschwindigkeitLabel.Text = "Windgeschwindigkeit [km/h]";
            this.WindgeschwindigkeitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NiederschlagsmengeLabel
            // 
            this.NiederschlagsmengeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NiederschlagsmengeLabel.AutoSize = true;
            this.NiederschlagsmengeLabel.Location = new System.Drawing.Point(18, 91);
            this.NiederschlagsmengeLabel.Name = "NiederschlagsmengeLabel";
            this.NiederschlagsmengeLabel.Size = new System.Drawing.Size(136, 13);
            this.NiederschlagsmengeLabel.TabIndex = 5;
            this.NiederschlagsmengeLabel.Text = "Niederschlagsmenge [l/m2]";
            // 
            // NiederschlagswahrscheinlichkeitLabel
            // 
            this.NiederschlagswahrscheinlichkeitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NiederschlagswahrscheinlichkeitLabel.AutoSize = true;
            this.NiederschlagswahrscheinlichkeitLabel.Location = new System.Drawing.Point(207, 91);
            this.NiederschlagswahrscheinlichkeitLabel.Name = "NiederschlagswahrscheinlichkeitLabel";
            this.NiederschlagswahrscheinlichkeitLabel.Size = new System.Drawing.Size(178, 13);
            this.NiederschlagswahrscheinlichkeitLabel.TabIndex = 6;
            this.NiederschlagswahrscheinlichkeitLabel.Text = "Niederschlagswahrscheinlichkeit [%]";
            // 
            // LuftfeuchtigkeitLabel
            // 
            this.LuftfeuchtigkeitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LuftfeuchtigkeitLabel.AutoSize = true;
            this.LuftfeuchtigkeitLabel.Location = new System.Drawing.Point(399, 91);
            this.LuftfeuchtigkeitLabel.Name = "LuftfeuchtigkeitLabel";
            this.LuftfeuchtigkeitLabel.Size = new System.Drawing.Size(97, 13);
            this.LuftfeuchtigkeitLabel.TabIndex = 7;
            this.LuftfeuchtigkeitLabel.Text = "Luftfeuchtigkeit [%]";
            // 
            // textBoxTemp
            // 
            this.textBoxTemp.Location = new System.Drawing.Point(210, 57);
            this.textBoxTemp.Name = "textBoxTemp";
            this.textBoxTemp.Size = new System.Drawing.Size(136, 20);
            this.textBoxTemp.TabIndex = 2;
            // 
            // textBoxWindge
            // 
            this.textBoxWindge.Location = new System.Drawing.Point(402, 57);
            this.textBoxWindge.Name = "textBoxWindge";
            this.textBoxWindge.Size = new System.Drawing.Size(136, 20);
            this.textBoxWindge.TabIndex = 3;
            // 
            // textBoxNiederschlagsmenge
            // 
            this.textBoxNiederschlagsmenge.Location = new System.Drawing.Point(18, 107);
            this.textBoxNiederschlagsmenge.Name = "textBoxNiederschlagsmenge";
            this.textBoxNiederschlagsmenge.Size = new System.Drawing.Size(136, 20);
            this.textBoxNiederschlagsmenge.TabIndex = 4;
            // 
            // textBoxNiederschlagswahrscheinlichkeit
            // 
            this.textBoxNiederschlagswahrscheinlichkeit.Location = new System.Drawing.Point(210, 107);
            this.textBoxNiederschlagswahrscheinlichkeit.Name = "textBoxNiederschlagswahrscheinlichkeit";
            this.textBoxNiederschlagswahrscheinlichkeit.Size = new System.Drawing.Size(136, 20);
            this.textBoxNiederschlagswahrscheinlichkeit.TabIndex = 5;
            // 
            // textBoxLuftfeuchtigkeit
            // 
            this.textBoxLuftfeuchtigkeit.Location = new System.Drawing.Point(402, 107);
            this.textBoxLuftfeuchtigkeit.Name = "textBoxLuftfeuchtigkeit";
            this.textBoxLuftfeuchtigkeit.Size = new System.Drawing.Size(136, 20);
            this.textBoxLuftfeuchtigkeit.TabIndex = 6;
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(610, 426);
            this.delete_btn.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(176, 40);
            this.delete_btn.TabIndex = 10;
            this.delete_btn.Text = "Löschen";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // simulationLabel
            // 
            this.simulationLabel.AutoSize = true;
            this.simulationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.simulationLabel.Location = new System.Drawing.Point(607, 137);
            this.simulationLabel.Name = "simulationLabel";
            this.simulationLabel.Size = new System.Drawing.Size(81, 18);
            this.simulationLabel.TabIndex = 17;
            this.simulationLabel.Text = "Simulation:";
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(607, 165);
            this.start_btn.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(176, 40);
            this.start_btn.TabIndex = 7;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(607, 225);
            this.stop_btn.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(176, 40);
            this.stop_btn.TabIndex = 8;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // textBoxDatum
            // 
            this.textBoxDatum.Location = new System.Drawing.Point(18, 57);
            this.textBoxDatum.Name = "textBoxDatum";
            this.textBoxDatum.Size = new System.Drawing.Size(136, 20);
            this.textBoxDatum.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // labelEditieren
            // 
            this.labelEditieren.AutoSize = true;
            this.labelEditieren.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelEditieren.Location = new System.Drawing.Point(607, 295);
            this.labelEditieren.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.labelEditieren.Name = "labelEditieren";
            this.labelEditieren.Size = new System.Drawing.Size(69, 18);
            this.labelEditieren.TabIndex = 22;
            this.labelEditieren.Text = "Editieren:";
            // 
            // comboBoxDateTimeEdit
            // 
            this.comboBoxDateTimeEdit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataValuesBindingSource, "DateTime", true));
            this.comboBoxDateTimeEdit.DataSource = this.dataValuesBindingSource;
            this.comboBoxDateTimeEdit.DisplayMember = "DateTime";
            this.comboBoxDateTimeEdit.FormattingEnabled = true;
            this.comboBoxDateTimeEdit.Location = new System.Drawing.Point(610, 316);
            this.comboBoxDateTimeEdit.Name = "comboBoxDateTimeEdit";
            this.comboBoxDateTimeEdit.Size = new System.Drawing.Size(173, 21);
            this.comboBoxDateTimeEdit.TabIndex = 23;
            this.comboBoxDateTimeEdit.ValueMember = "DateTime";
            // 
            // dataValuesBindingSource
            // 
            this.dataValuesBindingSource.DataSource = typeof(Wetterstationssimulator.DataValues);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Wetterstationssimulator.Form1);
            // 
            // timerSetValues
            // 
            this.timerSetValues.Enabled = true;
            this.timerSetValues.Interval = 1000;
            this.timerSetValues.Tick += new System.EventHandler(this.timerSetValues_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(795, 478);
            this.Controls.Add(this.comboBoxDateTimeEdit);
            this.Controls.Add(this.labelEditieren);
            this.Controls.Add(this.textBoxDatum);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.simulationLabel);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.textBoxLuftfeuchtigkeit);
            this.Controls.Add(this.textBoxNiederschlagswahrscheinlichkeit);
            this.Controls.Add(this.textBoxNiederschlagsmenge);
            this.Controls.Add(this.textBoxWindge);
            this.Controls.Add(this.textBoxTemp);
            this.Controls.Add(this.LuftfeuchtigkeitLabel);
            this.Controls.Add(this.NiederschlagswahrscheinlichkeitLabel);
            this.Controls.Add(this.NiederschlagsmengeLabel);
            this.Controls.Add(this.WindgeschwindigkeitLabel);
            this.Controls.Add(this.TemperaturLabel);
            this.Controls.Add(this.DatumLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wetterstationssimulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataValuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private ToolStripMenuItem fileToExcelFileToolStripMenuItem;
        private DataGridView dataGridView1;
        private Label DatumLabel;
        private Label TemperaturLabel;
        private Label WindgeschwindigkeitLabel;
        private Label NiederschlagsmengeLabel;
        private Label NiederschlagswahrscheinlichkeitLabel;
        private Label LuftfeuchtigkeitLabel;
        private TextBox textBoxTemp;
        private TextBox textBoxWindge;
        private TextBox textBoxNiederschlagsmenge;
        private TextBox textBoxNiederschlagswahrscheinlichkeit;
        private TextBox textBoxLuftfeuchtigkeit;
        private Button delete_btn;
        private Label simulationLabel;
        private Button start_btn;
        private Button stop_btn;
        private TextBox textBoxDatum;
        private ContextMenuStrip contextMenuStrip1;
        private Label labelEditieren;
        private BindingSource dataValuesBindingSource;
        private BindingSource form1BindingSource;
        private ComboBox comboBoxDateTimeEdit;
        private Timer timerSetValues;
        private Timer timer1;
    }
}

