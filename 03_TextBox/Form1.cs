using System;
using System.Windows.Forms;

namespace _03_TextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InputTextChanged(object sender, EventArgs e)
        {
            displayLabelForTextChangedEvent.Text = inputTextBoxForTextChangedEvent.Text;
        }

        private void inputTextBoxForLeaveEvent_Leave(object sender, EventArgs e)
        {
            displayLabelForLeaveEvent.Text = inputTextBoxForLeaveEvent.Text;
        }
    }
}
