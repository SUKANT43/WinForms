using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace ShapeDrawing
{
    public partial class Form1 : Form
    {
        List<Shape> shapeList = new List<Shape>();
        bool isDragging = false;
        Shape selectedShape = null;
        Point lastMousePos;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty|
                System.Reflection.BindingFlags.Instance|
                System.Reflection.BindingFlags.NonPublic,
                null,leftPanel, new object[] { true });
            leftPanel.Paint += DrawShape;
            leftPanel.MouseDown += MouseDownClick;
            leftPanel.MouseMove += MouseMovement;
            leftPanel.MouseUp += MouseUpClick;
        }

        private void EllipseButtonClick(object sender, EventArgs e)
        {
            int[] s = { 150, 200 };
            List<Point> p = new List<Point> { new Point(200, 200) };

            shapeList.Add(new Shape("Ellipse", s, p));
            leftPanel.Invalidate();
        }

        private void RectangleButtonClick(object sender, EventArgs e)
        {
            int[] s = { 200, 100 }; 
            List<Point> p = new List<Point> { new Point(300, 250) }; 
            shapeList.Add(new Shape("Rectangle", s, p));
            leftPanel.Invalidate();
        }

        private void TriangleButtonClick(object sender, EventArgs e)
        {
            List<Point> ls = new List<Point>
            {
                new Point(100, 0), new Point(0, 300), new Point(200, 300)
            };
            shapeList.Add(new Shape("Triangle", ls));
            leftPanel.Invalidate();
        }
        private void LineButtonClick(object sender, EventArgs e)
        {
            List<Point> l = new List<Point>
            {
                new Point(200,100),
                new Point(400,100)
            };
            shapeList.Add(new Shape("Line", l));
            leftPanel.Invalidate();
        }
        private void AdjustableRectangleButtonClick(object sender, EventArgs e)
        {
            List<Point> l = new List<Point>()
            {
                new Point(200,200),
                new Point(500,200),
                new Point(500,400),
                new Point(250,400)
            };
            shapeList.Add(new Shape("Adjustable Rectangle",l));
            leftPanel.Invalidate();
        }

        private void DrawShape(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var sh in shapeList)
            {
                if (sh.shapeName == "Ellipse")
                {
                    foreach (var loc in sh.location)
                    {
                        g.FillEllipse(Brushes.LightCoral, loc.X, loc.Y, sh.size[0], sh.size[1]);
                    }
                }
                if (sh.shapeName == "Rectangle")
                {
                    Point loc = sh.location[0];
                    g.FillRectangle(Brushes.LightBlue, loc.X, loc.Y, sh.size[0], sh.size[1]);
                }
                if (sh.shapeName == "Triangle")
                {  

 
                    List<Point> ls = sh.location;
                    g.FillPolygon(Brushes.Bisque,ls.ToArray());
                }
                if (sh.shapeName == "Line")
                {
                    using (Pen pen = new Pen(Color.Black, 3))
                    {
                        g.DrawLine(pen, sh.location[0], sh.location[1]);
                    }
                }
                if(sh.shapeName== "Adjustable Rectangle")
                {
                    g.FillPolygon(Brushes.BlueViolet, sh.location.ToArray());
                }

            }
        }

        private void MouseDownClick(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                foreach (var sh in shapeList)
                {
                    if (sh.shapeName == "Ellipse")
                    {
                        foreach (var loc in sh.location)
                        {
                            Rectangle rect = new Rectangle(loc.X, loc.Y, sh.size[0], sh.size[1]);
                            using (GraphicsPath g = new GraphicsPath()) {
                                g.AddRectangle(rect);
                                if (g.IsVisible(e.Location))
                                {
                                    selectedShape = sh;
                                    lastMousePos = e.Location;
                                    isDragging = true;
                                    Cursor = Cursors.SizeAll;
                                    return;
                                }
                            }
                        }
                    }

                    if (sh.shapeName == "Rectangle")
                    {
                        foreach(var loc in sh.location)
                        {
                            Rectangle rect = new Rectangle(loc.X, loc.Y, sh.size[0], sh.size[1]);
                            using (GraphicsPath g = new GraphicsPath())
                            {
                                g.AddRectangle(rect);
                                if (g.IsVisible(e.Location))
                                {
                                    selectedShape = sh;
                                    lastMousePos = e.Location;
                                    isDragging = true;
                                    Cursor = Cursors.SizeAll;
                                    return;
                                }
                            }
                        }
                    }

                    if (sh.shapeName == "Triangle")
                    {
                        using(GraphicsPath g=new GraphicsPath())
                        {
                            Point[] p = sh.location.ToArray();

                            g.AddPolygon(p);
                            if (g.IsVisible(e.Location))
                            {
                                selectedShape = sh;
                                lastMousePos = e.Location;
                                isDragging = true;
                                Cursor = Cursors.SizeAll;
                                return;
                            }
                        }
                    }
                    if (sh.shapeName == "Line")
                    {
                        using(GraphicsPath g=new GraphicsPath())
                        {
                            using (Pen p = new Pen(Color.Black, 3))
                            {
                                g.AddLine(sh.location[0], sh.location[1]);
                                if (g.IsOutlineVisible(e.Location,p))
                                {
                                    selectedShape = sh;
                                    lastMousePos = e.Location;
                                    isDragging = true;
                                    Cursor = Cursors.SizeAll;
                                    return;
                                }
                            }
                        }
                    }
                    if (sh.shapeName == "Adjustable Rectangle")
                    {
                        using(GraphicsPath g=new GraphicsPath())
                        {
                            g.AddPolygon(sh.location.ToArray());
                            if (g.IsVisible(e.Location))
                            {
                                selectedShape = sh;
                                lastMousePos = e.Location;
                                isDragging = true;
                                Cursor = Cursors.SizeAll;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void MouseMovement(object s, MouseEventArgs e)
        {
            if (isDragging && selectedShape != null)
            {
                int dx = e.X - lastMousePos.X;
                int dy = e.Y - lastMousePos.Y;

                for (int i = 0; i < selectedShape.location.Count; i++)
                {
                    selectedShape.location[i] = new Point(
                        selectedShape.location[i].X + dx,
                        selectedShape.location[i].Y + dy
                    );
                }

                lastMousePos = e.Location;
                leftPanel.Invalidate(); 
            }
        }

        private void MouseUpClick(object s, MouseEventArgs e)
        {
            isDragging = false;
            selectedShape = null;
            Cursor = Cursors.Default;
        }
    }

    public class Shape
    {
        public string shapeName;
        public int[] size;
        public List<Point> location;

        public Shape(string shapeName, int[] size, List<Point> location)
        {
            this.shapeName = shapeName;
            this.size = size;
            this.location = location;
        }
        public Shape(string shapeName, List<Point> location)
        {
            this.shapeName = shapeName;
            this.location = location;
        }
    }
}
