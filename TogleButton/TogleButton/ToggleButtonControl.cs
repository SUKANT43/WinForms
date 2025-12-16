using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TogleButton
{
    public partial class ToggleButtonControl : UserControl
    {
        private bool isOn;
        private Rectangle toggleRect;

        private Timer animationTimer;
        private int currentThumbX;
        private int targetThumbX;
        private int thumbSize ;

        private  Font textFont;

        public bool IsOn
        {
            get => isOn;
            set
            {
                isOn = value;
                StartAnimation();
                Invalidate();
            }
        }

        public ToggleButtonControl()
        {
            DoubleBuffered = true;
            Size = new Size(80, 35);
            BackColor = Color.Transparent;
            float fontSize = (float)(Height) * 0.35f;

            textFont = new Font("Segoe UI", fontSize, FontStyle.Bold);


            MouseDown += Toggle;

            animationTimer = new Timer { Interval = 10 };
            animationTimer.Tick += AnimateThumb;
            Resize += ManageFontSize;
        }

       public void  ManageFontSize(object s,EventArgs e)
        {
            float fontSize = (float)(Height) * 0.35f;
            textFont = new Font("Segoe UI", fontSize, FontStyle.Bold);
            Validate();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            toggleRect = new Rectangle(
                ClientRectangle.X + 3,
                ClientRectangle.Y + 3,
                ClientRectangle.Width - 6,
                ClientRectangle.Height - 6
            );

            using (GraphicsPath path = GetRoundedRect(toggleRect, toggleRect.Height))
            using (SolidBrush trackBrush = new SolidBrush(isOn ? Color.RoyalBlue : Color.Black))
            {
                g.FillPath(trackBrush, path);
            }

            thumbSize = toggleRect.Height - 6;

            if (currentThumbX == 0)
            {
                currentThumbX = isOn
                    ? toggleRect.Right - thumbSize - 3
                    : toggleRect.Left + 3;
            }

            Rectangle thumbRect = new Rectangle(
                currentThumbX,
                toggleRect.Top + 3,
                thumbSize,
                thumbSize
            );

            using (SolidBrush thumbBrush = new SolidBrush(Color.White))
            {
                g.FillEllipse(thumbBrush, thumbRect);
            }

            DrawText(g);
        }

        private void DrawText(Graphics g)
        {
            string text = isOn ? "ON" : "OFF";

            SizeF textSize = g.MeasureString(text, textFont);

            float x = isOn
                ? toggleRect.Left + 8
                : toggleRect.Right - textSize.Width - 8;

            float y = toggleRect.Top + (toggleRect.Height - textSize.Height) / 2;

            using (Brush textBrush = new SolidBrush(Color.White))
            {
                g.DrawString(text, textFont, textBrush, x, y);
            }
        }

        private void Toggle(object sender, EventArgs e)
        {
            IsOn = !IsOn;
        }

        private void StartAnimation()
        {
            targetThumbX = isOn
                ? toggleRect.Right - thumbSize - 3
                : toggleRect.Left + 3;

            animationTimer.Start();
        }

        private void AnimateThumb(object sender, EventArgs e)
        {
            int speed = 4;

            if (currentThumbX < targetThumbX)
                currentThumbX += speed;
            else if (currentThumbX > targetThumbX)
                currentThumbX -= speed;

            if (Math.Abs(currentThumbX - targetThumbX) <= speed)
            {
                currentThumbX = targetThumbX;
                animationTimer.Stop();
            }

            Invalidate();
        }

        private GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
