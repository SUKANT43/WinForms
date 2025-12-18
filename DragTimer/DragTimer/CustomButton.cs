using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DragTimer
{
    public partial class CustomButton : UserControl
    {
        private Color backgroundColor = Color.SkyBlue;
        private Color textColor = Color.Black;
        private float textSize = 10f;
        private int cornerRadius = 20;

        private Font textFont;

        [Category("Appearance")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public float TextSize
        {
            get => textSize;
            set
            {
                textSize = value;
                UpdateFont();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public int CornerRadius
        {
            get => cornerRadius;
            set
            {
                cornerRadius = value;
                Invalidate();
            }
        }

        public CustomButton()
        {
            DoubleBuffered = true;
            Size = new Size(160, 50);
            Cursor = Cursors.Hand;

            UpdateFont();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;

            using (GraphicsPath path = CreateRoundedRectangle(rect, cornerRadius))
            using (SolidBrush bgBrush = new SolidBrush(backgroundColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                g.FillPath(bgBrush, path);

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                g.DrawString(Text, textFont, textBrush, rect, sf);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        private void UpdateFont()
        {
            textFont?.Dispose();
            textFont = new Font("Segoe UI", textSize, FontStyle.Bold);
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
