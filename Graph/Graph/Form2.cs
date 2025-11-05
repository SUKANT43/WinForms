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
    public partial class Form2 : Form
    {
        public Form2()
        {
            //Panel p = new Panel();
            //p.Dock = DockStyle.Fill;
            Paint += DrawHome;
            //Controls.Add(p);
        }
        public void DrawHome(object s,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] p1 = {new Point(100,100),new Point(50,200),new Point(150,200)};
            g.FillPolygon(Brushes.LightBlue,p1);
            g.FillRectangle(Brushes.LightGreen,50,200,100,200);
            g.FillRectangle(Brushes.LightSalmon, 150, 200, 300, 200);
            Point[] p2 = { new Point (100,100), new Point(150,200),new Point(450,200),new Point(450,100)};
            g.FillPolygon(Brushes.LightGray, p2);
        }
    }
}
