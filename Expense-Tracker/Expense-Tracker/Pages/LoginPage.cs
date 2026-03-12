using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Expense_Tracker.Pages
{
    public partial class LoginPage : UserControl
    {
       
        public LoginPage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += LoginPagePaint;
        }

        public void LoginPagePaint(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.SkyBlue,
                Color.LightGray,
                LinearGradientMode.BackwardDiagonal
                );
            g.FillRectangle(brush, this.ClientRectangle);
        }



    }
}
