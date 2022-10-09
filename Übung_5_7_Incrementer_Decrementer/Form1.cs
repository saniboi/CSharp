using System;
using System.Windows.Forms;

namespace Uebung_5_7_Incrementer_Decrementer
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                timer.Start();
                startStopButton.Text = "Stop";
            }
            else
            {
                timer.Stop();
                startStopButton.Text = "Start";
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Direct access from separate timer thread to UI label component
            // leads to an 'System.InvalidOperationException'
            //timeLabel.Text = string.Format(DateTime.Now.ToLongTimeString());

            // The correct way is to make an invocation to the UI-thread giving
            // it a method to execute on the UI-thread
            this.Invoke(new Action(() => this.timeLabel.Text = string.Format(DateTime.Now.ToLongTimeString()))); // this = a control

            // Or like this
            //var myUiUpdateAction = new Action(UpdateTimeOnUi);
            //this.Invoke(myUiUpdateAction); // this = a control
        }

        private void UpdateTimeOnUi()
        {
            this.timeLabel.Text = string.Format(DateTime.Now.ToLongTimeString());
        }
    }
}