namespace _07_UserControl
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
            this.myUserControl1 = new _07_UserControl.MyUserControl();
            this.myUserControl2 = new _07_UserControl.MyUserControl();
            this.myUserControl3 = new _07_UserControl.MyUserControl();
            this.myUserControl4 = new _07_UserControl.MyUserControl();
            this.SuspendLayout();
            // 
            // myUserControl1
            // 
            this.myUserControl1.Location = new System.Drawing.Point(13, 17);
            this.myUserControl1.Name = "myUserControl1";
            this.myUserControl1.Size = new System.Drawing.Size(250, 53);
            this.myUserControl1.TabIndex = 0;
            // 
            // myUserControl2
            // 
            this.myUserControl2.Location = new System.Drawing.Point(12, 70);
            this.myUserControl2.Name = "myUserControl2";
            this.myUserControl2.Size = new System.Drawing.Size(259, 53);
            this.myUserControl2.TabIndex = 1;
            // 
            // myUserControl3
            // 
            this.myUserControl3.Location = new System.Drawing.Point(12, 123);
            this.myUserControl3.Name = "myUserControl3";
            this.myUserControl3.Size = new System.Drawing.Size(259, 53);
            this.myUserControl3.TabIndex = 2;
            // 
            // myUserControl4
            // 
            this.myUserControl4.Location = new System.Drawing.Point(12, 176);
            this.myUserControl4.Name = "myUserControl4";
            this.myUserControl4.Size = new System.Drawing.Size(259, 53);
            this.myUserControl4.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.myUserControl4);
            this.Controls.Add(this.myUserControl3);
            this.Controls.Add(this.myUserControl2);
            this.Controls.Add(this.myUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MyUserControl myUserControl1;
        private MyUserControl myUserControl2;
        private MyUserControl myUserControl3;
        private MyUserControl myUserControl4;
    }
}

