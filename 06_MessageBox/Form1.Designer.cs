namespace _06_MessageBox
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
            this.showOkMessageBoxButton = new System.Windows.Forms.Button();
            this.showOkMessageBoxWithTitleButton = new System.Windows.Forms.Button();
            this.showOkMessageBoxWithIconButton = new System.Windows.Forms.Button();
            this.showOkCancelMessageBoxButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clickedButtonResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showOkMessageBoxButton
            // 
            this.showOkMessageBoxButton.Location = new System.Drawing.Point(12, 12);
            this.showOkMessageBoxButton.Name = "showOkMessageBoxButton";
            this.showOkMessageBoxButton.Size = new System.Drawing.Size(260, 23);
            this.showOkMessageBoxButton.TabIndex = 0;
            this.showOkMessageBoxButton.Text = "Show OK message box";
            this.showOkMessageBoxButton.UseVisualStyleBackColor = true;
            this.showOkMessageBoxButton.Click += new System.EventHandler(this.okMessageBoxButton_Click);
            // 
            // showOkMessageBoxWithTitleButton
            // 
            this.showOkMessageBoxWithTitleButton.Location = new System.Drawing.Point(12, 41);
            this.showOkMessageBoxWithTitleButton.Name = "showOkMessageBoxWithTitleButton";
            this.showOkMessageBoxWithTitleButton.Size = new System.Drawing.Size(260, 23);
            this.showOkMessageBoxWithTitleButton.TabIndex = 0;
            this.showOkMessageBoxWithTitleButton.Text = "Show OK message box with title";
            this.showOkMessageBoxWithTitleButton.UseVisualStyleBackColor = true;
            this.showOkMessageBoxWithTitleButton.Click += new System.EventHandler(this.showOkMessageBoxWithTitleButton_Click);
            // 
            // showOkMessageBoxWithIconButton
            // 
            this.showOkMessageBoxWithIconButton.Location = new System.Drawing.Point(12, 70);
            this.showOkMessageBoxWithIconButton.Name = "showOkMessageBoxWithIconButton";
            this.showOkMessageBoxWithIconButton.Size = new System.Drawing.Size(260, 23);
            this.showOkMessageBoxWithIconButton.TabIndex = 0;
            this.showOkMessageBoxWithIconButton.Text = "Show OK message box with icon";
            this.showOkMessageBoxWithIconButton.UseVisualStyleBackColor = true;
            this.showOkMessageBoxWithIconButton.Click += new System.EventHandler(this.showOkMessageBoxWithIconButton_Click);
            // 
            // showOkCancelMessageBoxButton
            // 
            this.showOkCancelMessageBoxButton.Location = new System.Drawing.Point(12, 99);
            this.showOkCancelMessageBoxButton.Name = "showOkCancelMessageBoxButton";
            this.showOkCancelMessageBoxButton.Size = new System.Drawing.Size(260, 23);
            this.showOkCancelMessageBoxButton.TabIndex = 0;
            this.showOkCancelMessageBoxButton.Text = "Show OK Cancel message box";
            this.showOkCancelMessageBoxButton.UseVisualStyleBackColor = true;
            this.showOkCancelMessageBoxButton.Click += new System.EventHandler(this.showOkCancelMessageBoxButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clicked button was:";
            // 
            // clickedButtonResultLabel
            // 
            this.clickedButtonResultLabel.AutoSize = true;
            this.clickedButtonResultLabel.Location = new System.Drawing.Point(118, 173);
            this.clickedButtonResultLabel.Name = "clickedButtonResultLabel";
            this.clickedButtonResultLabel.Size = new System.Drawing.Size(154, 13);
            this.clickedButtonResultLabel.TabIndex = 2;
            this.clickedButtonResultLabel.Text = "Nothing has been clicked yet...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.clickedButtonResultLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showOkCancelMessageBoxButton);
            this.Controls.Add(this.showOkMessageBoxWithIconButton);
            this.Controls.Add(this.showOkMessageBoxWithTitleButton);
            this.Controls.Add(this.showOkMessageBoxButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showOkMessageBoxButton;
        private System.Windows.Forms.Button showOkMessageBoxWithTitleButton;
        private System.Windows.Forms.Button showOkMessageBoxWithIconButton;
        private System.Windows.Forms.Button showOkCancelMessageBoxButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label clickedButtonResultLabel;
    }
}

