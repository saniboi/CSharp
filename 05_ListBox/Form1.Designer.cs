namespace _05_ListBox
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
            this.carsListBox = new System.Windows.Forms.ListBox();
            this.selectedItemTitleLable = new System.Windows.Forms.Label();
            this.selectedItemLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.userInputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // carsListBox
            // 
            this.carsListBox.FormattingEnabled = true;
            this.carsListBox.Location = new System.Drawing.Point(12, 12);
            this.carsListBox.Name = "carsListBox";
            this.carsListBox.Size = new System.Drawing.Size(260, 108);
            this.carsListBox.TabIndex = 0;
            this.carsListBox.SelectedIndexChanged += new System.EventHandler(this.CarsListBox_SelectedIndexChanged);
            // 
            // selectedItemTitleLable
            // 
            this.selectedItemTitleLable.AutoSize = true;
            this.selectedItemTitleLable.Location = new System.Drawing.Point(13, 127);
            this.selectedItemTitleLable.Name = "selectedItemTitleLable";
            this.selectedItemTitleLable.Size = new System.Drawing.Size(72, 13);
            this.selectedItemTitleLable.TabIndex = 1;
            this.selectedItemTitleLable.Text = "SelectedItem:";
            // 
            // selectedItemLabel
            // 
            this.selectedItemLabel.AutoSize = true;
            this.selectedItemLabel.Location = new System.Drawing.Point(91, 127);
            this.selectedItemLabel.Name = "selectedItemLabel";
            this.selectedItemLabel.Size = new System.Drawing.Size(160, 13);
            this.selectedItemLabel.TabIndex = 2;
            this.selectedItemLabel.Text = "Nothing has been selected yet...";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(201, 254);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 215);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(123, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.removeButton.Location = new System.Drawing.Point(12, 143);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(123, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove selected";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // userInputTextBox
            // 
            this.userInputTextBox.Location = new System.Drawing.Point(12, 189);
            this.userInputTextBox.Name = "userInputTextBox";
            this.userInputTextBox.Size = new System.Drawing.Size(260, 20);
            this.userInputTextBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 289);
            this.Controls.Add(this.userInputTextBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.selectedItemLabel);
            this.Controls.Add(this.selectedItemTitleLable);
            this.Controls.Add(this.carsListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox carsListBox;
        private System.Windows.Forms.Label selectedItemTitleLable;
        private System.Windows.Forms.Label selectedItemLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox userInputTextBox;
    }
}

