using System;
using System.Windows.Forms;

namespace _03_TimerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // System.Windows.Forms.Timer läuft auf dem UI-Thread
        // Vorteil: man kann UI-Komponenten aufrufen
        // Nachteil: Blockiert das UI
        // https://stackoverflow.com/a/20816431
        private void Timer1_Tick(object sender, EventArgs e)
        {
            zeitLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            // Dieser Code blockiert das UI
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    Console.WriteLine("Rechenintensive Arbeit erledigen...");
            //}
        }

        private void StartStopKnopf_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
