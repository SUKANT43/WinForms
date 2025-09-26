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
    public partial class SignupForm : Form
    {
        private Panel signupPnl;
        private TableLayoutPanel signupFormTblPnl;
        private Label nameLbl, emailLbl, passwordLbl, confirmPasswordLbl;
        private TextBox nameTxt, emailTxt, passwordTxt, confirmPasswordTxt;
        private Button signupButton;
        private LinkLabel loginLbl;
        public SignupForm()
        {
            MaximizeBox = false;
            signupPnl = new Panel
            {
                Dock = DockStyle.Fill,

            };
            signupFormTblPnl = new TableLayoutPanel
            {
                BackColor = Color.AliceBlue,
                ColumnCount = 2,
                RowCount = 6,
                Padding = new Padding(40),
                AutoSize = true,
                Font = new Font("Segoe UI",12, FontStyle.Bold),
                Anchor = AnchorStyles.None

        };

            signupFormTblPnl.Anchor = AnchorStyles.None;
            Resize += (s, e) =>
            {
                signupFormTblPnl.Location = new Point(
                  (signupPnl.Width - signupFormTblPnl.Width) / 2,
                  (signupPnl.Height - signupFormTblPnl.Height) / 2
                   );
                signupFormTblPnl.Anchor = AnchorStyles.None;
            };
            signupFormTblPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,40f));
            signupFormTblPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));
            signupFormTblPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 17f));
            signupFormTblPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 17f));
            signupFormTblPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 17f));
            signupFormTblPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 17f));
            signupFormTblPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 17f));
            signupFormTblPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 17f));
            nameLbl = new Label
            {
                Text = "Name:"
            };
            emailLbl = new Label
            {
                Text = "Email:"
            };
            passwordLbl = new Label
            {
                Text = "Password:"
            };
            confirmPasswordLbl = new Label
            {
                Text = "Confirm Password:",
                AutoSize = true,
            };
            loginLbl = new LinkLabel
            {
                Text = "Login",
                LinkBehavior = LinkBehavior.NeverUnderline,
            };
            nameTxt = new TextBox{ Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12) };
            emailTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12) }; 
            passwordTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12), UseSystemPasswordChar=true }; 
            confirmPasswordTxt = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 12), UseSystemPasswordChar=true };
            signupButton = new Button {Text="Sign Up", AutoSize=true };
            signupFormTblPnl.Controls.Add(nameLbl,0,0);
            signupFormTblPnl.Controls.Add(emailLbl, 0, 1);
            signupFormTblPnl.Controls.Add(passwordLbl, 0, 2);
            signupFormTblPnl.Controls.Add(confirmPasswordLbl, 0, 3);
            signupFormTblPnl.Controls.Add(nameTxt, 1, 0);
            signupFormTblPnl.Controls.Add(emailTxt, 1, 1);
            signupFormTblPnl.Controls.Add(passwordTxt, 1, 2);
            signupFormTblPnl.Controls.Add(confirmPasswordTxt, 1, 3);
            signupFormTblPnl.Controls.Add(signupButton, 1, 4);
            signupFormTblPnl.Controls.Add(loginLbl, 0, 5);
            signupFormTblPnl.Controls.Add(loginLbl, 1, 5);

            signupPnl.Controls.Add(signupFormTblPnl);
            Controls.Add(signupPnl);
            MinimumSize = signupFormTblPnl.PreferredSize;
            MaximumSize = signupFormTblPnl.PreferredSize;

            loginLbl.Click += (s, e) =>
            {
                LoginForm lf = new LoginForm();
                lf.Show();
                Hide();
                
            };
        }
    }
}
