using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf
{
    public partial class Form5 : Form
    {
        private TableLayoutPanel layout;
        private Label lblUsername, lblPassword;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin;
        public Form5()
        {
            InitializeComponent();
            this.Text = "Login Page";
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(400, 300);
            layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));

                        lblUsername = new Label
            {
                Text = "Username:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            txtUsername = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12)
            };

            // Password
            lblPassword = new Label
            {
                Text = "Password:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            txtPassword = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12),
                UseSystemPasswordChar = true
            };

            // Login Button
            btnLogin = new Button
            {
                Text = "Login",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.LightBlue
            };

            // Add controls
            layout.Controls.Add(lblUsername, 0, 0);
            layout.Controls.Add(txtUsername, 1, 0);
            layout.Controls.Add(lblPassword, 0, 1);
            layout.Controls.Add(txtPassword, 1, 1);
            layout.Controls.Add(btnLogin, 0, 2);
            layout.SetColumnSpan(btnLogin, 2); // Button spans 2 columns

            this.Controls.Add(layout);

        }
    }
}
