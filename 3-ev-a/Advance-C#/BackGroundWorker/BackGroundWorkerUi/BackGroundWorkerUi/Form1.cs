using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackGroundWorkerUi
{
    public partial class Form1 : Form
    {
        BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += DoUiWork;
            worker.RunWorkerCompleted += UiWorkCompleted;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += UiProgress;
        }

        private void UiProgress(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = $"Step{e.ProgressPercentage}";
        }

        private void UiWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label2.Text = "Work Completed";
        }


        private void DoUiWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 1; i <= 5; i++)
            {
                Thread.Sleep(1000);
                worker.ReportProgress(i);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            for(int i = 1; i <= 5; i++)
            {
                Thread.Sleep(1000);
                label1.Text = $"Step{i}";
            }
            label1.Text = "Completed";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
            {
                label2.Text = "loading...";
                worker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Worker running in other task");
            }
        }
    }


}
