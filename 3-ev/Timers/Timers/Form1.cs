using System;
using System.Threading;
using System.Windows.Forms;

namespace Timers
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer winFormsTimer;
        private System.Timers.Timer timersTimer;
        private System.Threading.Timer threadingTimer;

        public Form1()
        {
            InitializeComponent();

            // 1️⃣ WinForms Timer (Runs on UI Thread)
            winFormsTimer = new System.Windows.Forms.Timer();
            winFormsTimer.Interval = 1000;
            winFormsTimer.Tick += (s, e) =>
            {
                label1.Text = "WinForms Timer - Thread: " +
                              Thread.CurrentThread.ManagedThreadId;
            };
            winFormsTimer.Start();


            // 2️⃣ System.Timers.Timer (Background Thread)
            timersTimer = new System.Timers.Timer(1000);
            timersTimer.Elapsed += (s, e) =>
            {
                Console.WriteLine("Timers.Timer Thread: " +
                                  Thread.CurrentThread.ManagedThreadId);

                // Must use Invoke to update UI
                this.Invoke((MethodInvoker)(() =>
                {
                    label2.Text = "Timers.Timer Updated";
                }));
            };
            timersTimer.Start();


            // 3️⃣ System.Threading.Timer (ThreadPool Thread)
            threadingTimer = new System.Threading.Timer((state) =>
            {
                Console.WriteLine("Threading.Timer Thread: " +
                                  Thread.CurrentThread.ManagedThreadId);

                // Must use Invoke to update UI
                this.Invoke((MethodInvoker)(() =>
                {
                    label3.Text = "Threading.Timer Updated";
                }));

            }, null, 0, 1000);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            winFormsTimer.Stop();
            timersTimer.Stop();
            threadingTimer.Dispose();

            base.OnFormClosing(e);
        }
    }
}