using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;
namespace Shapes
{
    class Triangle:Shapes
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        

        public override bool IsSelected { get; set; }
        public Triangle(Point p1,Point p2,Point p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public override void Draw(Graphics g)
        {
            using (Brush b = new SolidBrush(Color.LightBlue))
            {
                g.FillPolygon(b, new[] { P1, P2, P3 });
            }

            using (Pen p = new Pen(IsSelected?Color.Red:Color.Black,3))
            {
                g.DrawPolygon(p,new[] { P1,P2,P3});

            }

        }

        public override bool Contains(Point p)
        {
            using(GraphicsPath g=new GraphicsPath())
            {
                g.AddPolygon(new[] { P1,P2,P3});
                return g.IsVisible(p);
            }
        }

        public override void Move(int dx, int dy,Size s)
        {
            int w = s.Width;
            int h = s.Height;
            if (P1.X+dx > w || P2.X+dx > w || P3.X+dx > w || P1.Y+dy > h || P2.Y+dy > h || P3.Y+dy > h || P1.X+dx < 0 || P2.X+dx < 0 || P3.X+dx < 0 || P1.Y+dy < 0 || P2.Y+dy < 0 || P3.Y+dy < 0)
            {
                return;
            }
            P1 = new Point(P1.X + dx, P1.Y + dy);
            P2 = new Point(P2.X + dx, P2.Y + dy);
            P3 = new Point(P3.X + dx, P3.Y + dy);
        }

        public override void Resize(int dx, int dy,Size s)
        {
            int w = s.Width;
            int h = s.Height;
            if (P1.X + dx > w || P2.X + dx > w || P3.X + dx > w || P1.Y + dy > h || P2.Y + dy > h || P3.Y + dy > h || P1.X + dx < 0 || P2.X + dx < 0 || P3.X + dx < 0 || P1.Y + dy < 0 || P2.Y + dy < 0 || P3.Y + dy < 0)
            {
                return;
            }

            P2 = new Point(P2.X+dx, P2.Y+dx);
            P3 = new Point(P3.X+dx, P2.Y+dx);

        }
    }
}
