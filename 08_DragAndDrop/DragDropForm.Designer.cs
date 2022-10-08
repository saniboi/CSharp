namespace DragDropExample
{
    partial class DragDropForm
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
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DropZonePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DropZonePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(9, 126);
            this.OutputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(426, 133);
            this.OutputTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log-Ausgabe";
            // 
            // DropZonePanel
            // 
            this.DropZonePanel.AllowDrop = true;
            this.DropZonePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DropZonePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DropZonePanel.Controls.Add(this.label2);
            this.DropZonePanel.Location = new System.Drawing.Point(126, 10);
            this.DropZonePanel.Margin = new System.Windows.Forms.Padding(2);
            this.DropZonePanel.Name = "DropZonePanel";
            this.DropZonePanel.Size = new System.Drawing.Size(196, 91);
            this.DropZonePanel.TabIndex = 2;
            this.DropZonePanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropZonePanel_DragDrop);
            this.DropZonePanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropZonePanel_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(39, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Drop-Zone für Dateien";
            // 
            // DragDropForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 269);
            this.Controls.Add(this.DropZonePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DragDropForm";
            this.Text = "DragAndDrop-Beispiel";
            this.DropZonePanel.ResumeLayout(false);
            this.DropZonePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel DropZonePanel;
        private System.Windows.Forms.Label label2;
    }
}

