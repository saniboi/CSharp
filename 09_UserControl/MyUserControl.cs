using System.Windows.Forms;

namespace _07_UserControl
{
    public partial class MyUserControl : UserControl
    {
        // Die Controls sind private und müssen, falls gewünscht,
        // via Eigenschaften von aussen zugänglich gemacht werden
        public string Key
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        public string Value
        {
            get { return valueLabel.Text; }
            set { valueLabel.Text = value; }
        }

        public MyUserControl()
        {
            InitializeComponent();
        }
    }
}