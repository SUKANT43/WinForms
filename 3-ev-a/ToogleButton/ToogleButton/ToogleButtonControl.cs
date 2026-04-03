using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace ToogleButton
{
    class ToogleButtonControl : Control
    {
        Rectangle outerRectangle;
        Rectangle circleRectangle;
        Color primaryColor = Color.FromArgb(0, 122, 204);
        bool isClick;
        bool isOn = false;
        Timer timer;

        public ToogleButtonControl()
        {
            DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += TimerTick;
            Paint += PaintPage;
            UpdateSize();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateSize();
            Invalidate();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            UpdateSize();
            Invalidate();
        }


        private void UpdateSize()
        {
            outerRectangle = new Rectangle(1, 1, Width - 3, Height - 3);
            circleRectangle = new Rectangle(2, 2, Width / 4, Height - 3);
        }

        private void PaintPage(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawOuterLine(g);
            DrawInnerCircle(g);
            DrawText(g);
        }

        private void DrawText(Graphics g)
        {
            string text = "";
            using (Font font = new Font("Arial", Height / 2, FontStyle.Bold))
            {
                using (Brush brush = new SolidBrush(primaryColor))
                {
                    if (isOn)
                    {
                        text = "On";
                    }
                    if (!isOn)
                    {
                        text = "Off";
                    }

                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, brush, ((outerRectangle.Width) / 2) - (textSize.Width / 2), ((outerRectangle.Height) / 2) - (textSize.Height / 2));

                }
            }
        }

        private void DrawInnerCircle(Graphics g)
        {
            int radius = outerRectangle.Height / 2;
            int diameter = radius * 2;

            if (isClick)
            {
                if (circleRectangle.X >= outerRectangle.Right - circleRectangle.Width - 5 && isOn)
                {
                    timer.Stop();
                }

                if (circleRectangle.X <= outerRectangle.X + 6 && !isOn)
                {
                    timer.Stop();
                }

                if (isOn)
                {
                    circleRectangle.X += 5;
                }

                if (!isOn)
                {
                    circleRectangle.X -= 5;
                }

                using (Brush brush = new SolidBrush(primaryColor))
                {
                    g.FillEllipse(brush, circleRectangle);
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(primaryColor))
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddArc(circleRectangle.X, circleRectangle.Y, diameter, diameter, 180, 90);
                        path.AddArc(circleRectangle.Right - diameter, circleRectangle.Y, diameter, diameter, 270, 90);
                        path.AddArc(circleRectangle.Right - diameter, circleRectangle.Bottom - diameter, diameter, diameter, 0, 90);
                        path.AddArc(circleRectangle.X, circleRectangle.Bottom - diameter, diameter, diameter, 90, 90);
                        path.CloseFigure();

                        g.FillEllipse(brush, circleRectangle);

                    }
                }
            }
        }

        private void DrawOuterLine(Graphics g)
        {
            int radius = outerRectangle.Height / 2;
            int diameter = radius * 2;

            using (Pen p = new Pen(primaryColor, 2))
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(outerRectangle.X, outerRectangle.Y, diameter, diameter, 180, 90);
                path.AddArc(outerRectangle.Right - diameter, outerRectangle.Y, diameter, diameter, 270, 90);
                path.AddArc(outerRectangle.Right - diameter, outerRectangle.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(outerRectangle.X, outerRectangle.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                g.DrawPath(p, path);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (outerRectangle.Contains(e.Location))
            {
                isClick = true;
                isOn = !isOn;
                timer.Start();
            }
        }

    }
}
