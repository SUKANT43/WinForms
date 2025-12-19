using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Icons
{
    public partial class RssIconControl : UserControl
    {
        private Rectangle circleRectangle;
        private Rectangle curve1Rectangle;
        private Rectangle curve2Rectangle;

        public RssIconControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.LimeGreen;

            circleRectangle = new Rectangle();
            circleRectangle.Size = new Size(Width - ((Width * 25) / 100), Height - ((Height * 25) / 100));


        }

        protected override void OnResize(EventArgs e)
        {
            circleRectangle.Size = new Size(Width - ((Width * 25) / 100), Height - ((Height * 25) / 100));
            Validate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int circleSize = Math.Min(Width, Height) * 75 / 100;
            int cx = (Width - circleSize) / 2;
            int cy = (Height - circleSize) / 2;

            circleRectangle = new Rectangle(cx, cy, circleSize, circleSize);

            using (Brush b = new SolidBrush(Color.FromArgb(230, 126, 66)))
                g.FillEllipse(b, circleRectangle);

            int startAngle = 225;   
            int sweepAngle = 90;

            using (Pen p = new Pen(Color.White, circleSize * 0.08f))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;

                int pad1 = circleSize / 6;
                curve1Rectangle = new Rectangle(
                    circleRectangle.Left + pad1,
                    circleRectangle.Top + pad1,
                    circleRectangle.Width - pad1 * 2,
                    circleRectangle.Height - pad1 * 2
                );

                g.DrawArc(p, curve1Rectangle, startAngle, sweepAngle);

                int pad2 = circleSize / 3;
                curve2Rectangle = new Rectangle(
                    circleRectangle.Left + pad2,
                    circleRectangle.Top + pad2,
                    circleRectangle.Width - pad2 * 2,
                    circleRectangle.Height - pad2 * 2
                );

                g.DrawArc(p, curve2Rectangle, startAngle, sweepAngle);
            }

            float dotSize = circleSize * 0.12f;
            using (Brush wb = new SolidBrush(Color.White))
            {
                g.FillEllipse(
                    wb,
                    (Width-dotSize)/2,
                   ((Height - dotSize) / 2)+4,
                    dotSize,
                    dotSize
                );
            }
        }

    }
}
