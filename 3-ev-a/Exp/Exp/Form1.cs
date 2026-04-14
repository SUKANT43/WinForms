using Exp.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            LoadPage(new LoginPage(), new Size(600, 450));
        }

        public void LoadPage(UserControl page, Size size)
        {
            mainPanel.Controls.Clear();

            page.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(page);

            this.Size = size;
            this.CenterToScreen();

        }
    }
}
