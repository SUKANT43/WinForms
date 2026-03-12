using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Expense_Tracker.Pages;
namespace Expense_Tracker
{
    public partial class Form1 : Form
    {
        public static Control CurrentPage = new LoginPage();

        public Form1()
        {

            InitializeComponent();

            CurrentPage.Width = this.Width;
            CurrentPage.Height = this.Height;
            this.Controls.Add(CurrentPage);
            DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CurrentPage.Width = this.Width;
            CurrentPage.Height = this.Height;
        }
    }
}
