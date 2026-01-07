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
    public partial class ItemsForm : Form
    {
        BillingForm billingForm;
        public BindingList<InventoryItem> itemList;
        private bool isEditMode;
        private InventoryItem editingItem;
        private bool isFilterMode;
        public ItemsForm(BillingForm bf)
        {
            InitializeComponent();
            billingForm = bf;
            itemList = GlobalItem.itemList;
            dataGridView.DataSource = itemList;
            LoadData();
            LoadUi();
            AddEditAndDeleteButton();
        }



        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            LoadUi();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.ForeColor = Color.Black;
            clearButton.Visible = false;
        }

        private void LoadUi()
        {
            titleLabel.Location = new Point(
                (topPanel.Width - titleLabel.Width) / 2,
              topPanel.Top + 20
                );
        }

        private void LoadData()
        {
            categoryComboBox.Items.AddRange(new string[]
           {
                "Electronics",
                "Home appliances",
                "Grocceries",
                "Medicine",

           });
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.SelectedIndex = 0;

            filterCategoryComboBox.Items.AddRange(new string[]
          {
              "None",
                "Electronics",
                "Home appliances",
              "Grocceries",
                "Medicine"
          });
            filterCategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterCategoryComboBox.SelectedIndex = 0;

            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;

            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.FlatAppearance.BorderSize = 0;

            billButton.FlatStyle = FlatStyle.Flat;
            billButton.FlatAppearance.BorderSize = 0;

            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.FlatAppearance.BorderSize = 0;

            filterClearButton.FlatStyle = FlatStyle.Flat;
            filterClearButton.FlatAppearance.BorderSize = 0;


            stockNumericUpDown.Minimum = 0;
            stockNumericUpDown.Maximum = int.MaxValue;
           
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (isFilterMode) {
                MessageBox.Show("You need to cancel the edit mode.");
            }

            if (String.IsNullOrEmpty(productTextBox.Text))
            {
                MessageBox.Show("Product name must have a value");
                return;
            }
            try
            {
                double num = double.Parse(priceTextBox.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Price must be a double or int");
                return;
            }
            try
            {
                double num = double.Parse(discountTextBox.Text);
                if (num < 0 || num > 100)
                {
                    MessageBox.Show("Discount value must between 0 to 100");
                    return;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Discount must be a double or int");
                return;
            }

            



            if(isEditMode)
            {
                editingItem.ProductName = productTextBox.Text;
                editingItem.Category = categoryComboBox.SelectedItem.ToString();
                editingItem.Price = double.Parse(priceTextBox.Text);
                editingItem.Discount = double.Parse(discountTextBox.Text);
                editingItem.Stock = (int)stockNumericUpDown.Value;
                isEditMode = false;
                editingItem = null;
            }

            else
            {
                foreach (var l in itemList)
                {
                    if (l.ProductName == productTextBox.Text)
                    {
                        MessageBox.Show("Product already exist");
                        return;
                    }
                }
                itemList.Add(
                    new InventoryItem(
                        productName: productTextBox.Text,
                        category: categoryComboBox.SelectedItem.ToString(),
                        price: double.Parse(priceTextBox.Text),
                        discount: double.Parse(discountTextBox.Text),
                        stock: (int)stockNumericUpDown.Value
                        )
                    );
            }

            productTextBox.Text = "";
            categoryComboBox.SelectedIndex = 0;
            priceTextBox.Text = "";
            discountTextBox.Text = "";
            stockNumericUpDown.Value = stockNumericUpDown.Minimum;
            addButton.Text = "Add";
            clearButton.Visible = false;
            dataGridView.Refresh();

        }

        private void AddEditAndDeleteButton()
        {


            if (!dataGridView.Columns.Contains("Edit"))
            {
                // dataGridView.Columns["Id"].Visible = false;
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };

                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };

                dataGridView.Columns.Add(editBtn);
                dataGridView.Columns.Add(deleteBtn);
            }
            dataGridView.CellContentClick += DataGridViewClick;

        }

        private void DataGridViewClick(object s, DataGridViewCellEventArgs e)
        {
            if (isFilterMode)
            {
                MessageBox.Show("You need to cancel the edit mode.");
                return;
            }
            if (e.RowIndex < 0) return;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                InventoryItem item = dataGridView.Rows[e.RowIndex].DataBoundItem as InventoryItem;
                if (item == null)
                {
                    return;
                }


                var result = MessageBox.Show(
               "Are you sure you want to delete this record?",
               "Confirm Delete",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    itemList.Remove(item);
                }
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {


                InventoryItem item = dataGridView.Rows[e.RowIndex].DataBoundItem as InventoryItem;
                if (item == null)
                {
                    return;
                }
                isEditMode = true;
                editingItem = item;
                productTextBox.Text = editingItem.ProductName;
                categoryComboBox.SelectedItem = editingItem.Category;
                priceTextBox.Text = editingItem.Price.ToString();
                discountTextBox.Text = editingItem.Discount.ToString();
                stockNumericUpDown.Value = editingItem.Stock;
                addButton.Text = "Edit";
                clearButton.Visible = true;
            }
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            productTextBox.Text = "";
            addButton.Text = "Add";
            categoryComboBox.SelectedIndex = 0;
            priceTextBox.Text = "";
            discountTextBox.Text = "";
            isEditMode = false;
            editingItem = null;
            clearButton.Visible = false;
        }

        private void FilterButtonClick(object sender, EventArgs e)
        {
            if (itemList.Count <= 0) return;
            isFilterMode = true;
                var result = itemList.ToList();
                if (lowStockCheckBox.Checked)
                {
                    result = result.Where(es => es.Stock <= 10).ToList();
                }
                if (filterCategoryComboBox.SelectedIndex != 0)
                {
                    string type = filterCategoryComboBox.SelectedItem.ToString();
                    result = result.Where(es => es.Category == type).ToList();
                }
                if (!string.IsNullOrEmpty(filterProductTextBox.Text))
                {
                    result = result.Where(es => es.ProductName.Equals(filterProductTextBox.Text)).ToList();
                }
                if (outOfStockCheckBox.Checked)
                {
                    result = result.Where(es => es.Stock == 0).ToList();
                }

                dataGridView.DataSource = result;

            

        }


        private void FilterClearButtonClick(object s, EventArgs e)
        {
            isFilterMode = false;
            dataGridView.DataSource = itemList;
            lowStockCheckBox.Checked = false;
            filterCategoryComboBox.SelectedIndex = 0;
            filterProductTextBox.Text = "";
            outOfStockCheckBox.Checked = false;
        }

        private void BillButtonClick(object sender, EventArgs e)
        {
            billingForm.ShowDialog();
            
        }
    } 
}
