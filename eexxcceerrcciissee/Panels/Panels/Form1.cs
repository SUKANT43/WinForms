using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace expenseTracker
{
    public partial class Form1 : Form
    {
        private BindingList<ExpenseData> list = new BindingList<ExpenseData>();
        private BindingSource source = new BindingSource();

        private bool isEditing = false;
        private ExpenseData selectedData;

        public Form1()
        {
            InitializeComponent();

            MinimumSize = new Size(900, 600);

            AddSampleData();
            AlignUi();

            piePanel.Paint += PaintPage;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            source.DataSource = list;
            dataGridView.DataSource = source;

            UpdateData();
            SetValues();

            piePanel.Invalidate();
        }

        // ===================== FILTERING =====================
        private void FilterData()
        {
            var filtered = list.Where(e =>
            {
                if (startDatTimePicker.Checked &&
                    e.SelectedDate.Date < startDatTimePicker.Value.Date)
                    return false;

                if (endDateTimePicker.Checked &&
                    e.SelectedDate.Date > endDateTimePicker.Value.Date)
                    return false;

                if (filterTypeComboBox.SelectedIndex != 2 &&
                    e.Type != filterTypeComboBox.SelectedItem.ToString())
                    return false;

                if (filterCategoryComboBox.SelectedIndex != 5 &&
                    e.Category != filterCategoryComboBox.SelectedItem.ToString())
                    return false;

                return true;
            }).ToList();

            source.DataSource = new BindingList<ExpenseData>(filtered);
            piePanel.Invalidate();
        }

        // ===================== UI =====================
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AlignUi();
        }

        private void AlignUi()
        {
            titleLabel.Location = new Point(
                (topPanel.Width - titleLabel.Width) / 2,
                topPanel.Top + 20);

            foreach (var b in new[] { addButton, clearButton, filterButton, cancelButton })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
            }

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
        }

        private void SetValues()
        {
            typeComboBox.Items.AddRange(new[] { "Income", "Expense" });
            categoryComboBox.Items.AddRange(new[] { "Salary", "Interest", "Food", "Grocery", "Travel" });

            filterTypeComboBox.Items.AddRange(new[] { "Income", "Expense", "None" });
            filterCategoryComboBox.Items.AddRange(new[] { "Salary", "Interest", "Food", "Grocery", "Travel", "None" });

            typeComboBox.SelectedIndex = 0;
            categoryComboBox.SelectedIndex = 0;
            filterTypeComboBox.SelectedIndex = 2;
            filterCategoryComboBox.SelectedIndex = 5;

            amountNumericUpDown.Minimum = 1;
            amountNumericUpDown.Maximum = int.MaxValue;

            startDatTimePicker.ShowCheckBox = true;
            endDateTimePicker.ShowCheckBox = true;
        }

        // ===================== PIE CHART =====================
        private void PaintPage(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(30, 40, 250, 250);

            var data = ((BindingList<ExpenseData>)source.DataSource)
                .GroupBy(x => x.Category)
                .Select(gp => new { Category = gp.Key, Amount = gp.Sum(x => x.Amount) })
                .ToList();

            float total = data.Sum(x => x.Amount);
            if (total <= 0) return;

            Dictionary<string, Color> colors = new()
            {
                { "Food", Color.OrangeRed },
                { "Travel", Color.DodgerBlue },
                { "Grocery", Color.MediumSeaGreen },
                { "Salary", Color.Goldenrod },
                { "Interest", Color.MediumPurple }
            };

            float startAngle = 0;
            foreach (var d in data)
            {
                float sweep = d.Amount / total * 360f;
                using var brush = new SolidBrush(colors[d.Category]);
                g.FillPie(brush, r, startAngle, sweep);
                g.DrawPie(Pens.Black, r, startAngle, sweep);
                startAngle += sweep;
            }
        }

        // ===================== CRUD =====================
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionRichTextBox.Text))
            {
                MessageBox.Show("Fill all fields");
                return;
            }

            if (!isEditing)
            {
                list.Insert(0, new ExpenseData(
                    selectedDateTimePicker.Value.Date,
                    typeComboBox.Text,
                    categoryComboBox.Text,
                    (int)amountNumericUpDown.Value,
                    descriptionRichTextBox.Text));
            }
            else
            {
                selectedData.SelectedDate = selectedDateTimePicker.Value.Date;
                selectedData.Type = typeComboBox.Text;
                selectedData.Category = categoryComboBox.Text;
                selectedData.Amount = (int)amountNumericUpDown.Value;
                selectedData.Description = descriptionRichTextBox.Text;

                isEditing = false;
                selectedData = null;
                addButton.Text = "Add";
            }

            ClearInputs();
            FilterData();
        }

        private void ClearInputs()
        {
            amountNumericUpDown.Value = 1;
            typeComboBox.SelectedIndex = 0;
            categoryComboBox.SelectedIndex = 0;
            descriptionRichTextBox.Clear();
        }

        private void UpdateData()
        {
            if (dataGridView.Columns.Contains("Edit")) return;

            dataGridView.Columns["Id"].Visible = false;

            dataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            });

            dataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });

            dataGridView.CellContentClick += DataGridViewClick;
        }

        private void DataGridViewClick(object s, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = dataGridView.Rows[e.RowIndex].DataBoundItem as ExpenseData;
            if (item == null) return;

            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Delete this record?", "Confirm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list.Remove(item);
                    FilterData();
                }
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                isEditing = true;
                selectedData = item;

                selectedDateTimePicker.Value = item.SelectedDate;
                typeComboBox.Text = item.Type;
                categoryComboBox.Text = item.Category;
                amountNumericUpDown.Value = item.Amount;
                descriptionRichTextBox.Text = item.Description;

                addButton.Text = "Update";
            }
        }

        private void FilterButtonClick(object sender, EventArgs e) => FilterData();

        private void ClearButtonClick(object sender, EventArgs e)
        {
            startDatTimePicker.Checked = false;
            endDateTimePicker.Checked = false;
            filterTypeComboBox.SelectedIndex = 2;
            filterCategoryComboBox.SelectedIndex = 5;
            FilterData();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            isEditing = false;
            selectedData = null;
            addButton.Text = "Add";
            ClearInputs();
        }

        // ===================== SAMPLE DATA =====================
        private void AddSampleData()
        {
            list.Add(new ExpenseData(DateTime.Today.AddDays(-1), "Income", "Salary", 30000, "Salary"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-2), "Expense", "Food", 250, "Lunch"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-3), "Expense", "Travel", 1200, "Bus"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-4), "Expense", "Grocery", 1800, "Groceries"));
            list.Add(new ExpenseData(DateTime.Today.AddDays(-5), "Income", "Interest", 500, "Interest"));
        }
    }
}
