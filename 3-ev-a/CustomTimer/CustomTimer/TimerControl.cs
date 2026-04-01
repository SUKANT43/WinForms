using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CustomTimer
{
    public partial class TimerControl : UserControl
    {
        private Stopwatch stopWatch;
        public TimerControl()
        {
            InitializeComponent();
            Paint += PaintPage;
        }

        private void PaintPage(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DrawPlayButton(g);
            DrawPauseButton(g);
            DrawClearButton(g);

        }
      

        private void DrawPlayButton(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, 50, 50);

            int radius = 10;
            int diameter = radius * 2;

            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            g.DrawPolygon(new Pen(Color.Black,2),new PointF[] {new PointF(rect.X+10,rect.Y+4),new PointF(rect.X+10,rect.Y+44),new PointF((rect.X+(rect.Height/2))+18,rect.Y+(rect.Width/2))});
            g.FillPolygon(Brushes.Red, new PointF[] { new PointF(rect.X + 10, rect.Y + 4), new PointF(rect.X + 10, rect.Y + 44), new PointF((rect.X + (rect.Height / 2)) + 18, rect.Y + (rect.Width / 2)) });


            g.DrawPath(new Pen(Color.Black,2), path);
        }

        private void DrawPauseButton(Graphics g)
        {

        }

        private void DrawClearButton(Graphics g)
        {

        }

    }
}
