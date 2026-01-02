using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Panels
{
    public partial class RoundedButton : Form
    {
        public RoundedButton()
        {
            InitializeComponent();
            Paint += PagePaint;
        }

        private void PagePaint(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(200, 200, 200, 200);

            int radius = 100;
            int d = radius * 2;

            using (SolidBrush b = new SolidBrush(Color.LightBlue))
            using (Pen p = new Pen(Color.Black, 2))
            {
                GraphicsPath path = new GraphicsPath();

                path.AddArc(r.X, r.Y, d, d, 180, 90);
                path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);

                path.CloseFigure();

                g.FillPath(b, path);
                g.DrawPath(p, path);
            }
        }
    }
}
