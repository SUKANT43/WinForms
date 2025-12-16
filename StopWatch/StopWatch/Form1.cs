using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace StopWatch
{
    public partial class Form1 : Form
    {
        Timer uiTimer;
        Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            uiTimer = new Timer();
            stopwatch = new Stopwatch();

            uiTimer.Interval = 10;
            uiTimer.Tick += UpdateTime;
            button1.Click += (s, e) =>
            {
                stopwatch.Start();
                uiTimer.Start();
            };

            button2.Click += (s, e) =>
            {
                stopwatch.Stop();
                uiTimer.Stop();
            };
            button3.Click += (s, e) =>
            {
                stopwatch.Reset();
                label1.Text = "00:00:00.000";
            };
        }

        private void UpdateTime(object s,EventArgs e)
        {
            label1.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
        }

    }
}
