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
        private Label textLabel;

        private Timer animationTimer;
        private int currentThumbX;
        private int targetThumbX;
        private int thumbSize;

        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                StartAnimation();
                UpdateLabel();
            }
        }

        public ToggleButtonControl()
        {
            DoubleBuffered = true;
            Size = new Size(100, 35);
            BackColor = Color.Transparent;

            textLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.Transparent,
            };

            Controls.Add(textLabel);

            MouseDown += Toggle;
            textLabel.Click += Toggle;

            animationTimer = new Timer
            {
                Interval = 10 
            };
            animationTimer.Tick += AnimateThumb;

            UpdateLabel();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

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

        private void UpdateLabel()
        {
            textLabel.Text = isOn ? "ON" : "OFF";
            textLabel.Location = isOn
                ? new Point(8, Height / 2 - textLabel.Height / 2)
                : new Point(Width - textLabel.Width - 8, Height / 2 - textLabel.Height / 2);
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
