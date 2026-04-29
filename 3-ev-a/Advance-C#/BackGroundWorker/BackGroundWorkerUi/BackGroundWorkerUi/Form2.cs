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
    public partial class Form2 : Form
    {
        BackgroundWorker worker;
        List<FakeData> fakeData;
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += Form2Closing;
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("Designation", "Designation");
            fakeData = FakeData.GetFakeData();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = fakeData.Count();
            worker = new BackgroundWorker();
            worker.DoWork += FetchData;
            worker.ProgressChanged += UpdateProgress;
            worker.RunWorkerCompleted += TaskCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }

        private void Form2Closing(object sender, FormClosingEventArgs e)
        {
            worker.CancelAsync();
        }

        private void TaskCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "Completed...";
        }

        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            if (worker.CancellationPending)
            {
                return;
            }
            progressBar1.Value = e.ProgressPercentage + 1;
            label1.Text = $"{e.ProgressPercentage + 1}/{fakeData.Count()}";
            FakeData data = fakeData[e.ProgressPercentage];
            dataGridView1.Rows.Add(data.Id, data.Name, data.Address, data.Designation);
        }

        private void FetchData(object sender, DoWorkEventArgs e)
        {
            {
                for (int i = 0; i < fakeData.Count(); i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    Thread.Sleep(1);
                    worker.ReportProgress(i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Worke in progress");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
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
                    Id = $"EMP{i:D3}",
                    Name = names[random.Next(names.Length)] + " " + i,
                    Address = addresses[random.Next(addresses.Length)],
                    Designation = designations[random.Next(designations.Length)]
                });
            }

            return list;
        }
    }
}



