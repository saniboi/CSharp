namespace _04_ComboBox
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.stringsComboBox = new System.Windows.Forms.ComboBox();
            this.selectedStringTitleLabel = new System.Windows.Forms.Label();
            this.currentSelectionOfStringComboBoxLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.stringsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.enumsComboBox = new System.Windows.Forms.ComboBox();
            this.selectedEnumTitleLabel = new System.Windows.Forms.Label();
            this.currentSelectionOfEnumsComboBoxLabel = new System.Windows.Forms.Label();
            this.fuelPriceLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.objectsLabel = new System.Windows.Forms.Label();
            this.objectsComboBox = new System.Windows.Forms.ComboBox();
            this.selectedObjectTitleLabel = new System.Windows.Forms.Label();
            this.currentSelectionOfObject = new System.Windows.Forms.Label();
            this.personIdLabel = new System.Windows.Forms.Label();
            this.personFirstnameLabel = new System.Windows.Forms.Label();
            this.personLastnameLabel = new System.Windows.Forms.Label();
            this.personIdTextBox = new System.Windows.Forms.TextBox();
            this.personFirstnameTextBox = new System.Windows.Forms.TextBox();
            this.personLastnameTextBox = new System.Windows.Forms.TextBox();
            this.buttonUpdatePerson = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // stringsComboBox
            // 
            this.stringsComboBox.FormattingEnabled = true;
            this.stringsComboBox.Location = new System.Drawing.Point(92, 32);
            this.stringsComboBox.Name = "stringsComboBox";
            this.stringsComboBox.Size = new System.Drawing.Size(177, 21);
            this.stringsComboBox.TabIndex = 0;
            this.stringsComboBox.SelectedIndexChanged += new System.EventHandler(this.stringsComboBox_SelectedIndexChanged);
            // 
            // selectedStringTitleLabel
            // 
            this.selectedStringTitleLabel.AutoSize = true;
            this.selectedStringTitleLabel.Location = new System.Drawing.Point(9, 64);
            this.selectedStringTitleLabel.Name = "selectedStringTitleLabel";
            this.selectedStringTitleLabel.Size = new System.Drawing.Size(74, 13);
            this.selectedStringTitleLabel.TabIndex = 1;
            this.selectedStringTitleLabel.Text = "Selected item:";
            // 
            // currentSelectionOfStringComboBoxLabel
            // 
            this.currentSelectionOfStringComboBoxLabel.AutoSize = true;
            this.currentSelectionOfStringComboBoxLabel.Location = new System.Drawing.Point(89, 64);
            this.currentSelectionOfStringComboBoxLabel.Name = "currentSelectionOfStringComboBoxLabel";
            this.currentSelectionOfStringComboBoxLabel.Size = new System.Drawing.Size(113, 13);
            this.currentSelectionOfStringComboBoxLabel.TabIndex = 2;
            this.currentSelectionOfStringComboBoxLabel.Text = "Nothing selected yet...";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(206, 500);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // stringsLabel
            // 
            this.stringsLabel.AutoSize = true;
            this.stringsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringsLabel.Location = new System.Drawing.Point(9, 35);
            this.stringsLabel.Name = "stringsLabel";
            this.stringsLabel.Size = new System.Drawing.Size(50, 13);
            this.stringsLabel.TabIndex = 3;
            this.stringsLabel.Text = "Strings:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enums:";
            // 
            // enumsComboBox
            // 
            this.enumsComboBox.FormattingEnabled = true;
            this.enumsComboBox.Location = new System.Drawing.Point(90, 19);
            this.enumsComboBox.Name = "enumsComboBox";
            this.enumsComboBox.Size = new System.Drawing.Size(177, 21);
            this.enumsComboBox.TabIndex = 1;
            this.enumsComboBox.SelectedIndexChanged += new System.EventHandler(this.enumsComboBox_SelectedIndexChanged);
            // 
            // selectedEnumTitleLabel
            // 
            this.selectedEnumTitleLabel.AutoSize = true;
            this.selectedEnumTitleLabel.Location = new System.Drawing.Point(7, 43);
            this.selectedEnumTitleLabel.Name = "selectedEnumTitleLabel";
            this.selectedEnumTitleLabel.Size = new System.Drawing.Size(74, 13);
            this.selectedEnumTitleLabel.TabIndex = 6;
            this.selectedEnumTitleLabel.Text = "Selected item:";
            // 
            // currentSelectionOfEnumsComboBoxLabel
            // 
            this.currentSelectionOfEnumsComboBoxLabel.AutoSize = true;
            this.currentSelectionOfEnumsComboBoxLabel.Location = new System.Drawing.Point(87, 43);
            this.currentSelectionOfEnumsComboBoxLabel.Name = "currentSelectionOfEnumsComboBoxLabel";
            this.currentSelectionOfEnumsComboBoxLabel.Size = new System.Drawing.Size(113, 13);
            this.currentSelectionOfEnumsComboBoxLabel.TabIndex = 7;
            this.currentSelectionOfEnumsComboBoxLabel.Text = "Nothing selected yet...";
            // 
            // fuelPriceLabel
            // 
            this.fuelPriceLabel.AutoSize = true;
            this.fuelPriceLabel.Location = new System.Drawing.Point(7, 65);
            this.fuelPriceLabel.Name = "fuelPriceLabel";
            this.fuelPriceLabel.Size = new System.Drawing.Size(56, 13);
            this.fuelPriceLabel.TabIndex = 8;
            this.fuelPriceLabel.Text = "Fuel price:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(87, 65);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(113, 13);
            this.priceLabel.TabIndex = 7;
            this.priceLabel.Text = "Nothing selected yet...";
            // 
            // objectsLabel
            // 
            this.objectsLabel.AutoSize = true;
            this.objectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objectsLabel.Location = new System.Drawing.Point(7, 22);
            this.objectsLabel.Name = "objectsLabel";
            this.objectsLabel.Size = new System.Drawing.Size(54, 13);
            this.objectsLabel.TabIndex = 3;
            this.objectsLabel.Text = "Objects:";
            // 
            // objectsComboBox
            // 
            this.objectsComboBox.FormattingEnabled = true;
            this.objectsComboBox.Location = new System.Drawing.Point(90, 19);
            this.objectsComboBox.Name = "objectsComboBox";
            this.objectsComboBox.Size = new System.Drawing.Size(177, 21);
            this.objectsComboBox.TabIndex = 2;
            this.objectsComboBox.SelectedIndexChanged += new System.EventHandler(this.objectsComboBox_SelectedIndexChanged);
            // 
            // selectedObjectTitleLabel
            // 
            this.selectedObjectTitleLabel.AutoSize = true;
            this.selectedObjectTitleLabel.Location = new System.Drawing.Point(7, 50);
            this.selectedObjectTitleLabel.Name = "selectedObjectTitleLabel";
            this.selectedObjectTitleLabel.Size = new System.Drawing.Size(79, 13);
            this.selectedObjectTitleLabel.TabIndex = 9;
            this.selectedObjectTitleLabel.Text = "SelectedValue:";
            // 
            // currentSelectionOfObject
            // 
            this.currentSelectionOfObject.AutoSize = true;
            this.currentSelectionOfObject.Location = new System.Drawing.Point(87, 50);
            this.currentSelectionOfObject.Name = "currentSelectionOfObject";
            this.currentSelectionOfObject.Size = new System.Drawing.Size(113, 13);
            this.currentSelectionOfObject.TabIndex = 10;
            this.currentSelectionOfObject.Text = "Nothing selected yet...";
            // 
            // personIdLabel
            // 
            this.personIdLabel.AutoSize = true;
            this.personIdLabel.Location = new System.Drawing.Point(7, 117);
            this.personIdLabel.Name = "personIdLabel";
            this.personIdLabel.Size = new System.Drawing.Size(21, 13);
            this.personIdLabel.TabIndex = 9;
            this.personIdLabel.Text = "ID:";
            // 
            // personFirstnameLabel
            // 
            this.personFirstnameLabel.AutoSize = true;
            this.personFirstnameLabel.Location = new System.Drawing.Point(7, 142);
            this.personFirstnameLabel.Name = "personFirstnameLabel";
            this.personFirstnameLabel.Size = new System.Drawing.Size(58, 13);
            this.personFirstnameLabel.TabIndex = 9;
            this.personFirstnameLabel.Text = "First name:";
            // 
            // personLastnameLabel
            // 
            this.personLastnameLabel.AutoSize = true;
            this.personLastnameLabel.Location = new System.Drawing.Point(7, 167);
            this.personLastnameLabel.Name = "personLastnameLabel";
            this.personLastnameLabel.Size = new System.Drawing.Size(59, 13);
            this.personLastnameLabel.TabIndex = 9;
            this.personLastnameLabel.Text = "Last name:";
            // 
            // personIdTextBox
            // 
            this.personIdTextBox.Location = new System.Drawing.Point(90, 114);
            this.personIdTextBox.Name = "personIdTextBox";
            this.personIdTextBox.Size = new System.Drawing.Size(177, 20);
            this.personIdTextBox.TabIndex = 3;
            // 
            // personFirstnameTextBox
            // 
            this.personFirstnameTextBox.Location = new System.Drawing.Point(90, 139);
            this.personFirstnameTextBox.Name = "personFirstnameTextBox";
            this.personFirstnameTextBox.Size = new System.Drawing.Size(177, 20);
            this.personFirstnameTextBox.TabIndex = 4;
            // 
            // personLastnameTextBox
            // 
            this.personLastnameTextBox.Location = new System.Drawing.Point(90, 164);
            this.personLastnameTextBox.Name = "personLastnameTextBox";
            this.personLastnameTextBox.Size = new System.Drawing.Size(177, 20);
            this.personLastnameTextBox.TabIndex = 5;
            // 
            // buttonUpdatePerson
            // 
            this.buttonUpdatePerson.Location = new System.Drawing.Point(90, 79);
            this.buttonUpdatePerson.Name = "buttonUpdatePerson";
            this.buttonUpdatePerson.Size = new System.Drawing.Size(177, 23);
            this.buttonUpdatePerson.TabIndex = 11;
            this.buttonUpdatePerson.Text = "Update person object";
            this.buttonUpdatePerson.UseVisualStyleBackColor = true;
            this.buttonUpdatePerson.Click += new System.EventHandler(this.ButtonUpdatePerson);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stringsComboBox);
            this.groupBox1.Controls.Add(this.selectedStringTitleLabel);
            this.groupBox1.Controls.Add(this.currentSelectionOfStringComboBoxLabel);
            this.groupBox1.Controls.Add(this.stringsLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 138);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Strings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.enumsComboBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.selectedEnumTitleLabel);
            this.groupBox2.Controls.Add(this.currentSelectionOfEnumsComboBoxLabel);
            this.groupBox2.Controls.Add(this.priceLabel);
            this.groupBox2.Controls.Add(this.fuelPriceLabel);
            this.groupBox2.Location = new System.Drawing.Point(14, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enums";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.objectsComboBox);
            this.groupBox3.Controls.Add(this.objectsLabel);
            this.groupBox3.Controls.Add(this.selectedObjectTitleLabel);
            this.groupBox3.Controls.Add(this.buttonUpdatePerson);
            this.groupBox3.Controls.Add(this.currentSelectionOfObject);
            this.groupBox3.Controls.Add(this.personLastnameTextBox);
            this.groupBox3.Controls.Add(this.personIdLabel);
            this.groupBox3.Controls.Add(this.personFirstnameTextBox);
            this.groupBox3.Controls.Add(this.personFirstnameLabel);
            this.groupBox3.Controls.Add(this.personIdTextBox);
            this.groupBox3.Controls.Add(this.personLastnameLabel);
            this.groupBox3.Location = new System.Drawing.Point(14, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 206);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objects";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox stringsComboBox;
        private System.Windows.Forms.Label selectedStringTitleLabel;
        private System.Windows.Forms.Label currentSelectionOfStringComboBoxLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label stringsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox enumsComboBox;
        private System.Windows.Forms.Label selectedEnumTitleLabel;
        private System.Windows.Forms.Label currentSelectionOfEnumsComboBoxLabel;
        private System.Windows.Forms.Label fuelPriceLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label objectsLabel;
        private System.Windows.Forms.ComboBox objectsComboBox;
        private System.Windows.Forms.Label selectedObjectTitleLabel;
        private System.Windows.Forms.Label currentSelectionOfObject;
        private System.Windows.Forms.Label personIdLabel;
        private System.Windows.Forms.Label personFirstnameLabel;
        private System.Windows.Forms.Label personLastnameLabel;
        private System.Windows.Forms.TextBox personIdTextBox;
        private System.Windows.Forms.TextBox personFirstnameTextBox;
        private System.Windows.Forms.TextBox personLastnameTextBox;
        private System.Windows.Forms.Button buttonUpdatePerson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

