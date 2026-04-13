using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cloc
{
    public class ClockControl : Control
    {
        private readonly Timer timer;

        public ClockControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => Invalidate();
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DrawClock(g);
        }

        private void DrawClock(Graphics g)
        {
            int size = Math.Min(Width, Height) - 20;

            Rectangle rect = new Rectangle(
                (Width - size) / 2,
                (Height - size) / 2,
                size,
                size
            );

            using (Pen borderPen = new Pen(Color.Black, 3))
            {
                g.DrawEllipse(borderPen, rect);
            }

            Point center = new Point(
                rect.X + rect.Width / 2,
                rect.Y + rect.Height / 2
            );

            int radius = size / 2 - 15;

            DrawHourMarks(g, center, radius);
            DrawNumbers(g, center, radius);
            DrawHands(g, center, radius);

            g.FillEllipse(Brushes.Black,
                center.X - 4,
                center.Y - 4,
                8,
                8);
        }

        private void DrawHourMarks(Graphics g, Point center, int radius)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < 12; i++)
                {
                    double angle = (Math.PI / 180) * (i * 30 - 90);

                    int x1 = center.X + (int)((radius - 10) * Math.Cos(angle));
                    int y1 = center.Y + (int)((radius - 10) * Math.Sin(angle));

                    int x2 = center.X + (int)(radius * Math.Cos(angle));
                    int y2 = center.Y + (int)(radius * Math.Sin(angle));

                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        private void DrawNumbers(Graphics g, Point center, int radius)
        {
            Font font = new Font("Arial", 10, FontStyle.Bold);

            for (int i = 1; i <= 12; i++)
            {
                double angle = (Math.PI / 180) * (i * 30 - 90);

                int x = center.X + (int)((radius - 25) * Math.Cos(angle));
                int y = center.Y + (int)((radius - 25) * Math.Sin(angle));

                string text = i.ToString();
                SizeF textSize = g.MeasureString(text, font);

                g.DrawString(
                    text,
                    font,
                    Brushes.Black,
                    x - textSize.Width / 2,
                    y - textSize.Height / 2
                );
            }
        }

        private void DrawHands(Graphics g, Point center, int radius)
        {
            DateTime now = DateTime.Now;

            double secondAngle = now.Second * 6 - 90;
            double minuteAngle = now.Minute * 6 - 90;
            double hourAngle = (now.Hour % 12) * 30 + now.Minute * 0.5 - 90;

            DrawHand(g, center, radius - 40, hourAngle, 4, Color.Black);
            DrawHand(g, center, radius - 25, minuteAngle, 3, Color.Black);
            DrawHand(g, center, radius - 15, secondAngle, 1, Color.Red);
        }

        private void DrawHand(Graphics g, Point center, int length, double angleDeg, int thickness, Color color)
        {
            double angle = Math.PI / 180 * angleDeg;

            int x = center.X + (int)(length * Math.Cos(angle));
            int y = center.Y + (int)(length * Math.Sin(angle));

            using (Pen pen = new Pen(color, thickness))
            {
                g.DrawLine(pen, center.X, center.Y, x, y);
            }
        }
    }
}