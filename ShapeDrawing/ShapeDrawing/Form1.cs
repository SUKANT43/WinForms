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
            leftPanel.Paint += drawShape;
            leftPanel.MouseDown += MouseDownClick;
            leftPanel.MouseMove += MouseMovement;
            leftPanel.MouseUp += MouseUpClick;
        }

        private void ellipseButtonClick(object sender, EventArgs e)
        {
            int[] s = { 150, 200 };
            List<Point> p = new List<Point> { new Point(200, 200) };

            shapeList.Add(new Shape("Ellipse", s, p));
            leftPanel.Invalidate();
        }

        private void drawShape(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var sh in shapeList)
            {
                if (sh.shapeName == "Ellipse")
                {
                    foreach (var loc in sh.location)
                    {
                        g.FillEllipse(Brushes.Black, loc.X, loc.Y, sh.size[0], sh.size[1]);
                    }
                }
            }
        }

        private void MouseDownClick(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Cursor = Cursors.SizeAll;
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
    }
}
