using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Panels
{
    public class RoundedButton : Button
    {
        private bool isHovered = false;
        private bool isPressed = false;

        public int BorderRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.Black;
        public int BorderThickness { get; set; } = 2;

        public Color NormalBackColor { get; set; } = Color.LightBlue;
        public Color HoverBackColor { get; set; } = Color.DeepSkyBlue;
        public Color PressedBackColor { get; set; } = Color.DodgerBlue;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = Color.Black;

            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            int radius = Math.Min(BorderRadius, Height / 2);

            using (GraphicsPath path = GetRoundedPath(rect, radius))
            {
                Region = new Region(path);

                Color fillColor = NormalBackColor;
                if (isPressed)
                    fillColor = PressedBackColor;
                else if (isHovered)
                    fillColor = HoverBackColor;

                using (SolidBrush brush = new SolidBrush(fillColor))
                    e.Graphics.FillPath(brush, path);

                using (Pen pen = new Pen(BorderColor, BorderThickness))
                    e.Graphics.DrawPath(pen, path);

                TextRenderer.DrawText(
                    e.Graphics,
                    Text,
                    Font,
                    rect,
                    ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
