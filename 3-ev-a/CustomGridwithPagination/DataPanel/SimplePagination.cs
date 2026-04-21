using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataPanel
{
    public class SimplePagination : UserControl
    {
        private Button btnPrev;
        private Button btnNext;
        private Label lblInfo;
        private ComboBox cmbPageSize;

        public event Action<int> PageChanged;
        public event Action<int> PageSizeChanged;

        private int totalRecords = 0;
        private int pageSize = 10;
        private int currentPage = 1;

        public int TotalRecords
        {
            get => totalRecords;
            set { totalRecords = value; UpdateUI(); }
        }

        public int PageSize
        {
            get => pageSize;
            set { pageSize = value; UpdateUI(); }
        }

        public int CurrentPage
        {
            get => currentPage;
            set { currentPage = value; UpdateUI(); }
        }

        private int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

        public SimplePagination()
        {
            Height = 45;
            Dock = DockStyle.Bottom;

            btnPrev = new Button()
            {
                Text = "<<",
                Width = 50,
                Dock = DockStyle.Left
            };

            btnNext = new Button()
            {
                Text = ">>",
                Width = 50,
                Dock = DockStyle.Right
            };

            cmbPageSize = new ComboBox()
            {
                Width = 70,
                Dock = DockStyle.Right,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbPageSize.Items.AddRange(new object[] { 5, 10, 15, 20, 25, 50 });
            cmbPageSize.SelectedItem = pageSize;

            lblInfo = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnPrev.Click += (s, e) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage--;
                    PageChanged?.Invoke(CurrentPage);
                }
            };

            btnNext.Click += (s, e) =>
            {
                if (CurrentPage < TotalPages)
                {
                    CurrentPage++;
                    PageChanged?.Invoke(CurrentPage);
                }
            };

            cmbPageSize.SelectedIndexChanged += (s, e) =>
            {
                PageSize = Convert.ToInt32(cmbPageSize.SelectedItem);
                CurrentPage = 1; // reset page
                PageSizeChanged?.Invoke(PageSize);
                PageChanged?.Invoke(CurrentPage);
            };

            Controls.Add(lblInfo);
            Controls.Add(cmbPageSize);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (TotalRecords == 0)
            {
                lblInfo.Text = "No records";
                return;
            }

            int start = (CurrentPage - 1) * PageSize + 1;
            int end = Math.Min(CurrentPage * PageSize, TotalRecords);

            lblInfo.Text = $"Showing {start}-{end} of {TotalRecords}";

            btnPrev.Enabled = CurrentPage > 1;
            btnNext.Enabled = CurrentPage < TotalPages;
        }
    }
}