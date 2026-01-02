using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panels
{
    public partial class Crud : Form
    {
        private  BindingList<CrudData> list=new BindingList<CrudData>();
        public Crud()
        {
            InitializeComponent();
            dataGridView1.DataSource = list;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            UpdateData();
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Name = "hi";
            cms.Items.Add("Edit", null, (s, e) => EditItem());
            cms.Items.Add("Delete", null, (s, e) => DeleteItem());
            Button bt = new Button()
            {
                Text = "..."
            };
            panel1.Controls.Add(bt);
            bt.Click += (s, e) =>
            {
                cms.Show();
            };
        }

        private void EditItem()
        {
            MessageBox.Show("hi");
        }

        private void DeleteItem()
        {
            MessageBox.Show("hi");
        }


        private void UpdateData()
        {
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn()
            {
               HeaderText="Delete",
               Text="Delete",
               UseColumnTextForButtonValue=true,
               Name="Delete"
            };

            dataGridView1.Columns.Add(delete);
            dataGridView1.CellContentClick += DataGridClick;
        }

        private void DataGridClick(object s, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as CrudData;
                if (item == null)
                {
                    return;
                }
                list.Remove(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.Add(
                new CrudData(
                    text:textBox1.Text
                    )
                );
        }
    }

    public class CrudData
    {
        public string Text { get; set; }
        public CrudData(string text)
        {
            Text = text;
        }
    }
}
