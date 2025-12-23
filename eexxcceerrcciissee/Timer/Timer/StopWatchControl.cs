using System;
using System.Windows.Forms;

using System.Diagnostics;
namespace StopWatchC
{
    public partial class StopWatchControl : UserControl
    {
        private Timer timer;
        private Stopwatch stopwatch;
        public StopWatchControl()
        {
            InitializeComponent();
            timer = new Timer();
            stopwatch = new Stopwatch();
            timer.Interval = 10;
            timer.Tick += UpdateTime;

        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer.Start();
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
            stopwatch.Reset();
            timer.Stop();
            timerLabel.Text = "00:00:00.000";
        }

        private void UpdateTime(object s,EventArgs e)
        {
            timerLabel.Text=(stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff"));
        }
    }
}
