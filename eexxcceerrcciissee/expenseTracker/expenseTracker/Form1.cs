using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expenseTracker
{
    public partial class Form1 : Form
    {
        BindingList<ExpenseData> list = new BindingList<ExpenseData>();
        BindingList<ExpenseData> filteredList;

        private bool isEditing=false;
        private ExpenseData selectedData;
        public Form1()
        {
            InitializeComponent();
            
            AddSampleData();
            filteredList = new BindingList<ExpenseData>(list);
            MinimumSize = new Size(900, 600);
            AlignUi();
            piePanel.Paint += PaintPage;
            piePanel.Invalidate();

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView.DataSource = filteredList;
            UpdateData();
            SetValues();
            piePanel.Invalidate();
        }

        private void FilterData()
        {
            var result = list.ToList(); 

            if (startDatTimePicker.Checked)
            {
                DateTime startDate = startDatTimePicker.Value.Date;
                result = result.Where(e => e.SelectedDate.Date >= startDate).ToList();
            }

            if (endDateTimePicker.Checked)
            {
                DateTime endDate = endDateTimePicker.Value.Date;
                result = result.Where(e => e.SelectedDate.Date <= endDate).ToList();
            }

            if (filterTypeComboBox.SelectedIndex != 2)
            {
                string type = filterTypeComboBox.SelectedItem.ToString();
                result = result.Where(e => e.Type == type).ToList();
            }

            if (filterCategoryComboBox.SelectedIndex != 5) 
            {
                string category = filterCategoryComboBox.SelectedItem.ToString();
                result = result.Where(e => e.Category == category).ToList();
            }

            filteredList = new BindingList<ExpenseData>(result);
            dataGridView.DataSource = filteredList;
            piePanel.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AlignUi();
        }

        private void SetValues()
        {
            typeComboBox.Items.AddRange(new string[]
            {
                    "Income",
                    "Expense"
            });

            typeComboBox.SelectedIndex = 0;

            categoryComboBox.Items.AddRange(new string[]
            {
                "Salary",
                "Interest",
                "Food",
                "Grocery",
                "Travel"
            });

            categoryComboBox.SelectedIndex = 0;

            amountNumericUpDown.Minimum = 1;
            amountNumericUpDown.Maximum = int.MaxValue;

            filterTypeComboBox.Items.AddRange(new string[]
          {
                    "Income",
                    "Expense",
                    "None"
          });

            filterTypeComboBox.SelectedIndex = 2;

            filterCategoryComboBox.Items.AddRange(new string[]
           {
                "Salary",
                "Interest",
                "Food",
                "Grocery",
                "Travel",
                "None"
           });

            filterCategoryComboBox.SelectedIndex = 5;
            startDatTimePicker.ShowCheckBox = true;
            startDatTimePicker.Checked = false;

            endDateTimePicker.ShowCheckBox = true;
            endDateTimePicker.Checked = false;
        }

        private void PaintPage(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(30, 40,250,250);
            Dictionary<string, float> filter = new Dictionary<string, float>();
            float total=0;
            foreach(var l in filteredList)
            {
                if (filter.ContainsKey(l.Category))
                {
                    filter[l.Category] += l.Amount;
                }
                else
                {
                    filter[l.Category] = l.Amount;
                }
                total += l.Amount;
            }

            float startAngle = 0;
            Dictionary<string, Color> categoryColors = new Dictionary<string, Color>()
            {
                { "Food", Color.OrangeRed },
                { "Travel", Color.DodgerBlue },
                { "Grocery", Color.MediumSeaGreen },
                { "Salary", Color.Goldenrod },
                { "Interest", Color.MediumPurple }
            };

            foreach (var f in filter)
            {
                float percentage = (float)f.Value / total * 100f;
                float sweepAngle = (float)f.Value / total * 360f;
                using(SolidBrush b=new SolidBrush(categoryColors[f.Key]))
                {
                    g.FillPie(b, r, startAngle, sweepAngle);
                    g.DrawPie(new Pen(Color.Black, 1),r, startAngle, sweepAngle);
                    startAngle += sweepAngle;
                }
            }

            float income = 0;
            float expense=0;
            foreach(var l in list)
            {
                if (l.Type == "Income")
                {
                    income += l.Amount;
                }
                else
                {
                    expense += l.Amount;
                }
            }

            //g.DrawLine(new Pen(Color.Black,3),new Point(500,300),new Point(640,300));
            //g.DrawLine(new Pen(Color.BlueViolet, 40), new Point(520, 299), new Point(520, 140));
            //float height = income / expense * 100;
            ////MessageBox.Show($"{height}");
            //g.DrawLine(new Pen(Color.MediumVioletRed, 40), new Point(620, 299), new Point(620, (int)height));

        }


        private void AlignUi()
        {
            titleLabel.Location = new Point(
                (topPanel.Width - titleLabel.Width) / 2,
              topPanel.Top + 20
                );

            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;

            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.FlatAppearance.BorderSize = 0;

            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.FlatAppearance.BorderSize = 0;
            //piePanel.Size = new Size(0, 0);
            ColorCategoryControl cc = new ColorCategoryControl();
            cc.Location = new Point(295,140);
            piePanel.Controls.Add(cc);
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            try
            {
                if ((int)amountNumericUpDown.Value <= 0 || string.IsNullOrEmpty(descriptionRichTextBox.Text))
                {
                    MessageBox.Show("Check filled fields");
                    return;
                }
                if (!isEditing)
                {
                    list.Insert(0,
                        new ExpenseData(
                            selectedDate: selectedDateTimePicker.Value.Date,
                            type: typeComboBox.SelectedItem.ToString(),
                            category: categoryComboBox.SelectedItem.ToString(),
                            amount: (int)amountNumericUpDown.Value,
                            description: descriptionRichTextBox.Text
                        )
                    );
                   
                }
                else if (isEditing)
                {
                    selectedData.SelectedDate = selectedDateTimePicker.Value.Date;
                    
                    selectedData.Type = typeComboBox.SelectedItem.ToString();
                    selectedData.Category = categoryComboBox.SelectedItem.ToString();
                    selectedData.Amount = (int)amountNumericUpDown.Value;
                    selectedData.Description = descriptionRichTextBox.Text;
                    isEditing = false;
                    addButton.Text = "Add";
                    addButton.Text = "Add";
                    selectedData = null;
                    dataGridView.Refresh(); 
                }
                FilterData();
                piePanel.Invalidate();
                amountNumericUpDown.Value = 1;
                typeComboBox.SelectedIndex = 0;
                categoryComboBox.SelectedIndex = 0;
                descriptionRichTextBox.Clear();

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong. Try again.");
            }
        }
        private void UpdateData()
        {
            dataGridView.Columns["Id"].Visible = false;

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
                dataGridView.CellContentClick += DataGridViewClick;
            
        }
    

        private void DataGridViewClick(object s,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                var item = dataGridView.Rows[e.RowIndex].DataBoundItem as ExpenseData;
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
                    list.Remove(item);
                }
                piePanel.Invalidate();


            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                var item = dataGridView.Rows[e.RowIndex].DataBoundItem as ExpenseData;
                if (item == null)
                {
                    return;
                }
                isEditing = true;
                selectedData = item;
                selectedDateTimePicker.Value = item.SelectedDate;
                typeComboBox.SelectedItem = item.Type;
                categoryComboBox.SelectedItem = item.Category;
                amountNumericUpDown.Value = (int)item.Amount;
                descriptionRichTextBox.Text = item.Description;
                addButton.Text = "Edit";
            }            
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            startDatTimePicker.Checked = false;
            endDateTimePicker.Checked = false;
            filterTypeComboBox.SelectedIndex = 2;
            filterCategoryComboBox.SelectedIndex = 5;
            FilterData();
        }


        private void FilterButtonClick(object sender, EventArgs e)
        {
            FilterData();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            addButton.Text = "Add";
            isEditing = false;
            amountNumericUpDown.Value = 1;
            typeComboBox.SelectedIndex = 1;
            categoryComboBox.SelectedIndex = 1;
            descriptionRichTextBox.Clear();
        }

        private void AddSampleData()
        {
            list.Add(new ExpenseData(DateTime.Today.AddDays(-1), "Income", "Salary", 30000, "Monthly salary"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-2), "Expense", "Food", 250000, "Lunch"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-3), "Expense", "Travel", 1200, "Bus & auto"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-4), "Expense", "Grocery", 1800, "Weekly groceries"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-5), "Income", "Interest", 500000, "Bank interest"));

            list.Add(new ExpenseData(DateTime.Today.AddDays(-6), "Expense", "Food", 300, "Dinner"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-7), "Expense", "Travel", 600, "Fuel"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-8), "Expense", "Grocery", 1500, "Vegetables"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-9), "Income", "Salary", 15000, "Freelance payment"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-10), "Expense", "Food", 200, "Snacks"));

            list.Add(new ExpenseData(DateTime.Today.AddDays(-11), "Expense", "Travel", 900, "Train ticket"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-12), "Expense", "Grocery", 2100, "Monthly grocery"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-13), "Income", "Interest", 700, "FD interest"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-14), "Expense", "Food", 350, "Restaurant"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-15), "Expense", "Travel", 400, "Cab"));

            list.Add(new ExpenseData(DateTime.Today.AddDays(-16), "Expense", "Food", 150, "Tea & snacks"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-17), "Income", "Salary", 10000, "Bonus"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-18), "Expense", "Grocery", 1300, "Supermarket"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-19), "Expense", "Travel", 750, "Bike service"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-20), "Expense", "Food", 220, "Breakfast"));
        }

    }
}
