using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LineDrawing
{
    public partial class Form1 : Form
    {
        List<Point> ls = new List<Point>();
        bool makePoint = false;
        bool drawLine = false;
        Timer tm = new Timer();
        int timerCondition = 100;

        public Form1()
        {
            InitializeComponent();
            Paint += FormPaint;
            MouseDoubleClick += FormDoubleClick;
            MouseDown += FormClick;
            tm.Tick += OnTimerEvent;
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (makePoint)
            {
                foreach (var p in ls)
                    g.FillEllipse(Brushes.Black, p.X - 2, p.Y - 2, 5, 5);
            }

            Pen normalPen = new Pen(Color.Black, 2);
            Pen overlapPen = new Pen(Color.Orange, 2);
            Pen detectPen = new Pen(Color.Black, 2);

            GraphicsPath gp = new GraphicsPath();

            if (drawLine && ls.Count > 1)
            {

                for (int i = 1; i <= timerCondition && i < ls.Count; i++)
                {
                    bool overlapped = IsOverlaped(gp, detectPen, ls[i - 1], ls[i]);

                    if (overlapped)
                        g.DrawLine(overlapPen, ls[i - 1], ls[i]);
                    else
                        g.DrawLine(normalPen, ls[i - 1], ls[i]);

                    gp.AddLine(ls[i - 1], ls[i]);
                }

                if (timerCondition >= ls.Count && ls.Count > 2)
                {
                    bool overlapped = IsOverlaped(gp, detectPen, ls[ls.Count - 1], ls[0]);
                    if (overlapped)
                        g.DrawLine(overlapPen, ls[ls.Count - 1], ls[0]);
                    else
                        g.DrawLine(normalPen, ls[ls.Count - 1], ls[0]);
                }
            }
        }

        private bool IsOverlaped(GraphicsPath gp, Pen p, Point p1, Point p2)
        {
            int dx = Math.Abs(p2.X - p1.X);
            int dy = Math.Abs(p2.Y - p1.Y);
            int steps = Math.Max(dx, dy);

            float xInc = (p2.X - p1.X) / (float)steps;
            float yInc = (p2.Y - p1.Y) / (float)steps;

            float x = p1.X;
            float y = p1.Y;

            for (int i = 0; i <= steps; i++)
            {
                if (gp.IsOutlineVisible(new PointF(x - 8, y - 8), p))
                    return true;

                x += xInc;
                y += yInc;
            }

            return false;
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            if (timerCondition <= ls.Count)
            {
                timerCondition++;
                Invalidate();
            }
            else
            {
                tm.Stop();
            }
        }

        private void FormDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show($"{ls.Count}");
                makePoint = true;
                drawLine = true;
                Invalidate();

                if (ls.Count > 1)
                {
                    timerCondition = 1;
                    tm.Start();
                }
            }
        }

        private void FormClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timerCondition = 0;
                makePoint = true;
                drawLine = false;
                ls.Add(e.Location);
                Invalidate();
            }
        }
    }
}
