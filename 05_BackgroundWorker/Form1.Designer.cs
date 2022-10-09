namespace _02_BackgroundWorker
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
            this.startOnUiThreadButton = new System.Windows.Forms.Button();
            this.startOnBackgroundWorkerThreadButton = new System.Windows.Forms.Button();
            this.counterTitleLabel = new System.Windows.Forms.Label();
            this.counterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startOnUiThreadButton
            // 
            this.startOnUiThreadButton.Location = new System.Drawing.Point(13, 13);
            this.startOnUiThreadButton.Name = "startOnUiThreadButton";
            this.startOnUiThreadButton.Size = new System.Drawing.Size(542, 42);
            this.startOnUiThreadButton.TabIndex = 0;
            this.startOnUiThreadButton.Text = "Start work on UI-thread --> Freezes UI";
            this.startOnUiThreadButton.UseVisualStyleBackColor = true;
            this.startOnUiThreadButton.Click += new System.EventHandler(this.StartOnUiThreadButton_Click);
            // 
            // startOnBackgroundWorkerThreadButton
            // 
            this.startOnBackgroundWorkerThreadButton.Location = new System.Drawing.Point(13, 61);
            this.startOnBackgroundWorkerThreadButton.Name = "startOnBackgroundWorkerThreadButton";
            this.startOnBackgroundWorkerThreadButton.Size = new System.Drawing.Size(542, 42);
            this.startOnBackgroundWorkerThreadButton.TabIndex = 0;
            this.startOnBackgroundWorkerThreadButton.Text = "Start work on new thread with BackgroundWorker --> UI stays reactive";
            this.startOnBackgroundWorkerThreadButton.UseVisualStyleBackColor = true;
            this.startOnBackgroundWorkerThreadButton.Click += new System.EventHandler(this.StartOnBackgroundWorkerThreadButton_Click);
            // 
            // counterTitleLabel
            // 
            this.counterTitleLabel.AutoSize = true;
            this.counterTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterTitleLabel.Location = new System.Drawing.Point(38, 133);
            this.counterTitleLabel.Name = "counterTitleLabel";
            this.counterTitleLabel.Size = new System.Drawing.Size(286, 31);
            this.counterTitleLabel.TabIndex = 1;
            this.counterTitleLabel.Text = "Counter / progressbar:";
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterLabel.Location = new System.Drawing.Point(330, 133);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(38, 31);
            this.counterLabel.TabIndex = 1;
            this.counterLabel.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 212);
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.counterTitleLabel);
            this.Controls.Add(this.startOnBackgroundWorkerThreadButton);
            this.Controls.Add(this.startOnUiThreadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button startOnUiThreadButton;
        private System.Windows.Forms.Button startOnBackgroundWorkerThreadButton;
        private System.Windows.Forms.Label counterTitleLabel;
        private System.Windows.Forms.Label counterLabel;
    }
}

