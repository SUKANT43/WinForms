using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataPanel
{
    public class CustomPanel : UserControl
    {
        private Label descriptionLabel=new Label();
        private Label dateLabel=new Label();
        private Panel mainPanel=new Panel();
        private Button editButton=new Button();
        private Button deleteButton=new Button();

        private UserData _data;

        // Strongly typed events
        public event EventHandler<UserData> EditClicked;
        public event EventHandler<UserData> DeleteClicked;

        public CustomPanel()
        {
            InitializeUI();
        }

        // Data Binding Property
        public UserData Data
        {
            get => _data;
            set
            {
                _data = value;
                BindData();
            }
        }

        private void BindData()
        {
            if (_data == null) return;

            descriptionLabel.Text = _data.Description;
            dateLabel.Text = _data.Date.ToString("dd MMM yyyy");
        }

        private void InitializeUI()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = 70;
            this.BackColor = Color.White;

            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            descriptionLabel = new Label
            {
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true
            };

            dateLabel = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            editButton = new Button
            {
                Text = "Edit",
                Width = 60,
                Height = 30
            };

            deleteButton = new Button
            {
                Text = "Delete",
                Width = 60,
                Height = 30
            };

            // Event wiring with data
            editButton.Click += (s, e) =>
            {
                if (_data != null)
                    EditClicked?.Invoke(this, _data);
            };

            deleteButton.Click += (s, e) =>
            {
                if (_data != null)
                    DeleteClicked?.Invoke(this, _data);
            };

            mainPanel.Controls.Add(descriptionLabel);
            mainPanel.Controls.Add(dateLabel);
            mainPanel.Controls.Add(editButton);
            mainPanel.Controls.Add(deleteButton);

            this.Controls.Add(mainPanel);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            int padding = 10;

            descriptionLabel.Location = new Point(padding, 10);
            dateLabel.Location = new Point(padding, 35);

            int centerY = (this.Height - editButton.Height) / 2;

            deleteButton.Location = new Point(
                this.Width - padding - deleteButton.Width,
                centerY
            );

            editButton.Location = new Point(
                deleteButton.Left - 10 - editButton.Width,
                centerY
            );
        }
    }
}