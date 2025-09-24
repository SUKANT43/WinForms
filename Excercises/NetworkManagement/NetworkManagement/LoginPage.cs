using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkManagement
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        

        int x, y;
        NetworkPage nf = new NetworkPage();
        private void OnLoginBtnClicked(object sender, EventArgs e)
        {
            //if (UserEmailTextBox.Text != "sukant@gmail.com" || UserPasswordTextBox.Text != "sukant")
            //{
            //    MessageBox.Show("Enter valid credentials!");
            //    return;
            //}
            //MessageBox.Show("Login Successfull!");
            //NetworkPage nf = new NetworkPage();
            nf.Show();
            return;
            string dsf = "fds";

            Button button = new Button()
            {
                Text = $"{panel1.Controls.Count + 1}" ,
                Location=new Point(x,y)
            };

            y += button.Height;
            Button button1 = new Button()
            {
                Text = $"{panel1.Controls.Count + 1}",
                Location = new Point(x, y),
                Visible=false,
            };
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button);
            //panel1.Controls.Remove(button1);
            
            y += button.Height;

        }

        private void OnCloseBtnClicked(object sender, EventArgs e)
        {
            nf.Visible = !nf.Visible;
            panel1.Controls.Clear();
            //nf.Hide();
        }
    }
}
