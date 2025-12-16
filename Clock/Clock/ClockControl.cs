using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clock
{
    public partial class ClockControl : UserControl
    {
        private Timer timer;

        public ClockControl()
        {
            // Prevent flicker
            DoubleBuffered = true;

            // Default size (IMPORTANT)
            Size = new Size(300, 300);

            // Timer to update clock
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => Invalidate();
            timer.Start();

            Paint += ClockControl_Paint;
        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;

            // Safety guard (prevents Null / size issues)
            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int radius = Math.Min(rect.Width, rect.Height) / 2 - 10;
            if (radius <= 0)
                return;

            Point center = new Point(rect.Width / 2, rect.Height / 2);

            // ================= Clock Face =================
            using (SolidBrush faceBrush = new SolidBrush(Color.LightBlue))
            {
                g.FillEllipse(
                    faceBrush,
                    center.X - radius,
                    center.Y - radius,
                    radius * 2,
                    radius * 2);
            }

            using (Pen borderPen = new Pen(Color.Black, 3))
            {
                g.DrawEllipse(
                    borderPen,
                    center.X - radius,
                    center.Y - radius,
                    radius * 2,
                    radius * 2);
            }

            DrawNumbers(g, center, radius);
            DrawHands(g, center, radius);

            // ================= Center Dot =================
            g.FillEllipse(
                Brushes.Black,
                center.X - 5,
                center.Y - 5,
                10,
                10);
        }

        private void DrawNumbers(Graphics g, Point center, int radius)
        {
            using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                for (int i = 1; i <= 12; i++)
                {
                    double angle = (i - 3) * 30 * Math.PI / 180;

                    int x = center.X + (int)((radius - 30) * Math.Cos(angle));
                    int y = center.Y + (int)((radius - 30) * Math.Sin(angle));

                    string text = i.ToString();
                    SizeF size = g.MeasureString(text, font);

                    g.DrawString(
                        text,
                        font,
                        Brushes.Black,
                        x - size.Width / 2,
                        y - size.Height / 2);
                }
            }
        }

        private void DrawHands(Graphics g, Point center, int radius)
        {
            DateTime now = DateTime.Now;

            double secAngle = (now.Second - 15) * 6 * Math.PI / 180;
            double minAngle = (now.Minute - 15) * 6 * Math.PI / 180;
            double hourAngle =
                ((now.Hour % 12) * 30 + now.Minute / 2 - 90) * Math.PI / 180;

            // Hour hand
            DrawHand(g, center, hourAngle, radius * 0.5f, 6, Color.Black);

            // Minute hand
            DrawHand(g, center, minAngle, radius * 0.7f, 4, Color.Black);

            // Second hand
            DrawHand(g, center, secAngle, radius * 0.85f, 2, Color.Red);
        }

        private void DrawHand(Graphics g, Point center, double angle,
                              float length, int thickness, Color color)
        {
            int x = center.X + (int)(length * Math.Cos(angle));
            int y = center.Y + (int)(length * Math.Sin(angle));

            using (Pen pen = new Pen(color, thickness))
            {
                g.DrawLine(pen, center.X, center.Y, x, y);
            }
        }
    }
}
