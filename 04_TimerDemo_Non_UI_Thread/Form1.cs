using System;
using System.Windows.Forms;

namespace _04_TimerDemo_Non_UI_Thread
{
    public delegate void ZeitLabelAktualisierenDelegate();

    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        private ZeitLabelAktualisierenDelegate meineMethode;

        public Form1()
        {
            InitializeComponent();
            Shown += OnShown_TimerEinrichten;
        }

        private void OnShown_TimerEinrichten(object sender, EventArgs e)
        {
            meineMethode = new ZeitLabelAktualisierenDelegate(LabelAktualisieren);

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Tick;
            timer.Start();
        }

        // System.Timers.Timer läuft _nicht_ auf dem UI-Thread
        // Vorteil: Blockiert das UI nicht
        // Nachteil: Man kann UI-Komponente nicht direkt aufrufen
        // https://stackoverflow.com/a/20816431
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Die folgende Zeile führt zu dieser Exception:
            // An exception of type 'System.InvalidOperationException' occurred in System.Windows.Forms.dll
            // but was not handled in user code
            // Additional information: Cross - thread operation not valid: Control 'zeitLabel' accessed from
            // a thread other than the thread it was created on.
            //zeitLabel.Text = DateTime.Now.ToString("HH:mm:ss");

            // Die folgende Zeile führt zu _keiner_ Exception, weil der Code von meineMethode
            // dem UI-Thread zur Ausführung auf dem UI-Thread übergeben wird
            this.Invoke(meineMethode);

            // Dieser Code blockiert das UI nicht
            for (int i = 0; i < int.MaxValue; i++)
            {
                Console.WriteLine(@"Rechenintensive Arbeit erledigen...");
            }
        }

        private void LabelAktualisieren()
        {
            zeitLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void startStopKnopf_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
        }
    }
}
