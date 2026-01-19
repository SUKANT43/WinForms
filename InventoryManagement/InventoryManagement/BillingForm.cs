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
    public partial class BillingForm : Form
    {
        private double OfferedTotalPrice;
        private double totalPrice;
        int x, y;

        ShowBill showBill;

        InventoryItem selectedItem;
        private BindingList<InventoryItem> itemList;
        private List<BillingData> billingList = new List<BillingData>();

        public BindingList<BillClass> singleItemList = new BindingList<BillClass>();


        public BillingForm(ShowBill sb)
        {
            InitializeComponent();
            showBill = sb;
            itemList = GlobalItem.itemList;
            billingList = GlobalItem.billList;
            dataGridView.DataSource = singleItemList;
            AlignUi();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AlignUi();
            if (billingList.Count > 0)
            {
                ShowHistory();
            }
        }

        public void AlignUi()
        {
            titleLabel.Location = new Point(
             (panel3.Width - titleLabel.Width) / 2,
           panel3.Top + 20
             );
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.ForeColor = Color.Black;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            selectedItem = null;
            string productName;
            if (string.IsNullOrEmpty(productTextBox.Text))
            {
                MessageBox.Show("Product name must have a value");
                return;
            }

            foreach (var ls in itemList)
            {
                if (ls.ProductName == productTextBox.Text)
                {
                    selectedItem = ls;
                    break;
                }
            }

            if (selectedItem == null)
            {
                MessageBox.Show("No item found in this name");
                return;
            }

            if ((int)quantityUpDown.Value == 0)
            {
                MessageBox.Show("Atleast choose one quantity");
                return;
            }

            //double offer = ((int)quantityUpDown.Value * selectedItem.Price) - (((int)quantityUpDown.Value * selectedItem.Price) - ((selectedItem.Discount) / 100)));

            double offer = ((int)quantityUpDown.Value * selectedItem.Price) - (((int)quantityUpDown.Value * selectedItem.Price) - (selectedItem.Discount / 100));

            if (selectedItem.Stock - (int)quantityUpDown.Value < 0)
            {
                MessageBox.Show("Only " + selectedItem.Stock + " left.");
                return;
            }

            selectedItem.Stock -= (int)quantityUpDown.Value;

            singleItemList.Add(new BillClass(
                id: selectedItem.Id,
                product: selectedItem.ProductName,
                quantity: (int)quantityUpDown.Value,
                originalPrice: ((int)quantityUpDown.Value * selectedItem.Price),
                offeredPrice: ((int)quantityUpDown.Value * selectedItem.Price) - offer
                ));
            OfferedTotalPrice += offer;
            totalPrice += ((int)quantityUpDown.Value * selectedItem.Price);
            productTextBox.Text = "";
            quantityUpDown.Value = 0;
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            if (singleItemList.Count == 0)
            {
                MessageBox.Show("No Items added");
                return;
            }
            billingList.Insert(0, new BillingData(singleItemList.ToList(), totalPrice, totalPrice + (totalPrice * 0.18), OfferedTotalPrice));
            singleItemList.Clear();
            OfferedTotalPrice = 0;
            totalPrice = 0;
            ShowHistory();
        }



        private void ShowHistory()
        {
            panel6.Controls.Clear();
            x = 0;
            y = 0;
            foreach (var ls in billingList)
            {
                if (y == 0)
                {
                    y += 40;
                }
                Label l = new Label()
                {
                    Text = "Id: " + ls.Id + " Date: " + ls.CreatedAt,
                    AutoSize = true,
                    BorderStyle = BorderStyle.Fixed3D
                };
                l.Location = new Point(x += 40, y);
                panel6.Controls.Add(l);
                l.Click += (s, e) =>
                {
                    showBill.LoadData(ls);
                    showBill.ShowDialog();
                };
                x += l.Width;
                if (x + l.Width > panel6.Width)
                {
                    x = 0;
                    y += l.Height + 40;
                }
            }
        }
    }
}
