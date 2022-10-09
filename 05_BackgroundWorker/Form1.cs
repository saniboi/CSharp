using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace _02_BackgroundWorker
{
    public partial class Form1 : Form
    {
        // http://stackoverflow.com/a/6481328
        private readonly BackgroundWorker backgroundWorker;

        public Form1()
        {
            InitializeComponent();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.WorkerReportsProgress = true;
        }

        private void StartOnUiThreadButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 5; i++)
            {
                int counter = i;
                // Ein Invoke ist hier gar nicht nötig, weil alle Eventhandler auf dem UI-Thread laufen
                // https://stackoverflow.com/questions/11004789/does-a-winforms-event-handler-happen-on-the-same-thread-as-the-caller
                //this.Invoke(new Action(() => counterLabel.Text = counter.ToString()));
                counterLabel.Text = counter.ToString();
                Thread.Sleep(1000);
            }
        }

        private void StartOnBackgroundWorkerThreadButton_Click(object sender, EventArgs e)
        {
            // Ohne diesen Check, kommt es zu einer InvalidOperationException, wenn man mehr als einmal auf den Knopf drückt und der Worker dabei noch am Laufen ist
            // System.InvalidOperationException: 'This BackgroundWorker is currently busy and cannot run multiple tasks concurrently.'
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Der DoWork-Eventhandler läuft immer auf dem Non-UI-Thread.
        /// Darum wird das UI nicht blockiert.
        /// Andererseits darf man von hier keine UI-Elemente manipulieren.
        /// </summary>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 5; i++)
            {
                int counter = i;
                //this.Invoke(new Action(() => counterLabel.Text = counter.ToString())); // Falls wir von hier das UI manipulieren möchten (was man nicht machen sollte, denn BackgroundWorker_ProgressChanged ist dafür da), dann ist ein Invoke nötig, weil DoWork nicht auf dem UI-Thread läuft
                backgroundWorker.ReportProgress(counter);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Der ProgressChanged-Eventhandler läuft immer auf de UI-Thread.
        /// Darum ist kein this.Invoke(...) nötig.
        /// </summary>
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            counterLabel.Text = e.ProgressPercentage.ToString();
        }
    }
}
