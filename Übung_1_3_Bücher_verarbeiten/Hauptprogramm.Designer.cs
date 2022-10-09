namespace Uebung_1_3_Bücher_verarbeiten
{
    partial class Hauptprogramm
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
            this.xmlDateiLadenKnopf = new System.Windows.Forms.Button();
            this.xmlTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xmlDateiLadenKnopf
            // 
            this.xmlDateiLadenKnopf.Location = new System.Drawing.Point(12, 23);
            this.xmlDateiLadenKnopf.Name = "xmlDateiLadenKnopf";
            this.xmlDateiLadenKnopf.Size = new System.Drawing.Size(105, 23);
            this.xmlDateiLadenKnopf.TabIndex = 0;
            this.xmlDateiLadenKnopf.Text = "XML-Datei laden";
            this.xmlDateiLadenKnopf.UseVisualStyleBackColor = true;
            this.xmlDateiLadenKnopf.Click += new System.EventHandler(this.LadeXmlDatei_Click);
            // 
            // xmlTextBox
            // 
            this.xmlTextBox.Location = new System.Drawing.Point(12, 52);
            this.xmlTextBox.Multiline = true;
            this.xmlTextBox.Name = "xmlTextBox";
            this.xmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xmlTextBox.Size = new System.Drawing.Size(776, 239);
            this.xmlTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "XML-Datei als XML exportieren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SpeichereAlsXml_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(606, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ordner öffnen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ÖffneOrdner_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(606, 326);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "XML-Datei als CSV exportieren";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SpeichereAlsCvs_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "ISBN-Attribut hinzufügen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.FügeIsbnAttributHinzu_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 326);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(208, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "publishing_location-Element hinzufügen";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.FügePublishingLocationXmlElementHinzu_Click);
            // 
            // Hauptprogramm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xmlTextBox);
            this.Controls.Add(this.xmlDateiLadenKnopf);
            this.Name = "Hauptprogramm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button xmlDateiLadenKnopf;
        private System.Windows.Forms.TextBox xmlTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

