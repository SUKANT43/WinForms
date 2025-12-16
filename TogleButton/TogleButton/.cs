using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TogleButton
{
    public partial class ToggleSwitch : Control
    {
        public bool IsOn { get; private set; } = false;

        public event EventHandler Toggled;

        public Color OnColor { get; set; } = Color.MediumSeaGreen;
        public Color OffColor { get; set; } = Color.Gray;
        public Color ThumbColor { get; set; } = Color.White;

        public ToggleSwitch()
        {
            Size = new Size(60, 30);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle track = new Rectangle(0, 0, Width - 1, Height - 1);
            int thumbSize = Height - 4;

            // Track
            using (GraphicsPath path = GetRoundedRect(track, Height))
            using (SolidBrush brush = new SolidBrush(IsOn ? OnColor : OffColor))
            {
                g.FillPath(brush, path);
            }

            // Thumb
            int thumbX = IsOn ? Width - thumbSize - 2 : 2;
            Rectangle thumb = new Rectangle(thumbX, 2, thumbSize, thumbSize);

            using (SolidBrush thumbBrush = new SolidBrush(ThumbColor))
            {
                g.FillEllipse(thumbBrush, thumb);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            IsOn = !IsOn;
            Invalidate();
            Toggled?.Invoke(this, EventArgs.Empty);
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
