using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panels
{
    public partial class BellIcon : Form
    {
        public BellIcon()
        {
            InitializeComponent();
            Paint += PagePaint;
        }
        public void PagePaint(object s,PaintEventArgs e) {
           
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using(Pen p=new Pen(Color.Black, 3))
            {
                g.DrawArc(p, 200, 200,75,125, 150, 240);
                g.DrawArc(p, 200, 275, 75, 10, 0, 180);
                g.DrawArc(p, 200, 280, 75, 10, 0, 180);
                g.DrawArc(p, 200, 280, 5, 5, 90 ,95 );
                g.DrawArc(p, 275, 280, 5, 5, 95, 90);
                g.DrawEllipse(p, 233, 190, 10, 10);
            }
        }
    }
}
