using System;
using System.Windows.Forms;

namespace CrudWinforms
{
    public partial class CrudPage : UserControl
    {
        public CrudPage()
        {
            InitializeComponent();

            dataControl1.Clicked += OnRowClicked;
            searchTextBox.TextChanged += SearchBoxTextChanged;
        }

        // 🔍 FILTER
        private void SearchBoxTextChanged(object sender, EventArgs e)
        {
            dataControl1.ApplyFilter(searchTextBox.Text);
        }

        // 🗑 DELETE (on row click)
        private void OnRowClicked(UserData obj)
        {
            var confirm = MessageBox.Show("Delete this item?", "Confirm", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                DataController.DataList.Remove(obj);
            }
        }

        // ➕ CREATE
        private void CreateDataClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                return;

            DataController.DataList.Add(new UserData()
            {
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text
            });

            nameTextBox.Clear();
            descriptionTextBox.Clear();
        }
    }
}