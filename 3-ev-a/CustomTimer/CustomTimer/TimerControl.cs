using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomTimer
{
    public partial class TimerControl : UserControl
    {
        private Stopwatch stopWatch;
        private Timer uiTimer;
        private bool isRunning;

        private Rectangle playPauseRect = new Rectangle(20, 60, 60, 60);
        private Rectangle resetRect = new Rectangle(100, 60, 60, 60);

        public TimerControl()
        {
            InitializeComponent();

            DoubleBuffered = true;

            stopWatch = new Stopwatch();

            uiTimer = new Timer();
            uiTimer.Interval = 100;
            uiTimer.Tick += (s, e) => Invalidate();

            Paint += PaintPage;
        }

        private void PaintPage(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DrawTime(g);

            if (isRunning)
                DrawPauseButton(g);
            else
                DrawPlayButton(g);

            DrawResetButton(g);
        }

        private void DrawTime(Graphics g)
        {
            string time = stopWatch.Elapsed.ToString(@"hh\:mm\:ss\:fff");

            using (Font font = new Font("Arial", 18, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                g.DrawString(time, font, brush, 20, 20);
            }
        }

        private void DrawPlayButton(Graphics g)
        {
            DrawRoundedRect(g, playPauseRect);

            PointF[] triangle =
            {
                new PointF(playPauseRect.X + 18, playPauseRect.Y + 10),
                new PointF(playPauseRect.X + 18, playPauseRect.Bottom - 10),
                new PointF(playPauseRect.Right - 15, playPauseRect.Y + playPauseRect.Height / 2)
            };

            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawPolygon(pen, triangle);
                g.FillPolygon(Brushes.Red, triangle);
            }
        }

        private void DrawPauseButton(Graphics g)
        {
            DrawRoundedRect(g, playPauseRect);

            using (Pen pen = new Pen(Color.Black, 3))
            {
                g.DrawLine(
                    pen,
                    playPauseRect.X + 18,
                    playPauseRect.Y + 10,
                    playPauseRect.X + 18,
                    playPauseRect.Bottom - 10);

                g.DrawLine(
                    pen,
                    playPauseRect.X + 38,
                    playPauseRect.Y + 10,
                    playPauseRect.X + 38,
                    playPauseRect.Bottom - 10);
            }
        }

        private void DrawResetButton(Graphics g)
        {
            DrawRoundedRect(g, resetRect);

            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawLine(
                    pen,
                    resetRect.X + 15,
                    resetRect.Y + 15,
                    resetRect.Right - 15,
                    resetRect.Bottom - 15);

                g.DrawLine(
                    pen,
                    resetRect.Right - 15,
                    resetRect.Y + 15,
                    resetRect.X + 15,
                    resetRect.Bottom - 15);
            }
        }

        private void DrawRoundedRect(Graphics g, Rectangle rect)
        {
            int radius = 10;
            int diameter = radius * 2;

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(Color.Black, 2))
            {
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

                path.CloseFigure();

                g.DrawPath(pen, path);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (playPauseRect.Contains(e.Location))
            {
                if (!isRunning)
                {
                    stopWatch.Start();
                    uiTimer.Start();
                    isRunning = true;
                }
                else
                {
                    stopWatch.Stop();
                    uiTimer.Stop();
                    isRunning = false;
                }

                Invalidate();
            }
            else if (resetRect.Contains(e.Location))
            {
                stopWatch.Reset();
                uiTimer.Stop();
                isRunning = false;

                Invalidate();
            }
        }
    }
}