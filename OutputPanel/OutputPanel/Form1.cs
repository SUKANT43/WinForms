using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutputPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StyleGrid(dataGridView1);
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;



            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Age", "Age");

            dataGridView1.Rows.Add(1, "Sukanttrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrtrhhhhhhhhhhhhhhhhhhhhh", 22);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);

            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);
            dataGridView1.Rows.Add(2, "Rahul", 25);


        }
        void StyleGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.FromArgb(32, 32, 32);

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            dgv.RowHeadersVisible = false;
            dgv.GridColor = Color.FromArgb(64, 64, 64);
            dgv.RowTemplate.Height = 35;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToAddRows = false;
        }

    }
}
