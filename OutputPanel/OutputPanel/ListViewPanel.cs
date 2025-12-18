using System;
using System.Drawing;
using System.Windows.Forms;

namespace OutputPanel
{
    public partial class ListViewPanel : Form
    {
        private ListView listView1;

        public ListViewPanel()
        {
            InitializeComponent();
            BuildUI();
            LoadData();
            AdjustColumns(); // important
        }

        private void BuildUI()
        {
            Text = "ListView Example";
            Width = 400;
            Height = 300;
            BackColor = Color.FromArgb(32, 32, 32);

            listView1 = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                HideSelection = false,
                MultiSelect = false,
                BackColor = Color.FromArgb(40, 40, 40),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            listView1.Columns.Add("ID", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Name", 100, HorizontalAlignment.Left);

            Controls.Add(listView1);

            Resize += (s, e) => AdjustColumns();
        }

        private void LoadData()
        {
            listView1.Items.Clear();

            AddItem("1", "Sukant");
            AddItem("2", "Rahul");
            AddItem("3", "Amit");
            AddItem("4", "Priya");
        }

        private void AddItem(string id, string name)
        {
            ListViewItem item = new ListViewItem(id);
            item.SubItems.Add(name);
            listView1.Items.Add(item);
        }

        private void AdjustColumns()
        {
            if (listView1.Columns.Count < 2) return;

            int totalWidth = listView1.ClientSize.Width;

            // fixed column
            listView1.Columns[0].Width = 80;

            // fill remaining space
            listView1.Columns[1].Width = totalWidth - 80 - 5; // small padding
        }
    }
}
