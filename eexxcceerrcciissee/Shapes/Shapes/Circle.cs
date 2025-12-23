using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Shapes
{
    class Circle : Shapes
    {
        public float X{get;set;}
        public float Y { get; set; }
        public float Width, Height;
        public override bool IsSelected { get; set; }
        public Circle(float x, float y, float width,float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override void Draw(Graphics g)
        {
            using (Brush b = new SolidBrush(Color.LightBlue))
            {
                g.FillEllipse(b, X, Y, Width,Height);
            }

            using (Pen p = new Pen(IsSelected ? Color.Red : Color.Black, 3))
            {
                g.DrawEllipse(p,  X, Y, Width,Height );

            }
        }

        public override bool Contains(Point p)
        {
            using (GraphicsPath g = new GraphicsPath())
            {
                g.AddEllipse( X, Y, Width, Height);
                return g.IsVisible(p);
            }
        }

        public override void Move(int dx, int dy, Size s)
        {
            float newX = X + dx;
            float newY = Y + dy;

            if (newX < 0) return;
            if (newY < 0) return;

            if (newX + Width > s.Width)
                return;

            if (newY + Height > s.Height)
                return;

            X = newX;
            Y = newY;
        }

        public override void Resize(int dx, int dy,Size s)
        {
            float newX = X + dx;
            float newY = Y + dy;

            if (newX < 0) return;
            if (newY < 0) return;

            if (newX + Width > s.Width)
                return;

            if (newY + Height > s.Height)
                return;

            int d = Math.Max(dx, dy);
            Width += d;
            Height += d;
        }
    }
}
