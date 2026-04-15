using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace BackGroundWorkerUi
{
    public partial class Form2 : Form
    {
        private BackgroundWorker worker;
        private List<FakeData> fakeData;

        public Form2()
        {
            InitializeComponent();

            this.FormClosing += Form2_FormClosing;

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("Designation", "Designation");

            fakeData = FakeData.GetFakeData();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = fakeData.Count;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += FetchData;
            worker.ProgressChanged += UpdateProgress;
            worker.RunWorkerCompleted += TaskCompleted;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
            {
                MessageBox.Show("Work in progress");
                return;
            }

            dataGridView1.Rows.Clear();
            progressBar1.Value = 0;
            label1.Text = "Starting...";

            button1.Enabled = false;

            worker.RunWorkerAsync();
        }

        private void FetchData(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            int batchSize = 100;

            for (int i = 0; i < fakeData.Count; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                Thread.Sleep(1);

                if (i % batchSize == 0 || i == fakeData.Count - 1)
                {
                    bw.ReportProgress(i);
                }
            }
        }

        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            int currentIndex = e.ProgressPercentage;
            int batchSize = 100;

            int start = Math.Max(0, currentIndex - batchSize + 1);
            int end = currentIndex;

            for (int i = start; i <= end; i++)
            {
                if (i >= fakeData.Count)
                    break;

                FakeData data = fakeData[i];

                dataGridView1.Rows.Add(
                    data.Id,
                    data.Name,
                    data.Address,
                    data.Designation
                );
            }

            progressBar1.Value = Math.Min(currentIndex + 1, progressBar1.Maximum);
            label1.Text = $"{currentIndex + 1}/{fakeData.Count}";
        }

        private void TaskCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;

            if (e.Cancelled)
            {
                label1.Text = "Cancelled...";
            }
            else if (e.Error != null)
            {
                label1.Text = "Failed...";
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                label1.Text = "Completed...";
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
        }
    }

    public class FakeData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }

        internal static List<FakeData> GetFakeData()
        {
            var list = new List<FakeData>();

            string[] names =
            {
                "Sukant", "Rahul", "Arun", "Priya", "Meena",
                "Karthik", "Vijay", "Ajay", "Sneha", "Ravi"
            };

            string[] addresses =
            {
                "Chennai", "Coimbatore", "Madurai", "Salem",
                "Erode", "Trichy", "Namakkal", "Karur"
            };

            string[] designations =
            {
                "Software Developer",
                "QA Engineer",
                "UI Developer",
                "Backend Developer",
                "Project Manager",
                "System Analyst"
            };

            Random random = new Random();

            for (int i = 1; i <= 10000; i++)
            {
                list.Add(new FakeData
                {
                    Id = $"EMP{i:D5}",
                    Name = names[random.Next(names.Length)] + " " + i,
                    Address = addresses[random.Next(addresses.Length)],
                    Designation = designations[random.Next(designations.Length)]
                });
            }

            return list;
        }
    }
}