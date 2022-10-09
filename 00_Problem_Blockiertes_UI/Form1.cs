using System;
using System.Threading;
using System.Windows.Forms;

namespace _00_Problem_Blockiertes_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            // Rechenintesive Arbeit auf dem UI-Thread blockiert das UI
            RechenintensiveArbeitAusführen("Knopf 1 ");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Rechenintesive Arbeit in einem separaten Thread ausgeführt, blockiert das UI nicht
            var t = new Thread(new ParameterizedThreadStart(RechenintensiveArbeitAusführen));
            t.Start("Knopf 2 ");
        }

        private void RechenintensiveArbeitAusführen(object threadName)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                // Da die UI-Controls nur vom UI-Thread bearbeitet werden können
                // und wir uns hier auf einem anderen Thread befinden, müssen wir
                // Invoke verwenden und die Arbeit auf den UI-Thread legen

                // Das führt zu einer Exception
                //textBox1.AppendText($@"{(string)threadName}: {i}");

                // Das führt zu keiner Exception
                Invoke(new Action(() =>
                {
                    textBox1.AppendText($"{(string)threadName}: {i}\n");
                }));
            }
        }
    }
}
