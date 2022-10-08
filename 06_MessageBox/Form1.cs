using System;
using System.Windows.Forms;

namespace _06_MessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void okMessageBoxButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(text: "This is the displayed text");
            DisplayResult(result);
        }

        private void showOkMessageBoxWithTitleButton_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("This is the displayed text", "Titel of the MessageBox");
            DialogResult result = MessageBox.Show(text: "This is the displayed text", caption: "Title of the MessageBox"); // Mit benannten Argumenten
                                                                                                                           // wird der Code verständlicher.
                                                                                                                           // Und man kann die Position ändern, wenn man
                                                                                                                           // z.B. zuerst "caption" und erst dann "text"
                                                                                                                           // haben will.
            DisplayResult(result);
        }

        private void showOkMessageBoxWithIconButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This is the displayed text", "title", MessageBoxButtons.OK, MessageBoxIcon.Question);
            DisplayResult(result);
        }

        private void showOkCancelMessageBoxButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This is the displayed text", "title", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            DisplayResult(result);
            if (result == DialogResult.OK)
            {
                // Do something
            }
        }

        private void DisplayResult(DialogResult result)
        {
            clickedButtonResultLabel.Text = Enum.GetName(typeof(DialogResult), result);
        }
    }
}