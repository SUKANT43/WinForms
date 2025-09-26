using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo.View
{
    public partial class LoginForm : Form
    {
        private Panel loginPnl;
        private TableLayoutPanel loginFormTblLayoutPnl;
        private Label emailLbl, passwordLbl;
        private TextBox emailTxt, passTxt;
        private Button loginBtn;
        private LinkLabel createAccountLbl;

        public LoginForm()
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            loginPnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            loginFormTblLayoutPnl = new TableLayoutPanel
            {
                BackColor = Color.AliceBlue,
                ColumnCount = 2,
                RowCount = 4,
                AutoSize=true,
                Padding=new Padding(100),
            };
            loginFormTblLayoutPnl.Anchor = AnchorStyles.None;

            loginPnl.Resize += (s, e) =>
            {
                loginFormTblLayoutPnl.Location = new Point(
                    (loginPnl.Width - loginFormTblLayoutPnl.Width) / 2,
                    (loginPnl.Height - loginFormTblLayoutPnl.Height) / 2
                );
            };

            loginFormTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
            loginFormTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));

            emailLbl = new Label
            {
                Text = "Email:",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            passwordLbl = new Label
            {
                Text = "Password:",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            createAccountLbl = new LinkLabel
            {
                Text = "Create Account",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                LinkBehavior=LinkBehavior.NeverUnderline,
            };

            emailTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12) };
            passTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12), UseSystemPasswordChar = true };
            loginBtn = new Button { Text = "Login", AutoSize=true, Font = new Font("Segoe UI", 12, FontStyle.Bold),Cursor=Cursors.Hand };

            loginFormTblLayoutPnl.Controls.Add(emailLbl, 0, 0);
            loginFormTblLayoutPnl.Controls.Add(emailTxt, 1, 0);
            loginFormTblLayoutPnl.Controls.Add(passwordLbl, 0, 1);
            loginFormTblLayoutPnl.Controls.Add(passTxt, 1, 1);
            loginFormTblLayoutPnl.Controls.Add(loginBtn, 1, 2);
            loginFormTblLayoutPnl.Controls.Add(createAccountLbl, 0, 3);
            loginFormTblLayoutPnl.Controls.Add(createAccountLbl, 1, 3);


            loginPnl.Controls.Add(loginFormTblLayoutPnl);
            Controls.Add(loginPnl);
            MinimumSize = loginFormTblLayoutPnl.PreferredSize;
            MaximumSize = loginFormTblLayoutPnl.PreferredSize;
            createAccountLbl.Click += (s, e) =>
            {
                SignupForm sf = new SignupForm();
                sf.Show();
                Hide();
            };
        }
    }
}

