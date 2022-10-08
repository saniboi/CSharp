namespace _03_TextBox
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
            this.inputTextBoxForTextChangedEvent = new System.Windows.Forms.TextBox();
            this.displayLabelForTextChangedEvent = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputTextBoxForLeaveEvent = new System.Windows.Forms.TextBox();
            this.displayLabelForLeaveEvent = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTextBoxForTextChangedEvent
            // 
            this.inputTextBoxForTextChangedEvent.Location = new System.Drawing.Point(6, 30);
            this.inputTextBoxForTextChangedEvent.Name = "inputTextBoxForTextChangedEvent";
            this.inputTextBoxForTextChangedEvent.Size = new System.Drawing.Size(248, 20);
            this.inputTextBoxForTextChangedEvent.TabIndex = 0;
            this.inputTextBoxForTextChangedEvent.TextChanged += new System.EventHandler(this.InputTextChanged);
            // 
            // displayLabelForTextChangedEvent
            // 
            this.displayLabelForTextChangedEvent.AutoSize = true;
            this.displayLabelForTextChangedEvent.Location = new System.Drawing.Point(6, 64);
            this.displayLabelForTextChangedEvent.Name = "displayLabelForTextChangedEvent";
            this.displayLabelForTextChangedEvent.Size = new System.Drawing.Size(193, 13);
            this.displayLabelForTextChangedEvent.TabIndex = 1;
            this.displayLabelForTextChangedEvent.Text = "Es wurde noch kein Text eingegeben...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputTextBoxForTextChangedEvent);
            this.groupBox1.Controls.Add(this.displayLabelForTextChangedEvent);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TextChanged-Event";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.displayLabelForLeaveEvent);
            this.groupBox2.Controls.Add(this.inputTextBoxForLeaveEvent);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Leave-Event";
            // 
            // inputTextBoxForLeaveEvent
            // 
            this.inputTextBoxForLeaveEvent.Location = new System.Drawing.Point(7, 27);
            this.inputTextBoxForLeaveEvent.Name = "inputTextBoxForLeaveEvent";
            this.inputTextBoxForLeaveEvent.Size = new System.Drawing.Size(248, 20);
            this.inputTextBoxForLeaveEvent.TabIndex = 0;
            this.inputTextBoxForLeaveEvent.Leave += new System.EventHandler(this.inputTextBoxForLeaveEvent_Leave);
            // 
            // displayLabelForLeaveEvent
            // 
            this.displayLabelForLeaveEvent.AutoSize = true;
            this.displayLabelForLeaveEvent.Location = new System.Drawing.Point(6, 64);
            this.displayLabelForLeaveEvent.Name = "displayLabelForLeaveEvent";
            this.displayLabelForLeaveEvent.Size = new System.Drawing.Size(193, 13);
            this.displayLabelForLeaveEvent.TabIndex = 2;
            this.displayLabelForLeaveEvent.Text = "Es wurde noch kein Text eingegeben...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 235);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBoxForTextChangedEvent;
        private System.Windows.Forms.Label displayLabelForTextChangedEvent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox inputTextBoxForLeaveEvent;
        private System.Windows.Forms.Label displayLabelForLeaveEvent;
    }
}

