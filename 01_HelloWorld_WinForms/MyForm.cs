using System;
using System.Drawing;
using System.Windows.Forms;

namespace _01_Hello_World
{
    public class MyForm : Form
    {
        private readonly PictureBox pictureBox;

        public MyForm()
        {
            // Control instanziieren und Eigenschaften konfigurieren
            var loadButton = new Button
            {
                Text = "&Load", // Der Buchstabe nach & wird zum "Accelerator key",
                                // den man mit der Alt-Taste aktivieren kann
                Left = 10, // Abstand vom linken Rand in Pixeln
                Top = 10   // Abstand vom oberen Rand in Pixeln
            };
            loadButton.Click += new System.EventHandler(OnLoadClick);

            pictureBox = new PictureBox();
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Width = Width / 2;
            pictureBox.Height = Height / 2;
            pictureBox.Left = (Width - pictureBox.Width) / 2;
            pictureBox.Top = (Height - pictureBox.Height) / 2;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Fehlt auf der Folie

            // Control zur Form hinzufügen
            Controls.Add(loadButton); // Controls wird von Form geerbt
            Controls.Add(pictureBox);
        }

        private void OnLoadClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Open photo";
            dialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"; // Format und Anzeige: http://www.wpf-tutorial.com/chapters/dialogs/images/openfiledialog_filter.png
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(dialog.OpenFile()); // using System.Drawing.Bitmap
            }
            dialog.Dispose();
        }
    }
}