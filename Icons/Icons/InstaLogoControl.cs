using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icons
{
    public partial class InstaLogoControl : UserControl
    {
        private Rectangle baseRectangle;
        private Rectangle insideLineRectangle;
        private Rectangle insideInLineLineRectangle;
        private int circleX,circleY;

        public InstaLogoControl()
        {
            InitializeComponent();
            MinimumSize = new Size();
            //MaximumSize = new Size();
            DoubleBuffered=true;
            baseRectangle = new Rectangle();
            baseRectangle.Size = new Size(Width, Height);

            insideLineRectangle = new Rectangle();
            insideLineRectangle.Size = new Size(Width-22,Height-22);
            insideLineRectangle.Location = new Point(
                baseRectangle.X+10,
                baseRectangle.Y+10
                );

            insideInLineLineRectangle = new Rectangle();
            insideInLineLineRectangle.Size = new Size(Width - 66, Height - 66);
            insideInLineLineRectangle.Location = new Point(
            baseRectangle.X + 30,
            baseRectangle.Y + 30
            );
            circleX = insideLineRectangle.Right - 30;
            circleY = insideLineRectangle.Top + 14;
            Paint += PaintLogo;
            Resize += PageResize;
        }

        public void PageResize(object s,EventArgs e)
        {
            baseRectangle.Size=new Size(Width, Height);

            insideLineRectangle.Size = new Size(Width-22 , Height-22 );
            insideLineRectangle.Location = new Point(
                baseRectangle.X + 10,
                baseRectangle.Y + 10
                );

            insideInLineLineRectangle.Size = new Size(Width - 66, Height - 66);
            insideInLineLineRectangle.Location = new Point(
            baseRectangle.X + 30,
            baseRectangle.Y + 30
            );

            circleX = insideLineRectangle.Right - 30;
            circleY = insideLineRectangle.Top + 14;


            Invalidate();
        }

        private void PaintLogo(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = MakeBorderCurve(Height / 2, baseRectangle))
            {
                using (Brush b = new SolidBrush(Color.FromArgb(255, 225, 48, 108)))
                {
                    g.FillPath(b, path);
                }
            }


            
            using(GraphicsPath path = MakeBorderCurve(Height / 2, insideLineRectangle))
            {
                using(Pen p=new Pen(Color.White,2))
                {
                    g.DrawPath(p, path);
                }
            }

            using (GraphicsPath path = MakeBorderCurve(Height / 2, insideInLineLineRectangle))
            {
                using (Pen p = new Pen(Color.White,2))
                {
                    g.DrawPath(p, path);
                }
            }

            using(Brush b=new SolidBrush(Color.White))
            {
                g.FillEllipse(b,circleX,circleY,9,9);
            }
        }

        private void MakeLine(Graphics g)
        {
            using(Pen p=new Pen(Color.Black))
            {
                MessageBox.Show("");
                g.DrawLine(p,
                    baseRectangle.X+20
                    , baseRectangle.Y + 20
                    , baseRectangle.X + 20
                    , baseRectangle.Bottom-30);
            }
        }

        private GraphicsPath MakeBorderCurve(int radius, Rectangle r)
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

