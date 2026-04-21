using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CrudWinforms
{
    public partial class DataControl : UserControl
    {
        public event Action<UserData> Clicked;

        private BindingSource bs = new BindingSource();

        public DataControl()
        {
            InitializeComponent();
            SetupGridStyle();

            bs.DataSource = DataController.DataList;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = bs;

            dataGridView.CellClick += DataGridView_CellClick;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            UserData dat = dataGridView.Rows[e.RowIndex].DataBoundItem as UserData;

            if (dat != null)
            {
                Clicked?.Invoke(dat);
            }
        }

        // 🔥 FILTER METHOD
        public void ApplyFilter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                bs.DataSource = DataController.DataList;
            }
            else
            {
                var filtered = DataController.DataList
                    .Where(x =>
                        x.Name.Contains(text.Trim()) ||
                        x.Description.Contains(text.Trim())
                    )
                    .ToList();

                bs.DataSource = filtered;
            }
        }

        private void SetupGridStyle()
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.RowHeadersVisible = false;
            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersHeight = 40;

            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView.GridColor = Color.LightGray;
            dataGridView.RowTemplate.Height = 35;
        }
    }
}