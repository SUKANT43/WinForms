using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomButton
{
    class GraphicButton:Control
    {
        private bool isHover;
        private bool isPressed;

        public Color NormalColor { get; set; } = Color.FromArgb(52, 152, 219);

        public Color HoverColor { get; set; } = Color.FromArgb(41, 128, 185);

        public Color PressColor { get; set; } = Color.FromArgb(31, 97, 141);

        public Color BorderColor { get; set; } = Color.Black;

        public int BorderRadius { get; set; } = 20;

        public int BorderSize { get; set; } = 0;

        public override Color ForeColor { get; set; } = Color.Wheat;

        public GraphicButton()
        {
            Size = new Size(150, 50);
            Font = new Font("Segoe UI", 11, FontStyle.Bold);
            Cursor = Cursors.Hand;

            SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint|
                ControlStyles.OptimizedDoubleBuffer|
                ControlStyles.ResizeRedraw|
                ControlStyles.SupportsTransparentBackColor,true);
            BackColor = Color.Transparent;

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isHover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHover = false;
            isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();
            OnClick(e);
        }

        private GraphicsPath GetRoundPath(Rectangle rect,int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectSurface = new Rectangle(0, 0, Width - 1, Height - 1);
            Color backColor = NormalColor;
            if (isPressed) backColor = PressColor;
            else if (isHover) backColor = HoverColor;
            using (GraphicsPath path = GetRoundPath(rectSurface, BorderRadius))
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                g.FillPath(brush, path);

                if (BorderSize > 0)
                {
                    using (Pen pen = new Pen(BorderColor, BorderSize))
                        g.DrawPath(pen, path);
                }
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            using (Brush textBrush = new SolidBrush(ForeColor))
            {
                g.DrawString(Text, Font, textBrush, rectSurface, sf);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

    }
}
