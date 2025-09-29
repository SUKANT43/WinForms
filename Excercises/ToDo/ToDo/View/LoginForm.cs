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
        private Label emailLbl, passwordLbl,CloseLbl;
        private TextBox emailTxt, passTxt;
        private Button loginBtn;
        private LinkLabel createAccountLbl;
        
        public LoginForm()
        {
            MaximizeBox = false;
            FormClosing += (s, e) =>
            {
                Application.Exit();
            };
            StartPosition = FormStartPosition.CenterScreen;
            loginPnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,

            };

            loginFormTblLayoutPnl = new TableLayoutPanel
            {
                BackColor = Color.AliceBlue,
                ColumnCount = 3,
                RowCount = 5,
                AutoSize=true,
                Padding = new Padding(50),

            };
            loginFormTblLayoutPnl.Anchor = AnchorStyles.None;

            loginPnl.Resize += (s, e) =>
            {
                loginFormTblLayoutPnl.Location = new Point(
                    (loginPnl.Width - loginFormTblLayoutPnl.Width) / 2,
                    (loginPnl.Height - loginFormTblLayoutPnl.Height) / 2
                );
            };

            loginFormTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
            loginFormTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75f));
            loginFormTblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0f));

            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            loginFormTblLayoutPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));

            emailLbl = new Label
            {
                Text = "Email:",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            passwordLbl = new Label
            {
                Text = "Password:",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            createAccountLbl = new LinkLabel
            {
                Text = "Create Account",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                LinkBehavior=LinkBehavior.NeverUnderline,
            };
            //CloseLbl = new Label
            //{
            //    Text = "X",
            //    ForeColor = Color.Red,
            //    Font = new Font("Segoe UI", 12, FontStyle.Bold),
            //    AutoSize = true,
            //    Cursor = Cursors.Hand,
            //    Location = new Point(this.Width - 25, 5),
            //    Anchor = AnchorStyles.None,
            //    //TextAlign= ContentAlignment.TopRight
            //};

            emailTxt = new TextBox { Dock=DockStyle.Fill, Font = new Font("Segoe UI", 12) };
            passTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12), UseSystemPasswordChar = true };
            loginBtn = new Button { Text = "Login", AutoSize=true, Font = new Font("Segoe UI", 12, FontStyle.Bold),Cursor=Cursors.Hand,TextAlign= ContentAlignment.MiddleCenter };

            loginFormTblLayoutPnl.Controls.Add(emailLbl, 0, 1);
            loginFormTblLayoutPnl.Controls.Add(emailTxt, 1, 1);
            loginFormTblLayoutPnl.Controls.Add(passwordLbl, 0, 2);
            loginFormTblLayoutPnl.Controls.Add(passTxt, 1, 2);
            loginFormTblLayoutPnl.Controls.Add(loginBtn, 1, 3);
            loginFormTblLayoutPnl.Controls.Add(createAccountLbl, 1, 4);
            //loginFormTblLayoutPnl.Controls.Add(CloseLbl, 2, 0);

            //loginPnl.Controls.Add(CloseLbl);
            loginPnl.Controls.Add(loginFormTblLayoutPnl);
            Controls.Add(loginPnl);
            MinimumSize = loginFormTblLayoutPnl.PreferredSize;
            MaximumSize = loginFormTblLayoutPnl.PreferredSize;
            createAccountLbl.Click += (s, e) =>
            {
                Hide();
                SignupForm sf = new SignupForm();
                sf.Show();
            };
        }
    }
}

