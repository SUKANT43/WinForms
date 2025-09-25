using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement.Login
{
    public partial class LoginPage : Form
    {
        private Panel loginPnl;
        private TableLayoutPanel loginFormTblLayoutPnl;
        private Label emailLbl, passwordLbl;
        private TextBox emailTxt, passTxt;
        private Button loginBtn;
        public LoginPage()
        {
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(400,300);
            loginPnl = new Panel
            {
                Dock = DockStyle.Fill,
            };
            loginFormTblLayoutPnl = new TableLayoutPanel
            {
                BackColor = Color.AliceBlue,
                AutoSize = true
            };
            loginFormTblLayoutPnl.Anchor = AnchorStyles.None;


            loginFormTblLayoutPnl.Resize += (s, e) =>
            {
                loginFormTblLayoutPnl.Location = new Point(
                    (loginPnl.Width - loginFormTblLayoutPnl.Width) / 2,
                    (loginPnl.Height - loginFormTblLayoutPnl.Height) / 2
                );
            };

            loginFormTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,40f));
            loginFormTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));

            emailLbl = new Label
            {
                Text = "Email:",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI",12,FontStyle.Bold),
                TextAlign=ContentAlignment.MiddleLeft
            };

            passwordLbl = new Label
            {
                Text = "Password:",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            emailTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12) };
            passTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12), UseSystemPasswordChar = true };
            loginBtn = new Button { Text = "Login", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            Controls.Add(loginPnl);
            loginPnl.Controls.Add(loginFormTblLayoutPnl);
            loginFormTblLayoutPnl.Controls.Add(emailLbl, 0, 0);
            loginFormTblLayoutPnl.Controls.Add(passwordLbl, 0, 1);
            loginFormTblLayoutPnl.Controls.Add(emailTxt, 1, 0);
            loginFormTblLayoutPnl.Controls.Add(passTxt, 1, 1);
            loginFormTblLayoutPnl.Controls.Add(loginBtn, 1, 2);

        }
    }
}
