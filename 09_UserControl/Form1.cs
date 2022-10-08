using System.Windows.Forms;

namespace _07_UserControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeUserControls();
        }

        private void InitializeUserControls()
        {
            myUserControl1.Key = "k1";
            myUserControl1.Value = "v1";
            myUserControl2.Key = "k2";
            myUserControl2.Value = "v2";
            myUserControl3.Key = "k3";
            myUserControl3.Value = "v2";
            myUserControl4.Key = "k3";
            myUserControl4.Value = "v2";
        }
    }
}