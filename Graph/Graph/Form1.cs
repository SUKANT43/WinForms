using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Paint += Basics;
            Paint += Shapes;
        }

        private void Basics(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, 100, 100, 100,200);
        }

        private void Shapes(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Red, 50, 50, 100, 60);
            g.FillEllipse(Brushes.Blue, 200, 50, 100, 60);
            Point[] pts = { new Point(100, 150), new Point(150, 200), new Point(50, 200) };
            g.FillPolygon(Brushes.Green, pts);
            Pen p = new Pen(Color.Purple,20);
            g.DrawEllipse(p, 50, 50, 100, 100);
            Brush b = new SolidBrush(Color.Orange);
            g.FillRectangle(b, 300, 400, 500, 500);
            g.DrawString("Hello Graphics!", new Font("Arial", 14, FontStyle.Bold), Brushes.DarkBlue, 100, 150);
        }
    }
}
