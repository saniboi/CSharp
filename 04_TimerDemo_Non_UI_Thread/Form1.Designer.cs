namespace _04_TimerDemo_Non_UI_Thread
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
            this.label1 = new System.Windows.Forms.Label();
            this.zeitLabel = new System.Windows.Forms.Label();
            this.startStopKnopf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zeit:";
            // 
            // zeitLabel
            // 
            this.zeitLabel.AutoSize = true;
            this.zeitLabel.Location = new System.Drawing.Point(67, 47);
            this.zeitLabel.Name = "zeitLabel";
            this.zeitLabel.Size = new System.Drawing.Size(16, 13);
            this.zeitLabel.TabIndex = 1;
            this.zeitLabel.Text = "...";
            // 
            // startStopKnopf
            // 
            this.startStopKnopf.Location = new System.Drawing.Point(195, 42);
            this.startStopKnopf.Name = "startStopKnopf";
            this.startStopKnopf.Size = new System.Drawing.Size(75, 23);
            this.startStopKnopf.TabIndex = 2;
            this.startStopKnopf.Text = "Start/Stop";
            this.startStopKnopf.UseVisualStyleBackColor = true;
            this.startStopKnopf.Click += new System.EventHandler(this.startStopKnopf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 121);
            this.Controls.Add(this.startStopKnopf);
            this.Controls.Add(this.zeitLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label zeitLabel;
        private System.Windows.Forms.Button startStopKnopf;
    }
}

