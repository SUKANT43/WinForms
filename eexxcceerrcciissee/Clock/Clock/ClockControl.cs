using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class ClockControl : UserControl
    {
        Timer time = new Timer();

        public ClockControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            time.Interval = 100;
            time.Tick += (s, e) => { Invalidate(); };
            time.Start();
            Paint += PaintPage;
        }

        protected  void PaintPage(object s,PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int size = Math.Min(Width, Height) - 10;
            int dx = Width / 2;
            int dy = Height / 2;
            int radius = size / 2;

            g.FillEllipse(Brushes.SkyBlue, dx-radius, dy-radius, size, size);
            g.DrawEllipse(new Pen(Color.Black,3), dx - radius, dy - radius, size, size);

            for(int i = 1; i <= 12; i++)
            {
                double angle = (double)(Math.PI / 6 * i) - Math.PI / 2;
                int x = dx + (int)((radius - 25) * Math.Cos(angle));
                int y = dy + (int)((radius - 25) * Math.Sin(angle));
                string t = i.ToString();
                SizeF sizeF = g.MeasureString(t, Font);
                g.DrawString(
                    t,Font,Brushes.Black,x-sizeF.Width/2,y-sizeF.Height/2
                    );
            }
            DateTime now = DateTime.Now;

            DrawHand(g,dx, dy, radius - 20, now.Second * 6, Pens.Red);

            DrawHand(g, dx, dy, radius - 40, now.Minute * 6, new Pen(Color.Black, 3));

            DrawHand(g, dx, dy, radius - 60,
                (now.Hour % 12) * 30 + now.Minute * 0.5f,
                new Pen(Color.Black, 5));

        }

        private void DrawHand(Graphics g, int cx, int cy, int length, double angleDeg, Pen pen)
        {
            double angle = (Math.PI / 180 * angleDeg) - Math.PI / 2;
            int x = cx + (int)(length * Math.Cos(angle));
            int y = cy + (int)(length * Math.Sin(angle));

            g.DrawLine(pen, cx, cy, x, y);
        }

    }
}
