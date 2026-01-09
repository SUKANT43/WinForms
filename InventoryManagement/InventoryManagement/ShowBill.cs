using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class ShowBill : Form
    {
        public ShowBill()
        {
            InitializeComponent();
        }

        public void LoadData(BillingData bd)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.ForeColor = Color.Black;
            label2.AutoSize = true;
            label3.AutoSize = true;
            label5.AutoSize = true;
            label7.AutoSize = true;
            label8.AutoSize = true;

            label2.Text = bd.Id.ToString();
            label3.Text = bd.Total.ToString();
            label5.Text = bd.TotalDiscount.ToString();
            label7.Text = bd.CreatedAt;
            label9.Text = bd.Tax.ToString();
            dataGridView.DataSource = bd.ProductList;
        }
    }
}
