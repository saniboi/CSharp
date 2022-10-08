using System;
using System.Drawing;
using System.Windows.Forms;

namespace _02_Windows_Forms_Application_mit_Designer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LadenKnopf_Click(object sender, EventArgs e)
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

        private void Form2ÖffnenKnopf_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
