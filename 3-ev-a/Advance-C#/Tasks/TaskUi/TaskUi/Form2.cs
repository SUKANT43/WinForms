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

namespace TaskUi
{
    public partial class Form2 : Form
    {
        private List<FakeData> fakeData;
        private CancellationTokenSource cts;
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
            progressBar1.Maximum = fakeData.Count;

        }

        private void Form2Closing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                MessageBox.Show("Work in progress");
                return;
            }
            cts = new CancellationTokenSource();
            button1.Enabled = false;

            dataGridView1.Rows.Clear();
            progressBar1.Value = 0;
            label1.Text = "Loading...";
            try
            {
                await LoadDataAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                label1.Text = "Cancelled...";
            }
            finally
            {
                button1.Enabled = true;
                cts.Dispose();
                cts = null;
            }
        }

        private async Task LoadDataAsync(CancellationToken token)
        {
            for (int i = 0; i < fakeData.Count; i++)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(1, token);
                if (this.IsDisposed || dataGridView1.IsDisposed)
                    return;

                FakeData data = fakeData[i];

                progressBar1.Value = i + 1;
                label1.Text = $"{i + 1}/{fakeData.Count}";

                dataGridView1.Rows.Add(
                    data.Id,
                    data.Name,
                    data.Address,
                    data.Designation
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
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
